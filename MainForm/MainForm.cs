using DIS_Semestralka_S2_Letisko.Letisko;
using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
using DIS_Semestralka_S2_Letisko.Simulation.Collectors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;

namespace MainForm
{
    public partial class MainForm : Form, ISimDelegate
    {
        private LetiskoSimulation? _sim;
        private readonly System.Windows.Forms.Timer _refreshTimer = new();
        private readonly List<ReplicationForm> _replicationForms = new();
        private readonly List<SimulationForm>  _simulationForms  = new();
        private CancellationTokenSource? _depCts;
        private StreamWriter? _csvWriter;

        public MainForm()
        {
            InitializeComponent();
            _refreshTimer.Interval = 200;
            _refreshTimer.Tick += (s, e) => UpdateLabels();
        }

        // ── Simulation control ────────────────────────────────────────────

        private void btnReplicationStats_Click(object sender, EventArgs e)
        {
            var form = new ReplicationForm();
            _replicationForms.Add(form);
            form.FormClosed += (s, _) => _replicationForms.Remove((ReplicationForm)s!);
            form.Show();
        }

        private void btnSimulationStats_Click(object sender, EventArgs e)
        {
            var form = new SimulationForm();
            _simulationForms.Add(form);
            form.FormClosed += (s, _) => _simulationForms.Remove((SimulationForm)s!);
            form.Show();
        }

        private void numCestujucich_ValueChanged(object sender, EventArgs e)
        {
            double lambda = (double)numCestujucich.Value / 86400.0;
            lblLambdaValue.Text = $"{lambda:F6} /s";
        }

        private void chkWarmup_CheckedChanged(object sender, EventArgs e)
        {
            lblWarmupTimeTitle.Visible = chkWarmup.Checked;
            numWarmupTime.Visible      = chkWarmup.Checked;
        }

        private void chkProgressiveLambda_CheckedChanged(object sender, EventArgs e)
        {
            bool on = chkProgressiveLambda.Checked;
            // progresívny riadok
            lblOdTitle.Visible        = on;
            numCestujucichOd.Visible  = on;
            lblDoTitle.Visible        = on;
            numCestujucichDo.Visible  = on;
            // fixný riadok
            lblCestujucichTitle.Visible = !on;
            numCestujucich.Visible      = !on;
            lblLambdaTitle.Visible      = !on;
            lblLambdaValue.Visible      = !on;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (chkProgressiveLambda.Checked)
                StartProgressiveRun();
            else
                StartNormalRun();
        }

        private void StartNormalRun()
        {
            if (_sim != null) { _sim.Pause = false; _sim.Run = false; }

            double lambda  = (double)numCestujucich.Value / 86400.0;
            int replikacii = chkMaxSpeed.Checked ? (int)numReplikacii.Value : 1;

            _sim = new LetiskoSimulation(lambda);
            _sim.WarmupTime = chkWarmup.Checked ? (double)numWarmupTime.Value : 0;
            _sim.MaxPasPred = (int)numMaxPasPred.Value;
            _sim.MaxPasZa   = (int)numMaxPasZa.Value;
            _sim.RegisterDelegate(this);
            ApplySpeedSettings();
            foreach (var f in _simulationForms) f.Reset();

            // Inkrementálny CSV záznam — iba v slowdown móde (1 replikácia)
            if (chkSaveCsv.Checked && !chkMaxSpeed.Checked)
                OpenIncrementalCsv();

            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled  = true;
            if (!chkMaxSpeed.Checked)
                _refreshTimer.Start();

            Task.Run(() => _sim.RunSimulation(replikacii))
                .ContinueWith(_ => BeginInvoke(OnSimulationFinished));
        }

        private void StartProgressiveRun()
        {
            btnStart.Enabled = false;
            btnStop.Enabled  = true;

            int odCestujuci = (int)numCestujucichOd.Value;
            int doCestujuci = (int)numCestujucichDo.Value;
            int replikacii  = (int)numReplikacii.Value;
            int maxPasPred  = (int)numMaxPasPred.Value;
            int maxPasZa    = (int)numMaxPasZa.Value;

            _depCts = new CancellationTokenSource();
            var token = _depCts.Token;

            var rows = new List<string[]>();

            Task.Run(() =>
            {
                for (int i = 0; i < replikacii; i++)
                {
                    if (token.IsCancellationRequested) break;

                    int cestujuci = replikacii == 1
                        ? odCestujuci
                        : odCestujuci + (int)Math.Round((double)(doCestujuci - odCestujuci) * i / (replikacii - 1));
                    double lambda = cestujuci / 86400.0;

                    var sim = new LetiskoSimulation(lambda);
                    sim.MaxPasPred = maxPasPred;
                    sim.MaxPasZa   = maxPasZa;
                    sim.RunSimulation(1);

                    rows.Add([
                        (i + 1).ToString(),
                        cestujuci.ToString(),
                        lambda.ToString("F6", System.Globalization.CultureInfo.InvariantCulture),
                        sim.GlobalAvgCasVSysteme.Average.ToString("F4", System.Globalization.CultureInfo.InvariantCulture),
                        sim.GlobalAvgRadPredRontgenomSpolu.Average.ToString("F4", System.Globalization.CultureInfo.InvariantCulture),
                        sim.GlobalAvgRadPredDetektoromSpolu.Average.ToString("F4", System.Globalization.CultureInfo.InvariantCulture),
                        sim.GlobalAvgRadPredZberomSpolu.Average.ToString("F4", System.Globalization.CultureInfo.InvariantCulture)
                    ]);
                }
            }).ContinueWith(_ => BeginInvoke(() =>
            {
                btnStart.Enabled = true;
                btnStop.Enabled  = false;
                _depCts = null;

                if (rows.Count > 0)
                    SaveProgressiveCsv(rows);
            }));
        }

        private void SaveProgressiveCsv(List<string[]> rows)
        {
            using var dlg = new SaveFileDialog
            {
                Title      = "Uložiť výsledky progresívnej lambdy",
                Filter     = "CSV súbory (*.csv)|*.csv|Všetky súbory (*.*)|*.*",
                FileName   = $"progressive_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            var lines = new List<string>
            {
                "Replikacia,Cestujuci,Lambda,CasVSysteme,RadRontgen,RadDetektor,RadZber"
            };
            lines.AddRange(rows.Select(r => string.Join(",", r)));

            File.WriteAllLines(dlg.FileName, lines, System.Text.Encoding.UTF8);
            MessageBox.Show($"Uložené: {dlg.FileName}", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_sim == null) return;
            _sim.Pause = !_sim.Pause;
            btnPause.Text = _sim.Pause ? "Resume" : "Pause";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_sim != null) { _sim.Pause = false; _sim.Run = false; }
            _depCts?.Cancel();
        }

        private void chkDependency_CheckedChanged(object sender, EventArgs e)
        {
            bool on = chkDependency.Checked;
            lblTestPointsTitle.Visible = on;
            numTestPoints.Visible      = on;
            btnDependency.Visible      = on;
        }

        private void btnDependency_Click(object sender, EventArgs e)
        {
            var depForm = new DependencyForm();
            depForm.Show();

            btnStart.Enabled      = false;
            btnDependency.Enabled = false;
            btnStop.Enabled       = true;

            int baseCestujuci = (int)numCestujucich.Value;
            int n             = (int)numTestPoints.Value;
            int replikacii    = (int)numReplikacii.Value;
            int maxPasPred    = (int)numMaxPasPred.Value;
            int maxPasZa      = (int)numMaxPasZa.Value;

            double[] factors = ComputeTestFactors(n);
            _depCts = new CancellationTokenSource();
            var token = _depCts.Token;

            Task.Run(() =>
            {
                foreach (double factor in factors)
                {
                    if (token.IsCancellationRequested) break;

                    int cestujuci = Math.Max(1, (int)Math.Round(baseCestujuci * (1.0 + factor)));
                    double lambda = cestujuci / 86400.0;

                    var sim = new LetiskoSimulation(lambda);
                    sim.MaxPasPred = maxPasPred;
                    sim.MaxPasZa   = maxPasZa;
                    sim.RunSimulation(replikacii);

                    var result = new DependencyResult(
                        cestujuci, lambda,
                        sim.GlobalAvgCasVSysteme.Average,
                        sim.GlobalAvgCasVSysteme.GetConfidenceInterval(),
                        sim.GlobalAvgRadPredRontgenomSpolu.Average,
                        sim.GlobalAvgRadPredRontgenomSpolu.GetConfidenceInterval(),
                        sim.GlobalAvgRadPredDetektoromSpolu.Average,
                        sim.GlobalAvgRadPredDetektoromSpolu.GetConfidenceInterval(),
                        sim.GlobalAvgRadPredZberomSpolu.Average,
                        sim.GlobalAvgRadPredZberomSpolu.GetConfidenceInterval()
                    );

                    if (!depForm.IsDisposed)
                        BeginInvoke(() => depForm.AddResult(result));
                }
            }).ContinueWith(_ => BeginInvoke(() =>
            {
                btnStart.Enabled      = true;
                btnDependency.Enabled = true;
                btnStop.Enabled       = false;
                _depCts = null;
            }));
        }

        private static double[] ComputeTestFactors(int n)
        {
            if (n == 1) return [0.0];
            double step = 0.20 / (n - 1);
            return Enumerable.Range(0, n).Select(i => -0.10 + i * step).ToArray();
        }

        private void OnSimulationFinished()
        {
            _refreshTimer.Stop();
            UpdateLabels();
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnPause.Text = "Pause";

            if (_csvWriter != null)
            {
                // Inkrementálny CSV — zavrieme súbor
                _csvWriter.Flush();
                _csvWriter.Close();
                _csvWriter = null;
            }
            else if (chkSaveCsv.Checked && _sim != null)
            {
                // MaxSpeed mód — uložíme globálne štatistiky na konci
                SaveSimulationCsv(_sim);
            }
        }

        private void OpenIncrementalCsv()
        {
            using var dlg = new SaveFileDialog
            {
                Title      = "Uložiť priebežné dáta simulácie",
                Filter     = "CSV súbory (*.csv)|*.csv|Všetky súbory (*.*)|*.*",
                FileName   = $"simulation_priebeh_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            _csvWriter = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
            _csvWriter.WriteLine("SimCas,RadRontgen1,RadRontgen2,RadRontgenSpolu," +
                                 "RadDetektor1,RadDetektor2,RadDetektorSpolu," +
                                 "RadZber1,RadZber2,RadZberSpolu,AvgCasVSysteme");
        }

        private void AppendCsvRow()
        {
            if (_csvWriter == null || _sim == null) return;

            static string F(double v) => v.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);
            double t = Math.Max(0, _sim.CurrentTime - _sim.WarmupTime);
            string time = $"{(int)(t / 3600):D2}:{(int)(t / 60) % 60:D2}:{(int)(t % 60):D2}";

            _csvWriter.WriteLine(string.Join(",",
                time,
                F(_sim.PocetVRadePredRontgenom1.WeightedAverage),
                F(_sim.PocetVRadePredRontgenom2.WeightedAverage),
                F(_sim.PocetVRadePredRontgenomSpolu.WeightedAverage),
                F(_sim.PocetVRadePredDetektorom1.WeightedAverage),
                F(_sim.PocetVRadePredDetektorom2.WeightedAverage),
                F(_sim.PocetVRadePredDetektoromSpolu.WeightedAverage),
                F(_sim.PocetVRadePredZberom1.WeightedAverage),
                F(_sim.PocetVRadePredZberom2.WeightedAverage),
                F(_sim.PocetVRadePredZberomSpolu.WeightedAverage),
                F(_sim.CasVSystemeCollector.Average)));
        }

        private void SaveSimulationCsv(LetiskoSimulation sim)
        {
            using var dlg = new SaveFileDialog
            {
                Title      = "Uložiť výsledky simulácie",
                Filter     = "CSV súbory (*.csv)|*.csv|Všetky súbory (*.*)|*.*",
                FileName   = $"simulation_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            static string Fmt(double v) => v.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);
            static string CiStr((double Lower, double Upper)? ci) =>
                ci.HasValue ? $"{Fmt(ci.Value.Lower)},{Fmt(ci.Value.Upper)}" : ",";

            var lines = new List<string>
            {
                "Metrika,Priemer,CI_Dolny,CI_Horny"
            };

            void AddRow(string name, StatisticsCollector col)
                => lines.Add($"{name},{Fmt(col.Average)},{CiStr(col.GetConfidenceInterval())}");

            AddRow("CasVSysteme",             sim.GlobalAvgCasVSysteme);
            AddRow("RadRontgen1",             sim.GlobalAvgRadPredRontgenom1);
            AddRow("RadRontgen2",             sim.GlobalAvgRadPredRontgenom2);
            AddRow("RadRontgenSpolu",         sim.GlobalAvgRadPredRontgenomSpolu);
            AddRow("RadDetektor1",            sim.GlobalAvgRadPredDetektorom1);
            AddRow("RadDetektor2",            sim.GlobalAvgRadPredDetektorom2);
            AddRow("RadDetektorSpolu",        sim.GlobalAvgRadPredDetektoromSpolu);
            AddRow("RadZber1",                sim.GlobalAvgRadPredZberom1);
            AddRow("RadZber2",                sim.GlobalAvgRadPredZberom2);
            AddRow("RadZberSpolu",            sim.GlobalAvgRadPredZberomSpolu);

            File.WriteAllLines(dlg.FileName, lines, System.Text.Encoding.UTF8);
            MessageBox.Show($"Uložené: {dlg.FileName}", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Speed controls ────────────────────────────────────────────────

        private void chkMaxSpeed_CheckedChanged(object sender, EventArgs e)
        {
            bool maxSpeed = chkMaxSpeed.Checked;
            sldSleep.Enabled = !maxSpeed;
            sldStep.Enabled = !maxSpeed;

            if (_sim == null) return;

            if (maxSpeed)
            {
                _sim.Slowdown = false;
            }
            else
            {
                ApplySpeedSettings();
                _sim.ScheduleEvent(new SleepEvent(_sim, _sim.Length), _sim.CurrentTime);
            }
        }

        private void sldSleep_Scroll(object sender, EventArgs e)
        {
            lblSleepValue.Text = $"{sldSleep.Value} ms";
            if (_sim != null) ApplySpeedSettings();
        }

        private void sldStep_Scroll(object sender, EventArgs e)
        {
            lblStepValue.Text = $"{sldStep.Value}";
            if (_sim != null) ApplySpeedSettings();
        }

        private void ApplySpeedSettings()
        {
            if (_sim == null) return;
            bool maxSpeed = chkMaxSpeed.Checked;
            _sim.Slowdown = !maxSpeed;
            if (!maxSpeed)
            {
                _sim.Length = sldSleep.Value;
                _sim.Rate = (double)sldStep.Value / sldSleep.Value;
            }
        }

        // ── ISimDelegate ──────────────────────────────────────────────────────

        public void Refresh(Event_Core simulation)
        {
            if (InvokeRequired)
                BeginInvoke(() => { RefreshInternal(); AppendCsvRow(); });
            else
            { RefreshInternal(); AppendCsvRow(); }
        }

        private void RefreshInternal()
        {
            if (_sim == null) return;

            bool isMaxSpeed = chkMaxSpeed.Checked;

            // Pri MaxSpeed iba updatujeme grafy, nie Labels
            if (isMaxSpeed)
            {
                UpdateGlobalStats();
            }
            else
            {
                UpdateLabels();
            }
        }

        // ── Label update ──────────────────────────────────────────────────────

        private void UpdateLabels()
        {
            if (_sim == null) return;

            double t = Math.Max(0, _sim.CurrentTime - _sim.WarmupTime);
            lblSimTimeValue.Text = $"{(int)(t / 3600):D2}:{(int)(t / 60) % 60:D2}:{(int)(t % 60):D2}";
            lblPocetValue.Text = _sim.PocetCestujucich.ToString();

            UpdateTerminal(
                lstQueue1, lblRontgenCestujuci1Value, lblRontgenPrepravka1Value, lstPasPred1, lstPasZa1,
                lblDetektor1Value, lstRadDetektor1,
                lblZber1Value, lstRadZber1,
                _sim.RadPredRontgenom1, _sim.Rontgen1,
                _sim.Detektor1, _sim.RadPredDetektorom1,
                _sim.ZberPrepraviek1Volny, _sim.RadPredZberomPrepraviek1, _sim);

            UpdateTerminal(
                lstQueue2, lblRontgenCestujuci2Value, lblRontgenPrepravka2Value, lstPasPred2, lstPasZa2,
                lblDetektor2Value, lstRadDetektor2,
                lblZber2Value, lstRadZber2,
                _sim.RadPredRontgenom2, _sim.Rontgen2,
                _sim.Detektor2, _sim.RadPredDetektorom2,
                _sim.ZberPrepraviek2Volny, _sim.RadPredZberomPrepraviek2, _sim);

            lblCasVSystemeValue.Text          = _sim.CasVSystemeCollector.Average.ToString("F2");
            lblAvgRadRontgen1Value.Text       = _sim.PocetVRadePredRontgenom1.WeightedAverage.ToString("F4");
            lblAvgRadRontgen2Value.Text       = _sim.PocetVRadePredRontgenom2.WeightedAverage.ToString("F4");
            lblAvgRadDetektor1Value.Text      = _sim.PocetVRadePredDetektorom1.WeightedAverage.ToString("F4");
            lblAvgRadDetektor2Value.Text      = _sim.PocetVRadePredDetektorom2.WeightedAverage.ToString("F4");
            lblAvgRadZber1Value.Text          = _sim.PocetVRadePredZberom1.WeightedAverage.ToString("F4");
            lblAvgRadZber2Value.Text          = _sim.PocetVRadePredZberom2.WeightedAverage.ToString("F4");
            lblAvgRadRontgenSpoluValue.Text   = _sim.PocetVRadePredRontgenomSpolu.WeightedAverage.ToString("F4");
            lblAvgRadDetektorSpoluValue.Text  = _sim.PocetVRadePredDetektoromSpolu.WeightedAverage.ToString("F4");
            lblAvgRadZberSpoluValue.Text      = _sim.PocetVRadePredZberomSpolu.WeightedAverage.ToString("F4");

            if (!chkMaxSpeed.Checked)
                foreach (var f in _replicationForms) f.Update(_sim);

            UpdateGlobalStats();
        }

        private void UpdateGlobalStats()
        {
            if (_sim == null) return;
            int rep = _sim.GlobalAvgCasVSysteme.ValueCounter;
            lblReplikacieValue.Text                 = rep.ToString();
            lblGlobalCasVSystemeValue.Text          = rep > 0 ? _sim.GlobalAvgCasVSysteme.Average.ToString("F2")           : "—";
            lblGlobalAvgRadRontgen1Value.Text       = rep > 0 ? _sim.GlobalAvgRadPredRontgenom1.Average.ToString("F4")     : "—";
            lblGlobalAvgRadRontgen2Value.Text       = rep > 0 ? _sim.GlobalAvgRadPredRontgenom2.Average.ToString("F4")     : "—";
            lblGlobalAvgRadDetektor1Value.Text      = rep > 0 ? _sim.GlobalAvgRadPredDetektorom1.Average.ToString("F4")    : "—";
            lblGlobalAvgRadDetektor2Value.Text      = rep > 0 ? _sim.GlobalAvgRadPredDetektorom2.Average.ToString("F4")    : "—";
            lblGlobalAvgRadZber1Value.Text          = rep > 0 ? _sim.GlobalAvgRadPredZberom1.Average.ToString("F4")        : "—";
            lblGlobalAvgRadZber2Value.Text          = rep > 0 ? _sim.GlobalAvgRadPredZberom2.Average.ToString("F4")        : "—";
            lblGlobalAvgRadRontgenSpoluValue.Text   = rep > 0 ? _sim.GlobalAvgRadPredRontgenomSpolu.Average.ToString("F4") : "—";
            lblGlobalAvgRadDetektorSpoluValue.Text  = rep > 0 ? _sim.GlobalAvgRadPredDetektoromSpolu.Average.ToString("F4"): "—";
            lblGlobalAvgRadZberSpoluValue.Text      = rep > 0 ? _sim.GlobalAvgRadPredZberomSpolu.Average.ToString("F4")    : "—";

            foreach (var f in _simulationForms) f.Update(_sim);
        }

        private static void UpdateTerminal(
            ListBox lstQueue,
            Label lblRontgenCestujuciValue,
            Label lblRontgenPrepravkaValue,
            ListBox lstPasPred,
            ListBox lstPasZa,
            Label lblDetektorValue,
            ListBox lstRadDetektor,
            Label lblZberValue,
            ListBox lstRadZber,
            Queue<Cestujuci> rad,
            Rontgen rontgen,
            DetektorKovu detektor,
            Queue<Cestujuci> radDetektor,
            bool zberVolny,
            Queue<Cestujuci> radZber,
            LetiskoSimulation sim)
        {
            FillListBox(lstQueue, SafeToArray(rad, sim), c => $"ID {c.ID}");

            lblRontgenCestujuciValue.Text = rontgen.JeVolnyCestujuci ? "Voľný" : "Zaneprázdnený";
            lblRontgenCestujuciValue.ForeColor = rontgen.JeVolnyCestujuci ? Color.Green : Color.Red;

            lblRontgenPrepravkaValue.Text = rontgen.JeVolnyPrepravka ? "Voľný" : "Zaneprázdnený";
            lblRontgenPrepravkaValue.ForeColor = rontgen.JeVolnyPrepravka ? Color.Green : Color.Red;

            FillListBox(lstPasPred, SafeToArray(rontgen.PrepravkyPredRontgenom, sim), p => $"ID {p.ID}  (ces. {p.ID_Cestujuci})");
            FillListBox(lstPasZa,   SafeToArray(rontgen.PrepravkyZaRontgenom, sim),   p => $"ID {p.ID}  (ces. {p.ID_Cestujuci})");

            lblDetektorValue.Text = detektor.JeVolny ? "Voľný" : "Zaneprázdnený";
            lblDetektorValue.ForeColor = detektor.JeVolny ? Color.Green : Color.Red;

            FillListBox(lstRadDetektor, SafeToArray(radDetektor, sim), c => $"ID {c.ID}");

            lblZberValue.Text = zberVolny ? "Voľný" : "Zaneprázdnený";
            lblZberValue.ForeColor = zberVolny ? Color.Green : Color.Red;

            FillListBox(lstRadZber, SafeToArray(radZber, sim), c => $"ID {c.ID}");
        }

        private static void FillListBox<T>(ListBox lb, T[] items, Func<T, string> format)
        {
            lb.BeginUpdate();
            lb.Items.Clear();
            foreach (var item in items)
            {
                if (item != null)
                    lb.Items.Add(format(item));
            }
            lb.EndUpdate();
        }

        private static T[] SafeToArray<T>(Queue<T> queue, LetiskoSimulation sim)
        {
            if (queue == null) return [];
            
            lock (sim.QueueAccessLock)
            {
                try { return queue.ToArray(); }
                catch { return []; }
            }
        }
    }
}
