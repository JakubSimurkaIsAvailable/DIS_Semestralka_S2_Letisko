using DIS_Semestralka_S2_Letisko.Letisko;
using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;

namespace MainForm
{
    // 2.1.1 Štruktúra formulára
    public partial class MainForm : Form, ISimDelegate
    {
        private LetiskoSimulation? _sim;
        private readonly System.Windows.Forms.Timer _refreshTimer = new();
        private readonly List<ReplicationForm> _replicationForms = new();
        private readonly List<SimulationForm> _simulationForms = new();
        private CancellationTokenSource? _depCts;
        private StreamWriter? _csvWriter;

        public MainForm()
        {
            InitializeComponent();
            _refreshTimer.Interval = 200;
            _refreshTimer.Tick += (s, e) => UpdateLabels();
        }

        // 2.1.2 Vstupné parametre
        private void numCestujucich_ValueChanged(object sender, EventArgs e)
        {
            double lambda = (double)numCestujucich.Value / 86400.0;
            lblLambdaValue.Text = $"{lambda:F6} /s";
        }

        // 2.1.2 Vstupné parametre
        private void chkWarmup_CheckedChanged(object sender, EventArgs e)
        {
            lblWarmupTimeTitle.Visible = chkWarmup.Checked;
            numWarmupTime.Visible = chkWarmup.Checked;
        }

        // 2.1.2 Vstupné parametre — konverzia jednotky trvania na sekundy
        private double GetSimDurationInSeconds()
        {
            double value = (double)numSimDuration.Value;
            return cmbSimDurationUnit.SelectedIndex switch
            {
                0 => value * 60,
                1 => value * 3600,
                2 => value * 86400,
                _ => value * 3600
            };
        }

        // 2.1.2 Vstupné parametre — seed pre generátor náhodných čísel
        private int? GetSeed() => chkFixedSeed.Checked ? (int)numSeed.Value : null;

        // 2.1.2 Vstupné parametre — prepínanie fixného seedu
        private void chkFixedSeed_CheckedChanged(object sender, EventArgs e)
        {
            lblSeedTitle.Visible = chkFixedSeed.Checked;
            numSeed.Visible = chkFixedSeed.Checked;
        }

        // 2.1.2 Vstupné parametre — prepínanie progresívnej lambdy
        private void chkProgressiveLambda_CheckedChanged(object sender, EventArgs e)
        {
            bool on = chkProgressiveLambda.Checked;
            lblOdTitle.Visible = on;
            numCestujucichOd.Visible = on;
            lblDoTitle.Visible = on;
            numCestujucichDo.Visible = on;
            lblCestujucichTitle.Visible = !on;
            numCestujucich.Visible = !on;
            lblLambdaTitle.Visible = !on;
            lblLambdaValue.Visible = !on;
        }

        // 2.1.8 CSV export — prepínanie viditeľnosti intervalu
        private void chkCollectByInterval_CheckedChanged(object sender, EventArgs e)
        {
            numCollectInterval.Visible = chkCollectByInterval.Checked;
        }

        // 2.1.3 Rýchlosť simulácie
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

        // 2.1.3 Rýchlosť simulácie
        private void sldSleep_Scroll(object sender, EventArgs e)
        {
            lblSleepValue.Text = $"{sldSleep.Value} ms";
            if (_sim != null) ApplySpeedSettings();
        }

        // 2.1.3 Rýchlosť simulácie
        private void sldStep_Scroll(object sender, EventArgs e)
        {
            lblStepValue.Text = $"{sldStep.Value}";
            if (_sim != null) ApplySpeedSettings();
        }

        // 2.1.3 Rýchlosť simulácie — aplikovanie nastavení rýchlosti na bežiacu simuláciu
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

        // 2.1.4 Tlačidlá — rozhodnutie medzi normálnym a progresívnym behom
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (chkProgressiveLambda.Checked)
                StartProgressiveRun();
            else
                StartNormalRun();
        }

        // 2.1.4 Tlačidlá — Pause / Resume
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_sim == null) return;
            _sim.Pause = !_sim.Pause;
            btnPause.Text = _sim.Pause ? "Resume" : "Pause";
        }

        // 2.1.4 Tlačidlá — Stop
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_sim != null) { _sim.Pause = false; _sim.Run = false; }
            _depCts?.Cancel();
        }

        // 2.1.5 Normálny beh
        private void StartNormalRun()
        {
            if (_sim != null) { _sim.Pause = false; _sim.Run = false; }

            double lambda = (double)numCestujucich.Value / 86400.0;
            int replikacii = chkMaxSpeed.Checked ? (int)numReplikacii.Value : 1;

            _sim = new LetiskoSimulation(lambda, GetSeed());
            _sim.SimDuration = GetSimDurationInSeconds();
            _sim.WarmupTime = chkWarmup.Checked ? (double)numWarmupTime.Value : 0;
            _sim.MaxPasPred = (int)numMaxPasPred.Value;
            _sim.MaxPasZa = (int)numMaxPasZa.Value;
            _sim.RegisterDelegate(this);
            ApplySpeedSettings();
            foreach (var f in _simulationForms) f.Reset();

            // 2.1.8 CSV export — otvorenie súboru pred spustením simulácie
            if (chkSaveCsv.Checked)
            {
                if (chkCollectByInterval.Checked)
                {
                    _sim.CollectInterval = (double)numCollectInterval.Value;
                    OpenIntervalCsv();
                }
                else
                {
                    _sim.CollectInterval = 0;
                    OpenReplicationCsv();
                }
            }

            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            if (!chkMaxSpeed.Checked)
                _refreshTimer.Start();

            Task.Run(() => _sim.RunSimulation(replikacii))
                .ContinueWith(_ => BeginInvoke(OnSimulationFinished));
        }

        // 2.1.5 Normálny beh — upratanie po skončení simulácie
        private void OnSimulationFinished()
        {
            _refreshTimer.Stop();
            UpdateLabels();
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnPause.Text = "Pause";

            // 2.1.8 CSV export — zatvorenie writera
            if (_csvWriter != null)
            {
                _csvWriter.Flush();
                _csvWriter.Close();
                _csvWriter = null;
                if (_sim != null) _sim.CsvOutput = null;
            }
        }

        // 2.1.6 Progresívny beh
        private void StartProgressiveRun()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            int odCestujuci = (int)numCestujucichOd.Value;
            int doCestujuci = (int)numCestujucichDo.Value;
            int replikacii = (int)numReplikacii.Value;
            int maxPasPred = (int)numMaxPasPred.Value;
            int maxPasZa = (int)numMaxPasZa.Value;
            double simDuration = GetSimDurationInSeconds();
            double warmupTime = chkWarmup.Checked ? (double)numWarmupTime.Value : 0;
            int? seed = GetSeed();

            _depCts = new CancellationTokenSource();
            var token = _depCts.Token;
            var rows = new List<string[]>();
            int rowIndex = 1;

            Task.Run(() =>
            {
                for (int cestujuci = odCestujuci; cestujuci <= doCestujuci; cestujuci++)
                {
                    if (token.IsCancellationRequested) break;

                    double lambda = cestujuci / 86400.0;
                    var sim = new LetiskoSimulation(lambda, seed);
                    sim.SimDuration = simDuration;
                    sim.WarmupTime = warmupTime;
                    sim.MaxPasPred = maxPasPred;
                    sim.MaxPasZa = maxPasZa;
                    sim.RunSimulation(replikacii);

                    static string Fv(double v) =>
                        v.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);
                    static string Ci((double Lower, double Upper)? ci) =>
                        ci.HasValue ? $"{Fv(ci.Value.Lower)},{Fv(ci.Value.Upper)}" : ",";

                    rows.Add([
                        (rowIndex++).ToString(),
                        cestujuci.ToString(),
                        lambda.ToString("F6", System.Globalization.CultureInfo.InvariantCulture),
                        Fv(sim.GlobalAvgCasVSysteme.Average),
                        Ci(sim.GlobalAvgCasVSysteme.GetConfidenceInterval()),
                        Fv(sim.GlobalAvgRadPredRontgenomSpolu.Average),
                        Ci(sim.GlobalAvgRadPredRontgenomSpolu.GetConfidenceInterval()),
                        Fv(sim.GlobalAvgRadPredDetektoromSpolu.Average),
                        Ci(sim.GlobalAvgRadPredDetektoromSpolu.GetConfidenceInterval()),
                        Fv(sim.GlobalAvgRadPredZberomSpolu.Average),
                        Ci(sim.GlobalAvgRadPredZberomSpolu.GetConfidenceInterval())
                    ]);
                }
            }).ContinueWith(_ => BeginInvoke(() =>
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                _depCts = null;
                if (rows.Count > 0)
                    SaveProgressiveCsv(rows);
            }));
        }

        // 2.1.6 Progresívny beh — uloženie výsledkov do CSV
        private void SaveProgressiveCsv(List<string[]> rows)
        {
            using var dlg = new SaveFileDialog
            {
                Title = "Uložiť výsledky progresívnej lambdy",
                Filter = "CSV súbory (*.csv)|*.csv|Všetky súbory (*.*)|*.*",
                FileName = $"progressive_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            var lines = new List<string>
            {
                "Replikacia,Cestujuci,Lambda," +
                "CasVSysteme,CI_Cas_Dolny,CI_Cas_Horny," +
                "RadRontgenSpolu,CI_Rontgen_Dolny,CI_Rontgen_Horny," +
                "RadDetektorSpolu,CI_Detektor_Dolny,CI_Detektor_Horny," +
                "RadZberSpolu,CI_Zber_Dolny,CI_Zber_Horny"
            };
            lines.AddRange(rows.Select(r => string.Join(",", r)));
            File.WriteAllLines(dlg.FileName, lines, System.Text.Encoding.UTF8);
            MessageBox.Show($"Uložené: {dlg.FileName}", "Hotovo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2.1.7 Test závislosti — prepínanie viditeľnosti ovládacích prvkov
        private void chkDependency_CheckedChanged(object sender, EventArgs e)
        {
            bool on = chkDependency.Checked;
            lblTestPointsTitle.Visible = on;
            numTestPoints.Visible = on;
            btnDependency.Visible = on;
        }

        // 2.1.7 Test závislosti
        private void btnDependency_Click(object sender, EventArgs e)
        {
            var depForm = new DependencyForm();
            depForm.Show();

            btnStart.Enabled = false;
            btnDependency.Enabled = false;
            btnStop.Enabled = true;

            int baseCestujuci = (int)numCestujucich.Value;
            int n = (int)numTestPoints.Value;
            int replikacii = (int)numReplikacii.Value;
            int maxPasPred = (int)numMaxPasPred.Value;
            int maxPasZa = (int)numMaxPasZa.Value;
            double simDuration = GetSimDurationInSeconds();
            double warmupTime = chkWarmup.Checked ? (double)numWarmupTime.Value : 0;
            int? seed = GetSeed();

            double[] factors = ComputeTestFactors(n);
            _depCts = new CancellationTokenSource();
            var token = _depCts.Token;
            var depResults = new List<DependencyResult>();

            Task.Run(() =>
            {
                foreach (double factor in factors)
                {
                    if (token.IsCancellationRequested) break;

                    int cestujuci = Math.Max(1, (int)Math.Round(baseCestujuci * (1.0 + factor)));
                    double lambda = cestujuci / 86400.0;

                    var sim = new LetiskoSimulation(lambda, seed);
                    sim.SimDuration = simDuration;
                    sim.WarmupTime = warmupTime;
                    sim.MaxPasPred = maxPasPred;
                    sim.MaxPasZa = maxPasZa;
                    sim.RunSimulation(replikacii);

                    var result = new DependencyResult(
                        cestujuci, lambda,
                        sim.GlobalAvgCasVSysteme.Average,
                        sim.GlobalAvgCasVSysteme.GetConfidenceInterval(),
                        sim.GlobalAvgRadPredRontgenomSpolu.Average,
                        sim.GlobalAvgRadPredRontgenomSpolu.GetConfidenceInterval(),
                        sim.GlobalAvgRadPredZberomSpolu.Average,
                        sim.GlobalAvgRadPredZberomSpolu.GetConfidenceInterval()
                    );

                    depResults.Add(result);
                    if (!depForm.IsDisposed)
                        BeginInvoke(() => depForm.AddResult(result));
                }
            }).ContinueWith(_ => BeginInvoke(() =>
            {
                btnStart.Enabled = true;
                btnDependency.Enabled = true;
                btnStop.Enabled = false;
                _depCts = null;

                if (chkSaveCsv.Checked && depResults.Count > 0)
                    SaveDependencyCsv(depResults);
            }));
        }

        // 2.1.7 Test závislosti — generovanie testovacích faktorov od -0.10 do +0.10
        private static double[] ComputeTestFactors(int n)
        {
            if (n == 1) return [0.0];
            double step = 0.20 / (n - 1);
            return Enumerable.Range(0, n).Select(i => -0.10 + i * step).ToArray();
        }

        // 2.1.7 Test závislosti — uloženie výsledkov do CSV
        private void SaveDependencyCsv(List<DependencyResult> results)
        {
            using var dlg = new SaveFileDialog
            {
                Title = "Uložiť výsledky testu závislosti",
                Filter = "CSV súbory (*.csv)|*.csv|Všetky súbory (*.*)|*.*",
                FileName = $"zavislost_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            static string Fmt(double v) =>
                v.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);
            static string CiStr((double Lower, double Upper)? ci) =>
                ci.HasValue ? $"{Fmt(ci.Value.Lower)},{Fmt(ci.Value.Upper)}" : ",";

            var lines = new List<string>
            {
                "Cestujuci,Lambda,CasVSysteme,CI_Cas_Dolny,CI_Cas_Horny," +
                "RadRontgen,CI_Rontgen_Dolny,CI_Rontgen_Horny," +
                "RadZber,CI_Zber_Dolny,CI_Zber_Horny"
            };
            foreach (var r in results)
            {
                lines.Add(string.Join(",",
                    r.Cestujuci,
                    r.Lambda.ToString("F6", System.Globalization.CultureInfo.InvariantCulture),
                    Fmt(r.CasVSysteme), CiStr(r.CiCas),
                    Fmt(r.RadRontgen), CiStr(r.CiRontgen),
                    Fmt(r.RadZber), CiStr(r.CiZber)));
            }
            File.WriteAllLines(dlg.FileName, lines, System.Text.Encoding.UTF8);
            MessageBox.Show($"Uložené: {dlg.FileName}", "Hotovo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2.1.8 CSV export — otvorenie súboru pre intervalový zber (Welch)
        private void OpenIntervalCsv()
        {
            using var dlg = new SaveFileDialog
            {
                Title = "Uložiť priebežné pozorovania do CSV",
                Filter = "CSV súbory (*.csv)|*.csv|Všetky súbory (*.*)|*.*",
                FileName = $"welch_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            _csvWriter = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
            _csvWriter.WriteLine(LetiskoSimulation.CsvObservationHeader);
            _sim!.CsvOutput = _csvWriter;
        }

        // 2.1.8 CSV export — otvorenie súboru pre súhrn replikácií
        private void OpenReplicationCsv()
        {
            using var dlg = new SaveFileDialog
            {
                Title = "Uložiť súhrn replikácií do CSV",
                Filter = "CSV súbory (*.csv)|*.csv|Všetky súbory (*.*)|*.*",
                FileName = $"replikacie_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            _csvWriter = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
            _csvWriter.WriteLine(LetiskoSimulation.CsvReplicationHeader);
            _sim!.CsvOutput = _csvWriter;
        }

        // 2.1.1 Štruktúra formulára — otvorenie okien štatistík
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

        // 2.1.9 Live zobrazenie — ISimDelegate callback
        public void Refresh(Event_Core simulation)
        {
            if (InvokeRequired)
                BeginInvoke(RefreshInternal);
            else
                RefreshInternal();
        }

        // 2.1.9 Live zobrazenie / 2.1.10 Globálne štatistiky — rozhodnutie podľa MaxSpeed
        private void RefreshInternal()
        {
            if (_sim == null) return;
            if (chkMaxSpeed.Checked)
                UpdateGlobalStats();
            else
                UpdateLabels();
        }

        // 2.1.9 Live zobrazenie — hlavná aktualizácia labelov a frontov
        private void UpdateLabels()
        {
            if (_sim == null) return;

            double t = Math.Max(0, _sim.CurrentTime - _sim.WarmupTime);
            lblSimTimeValue.Text = $"{(int)(t / 3600):D2}:{(int)(t / 60) % 60:D2}:{(int)(t % 60):D2}";
            lblPocetValue.Text = _sim.PocetCestujucich.ToString();

            UpdateTerminal(
                lstQueue1, lblRontgenCestujuci1Value, lblRontgenPrepravka1Value,
                lstPasPred1, lstPasZa1,
                lblDetektor1Value, lstRadDetektor1,
                lblZber1Value, lstRadZber1,
                _sim.RadPredRontgenom1, _sim.Rontgen1,
                _sim.Detektor1, _sim.RadPredDetektorom1,
                _sim.ZberPrepraviek1Volny, _sim.RadPredZberomPrepraviek1, _sim);

            UpdateTerminal(
                lstQueue2, lblRontgenCestujuci2Value, lblRontgenPrepravka2Value,
                lstPasPred2, lstPasZa2,
                lblDetektor2Value, lstRadDetektor2,
                lblZber2Value, lstRadZber2,
                _sim.RadPredRontgenom2, _sim.Rontgen2,
                _sim.Detektor2, _sim.RadPredDetektorom2,
                _sim.ZberPrepraviek2Volny, _sim.RadPredZberomPrepraviek2, _sim);

            lblCasVSystemeValue.Text = _sim.CasVSystemeCollector.Average.ToString("F2");
            lblAvgRadRontgen1Value.Text = _sim.PocetVRadePredRontgenom1.WeightedAverage.ToString("F4");
            lblAvgRadRontgen2Value.Text = _sim.PocetVRadePredRontgenom2.WeightedAverage.ToString("F4");
            lblAvgRadDetektor1Value.Text = _sim.PocetVRadePredDetektorom1.WeightedAverage.ToString("F4");
            lblAvgRadDetektor2Value.Text = _sim.PocetVRadePredDetektorom2.WeightedAverage.ToString("F4");
            lblAvgRadZber1Value.Text = _sim.PocetVRadePredZberom1.WeightedAverage.ToString("F4");
            lblAvgRadZber2Value.Text = _sim.PocetVRadePredZberom2.WeightedAverage.ToString("F4");
            lblAvgRadRontgenSpoluValue.Text = _sim.PocetVRadePredRontgenomSpolu.WeightedAverage.ToString("F4");
            lblAvgRadDetektorSpoluValue.Text = _sim.PocetVRadePredDetektoromSpolu.WeightedAverage.ToString("F4");
            lblAvgRadZberSpoluValue.Text = _sim.PocetVRadePredZberomSpolu.WeightedAverage.ToString("F4");
            lblAvgCasVRadeValue.Text = _sim.CasVRadePredRontgenomCollector.Average.ToString("F2");
            lblAvgPasPred1Value.Text = _sim.PocetVPasPredRontgenom1.WeightedAverage.ToString("F4");
            lblAvgPasPred2Value.Text = _sim.PocetVPasPredRontgenom2.WeightedAverage.ToString("F4");
            lblAvgPasZa1Value.Text = _sim.PocetVPasZaRontgenom1.WeightedAverage.ToString("F4");
            lblAvgPasZa2Value.Text = _sim.PocetVPasZaRontgenom2.WeightedAverage.ToString("F4");
            lblAvgPasPredSpoluValue.Text = _sim.PocetVPasPredRontgenomSpolu.WeightedAverage.ToString("F4");
            lblAvgPasZaSpoluValue.Text = _sim.PocetVPasZaRontgenomSpolu.WeightedAverage.ToString("F4");

            if (!chkMaxSpeed.Checked)
                foreach (var f in _replicationForms) f.Update(_sim);

            UpdateGlobalStats();
        }

        // 2.1.10 Globálne štatistiky
        private void UpdateGlobalStats()
        {
            if (_sim == null) return;
            int rep = _sim.GlobalAvgCasVSysteme.ValueCounter;
            lblReplikacieValue.Text = rep.ToString();
            lblGlobalCasVSystemeValue.Text = rep > 0 ? _sim.GlobalAvgCasVSysteme.Average.ToString("F2") : "—";
            lblGlobalAvgRadRontgen1Value.Text = rep > 0 ? _sim.GlobalAvgRadPredRontgenom1.Average.ToString("F4") : "—";
            lblGlobalAvgRadRontgen2Value.Text = rep > 0 ? _sim.GlobalAvgRadPredRontgenom2.Average.ToString("F4") : "—";
            lblGlobalAvgRadDetektor1Value.Text = rep > 0 ? _sim.GlobalAvgRadPredDetektorom1.Average.ToString("F4") : "—";
            lblGlobalAvgRadDetektor2Value.Text = rep > 0 ? _sim.GlobalAvgRadPredDetektorom2.Average.ToString("F4") : "—";
            lblGlobalAvgRadZber1Value.Text = rep > 0 ? _sim.GlobalAvgRadPredZberom1.Average.ToString("F4") : "—";
            lblGlobalAvgRadZber2Value.Text = rep > 0 ? _sim.GlobalAvgRadPredZberom2.Average.ToString("F4") : "—";
            lblGlobalAvgRadRontgenSpoluValue.Text = rep > 0 ? _sim.GlobalAvgRadPredRontgenomSpolu.Average.ToString("F4") : "—";
            lblGlobalAvgRadDetektorSpoluValue.Text = rep > 0 ? _sim.GlobalAvgRadPredDetektoromSpolu.Average.ToString("F4") : "—";
            lblGlobalAvgRadZberSpoluValue.Text = rep > 0 ? _sim.GlobalAvgRadPredZberomSpolu.Average.ToString("F4") : "—";
            lblGlobalAvgCasVRadeValue.Text = rep > 0 ? _sim.GlobalAvgCasVRadePredRontgenom.Average.ToString("F2") : "—";
            lblGlobalAvgCasPasPredValue.Text = rep > 0 ? _sim.GlobalAvgCasVPasPredRontgenom.Average.ToString("F2") : "—";
            lblGlobalAvgCasPasZaValue.Text = rep > 0 ? _sim.GlobalAvgCasVPasZaRontgenom.Average.ToString("F2") : "—";
            lblGlobalAvgCasVRadeDetektorValue.Text = rep > 0 ? _sim.GlobalAvgCasVRadePredDetektorom.Average.ToString("F2") : "—";
            lblGlobalAvgCasVRadeZberomValue.Text = rep > 0 ? _sim.GlobalAvgCasVRadePredZberom.Average.ToString("F2") : "—";
            lblGlobalAvgPasPred1Value.Text = rep > 0 ? _sim.GlobalAvgPasPredRontgenom1.Average.ToString("F4") : "—";
            lblGlobalAvgPasPred2Value.Text = rep > 0 ? _sim.GlobalAvgPasPredRontgenom2.Average.ToString("F4") : "—";
            lblGlobalAvgPasZa1Value.Text = rep > 0 ? _sim.GlobalAvgPasZaRontgenom1.Average.ToString("F4") : "—";
            lblGlobalAvgPasZa2Value.Text = rep > 0 ? _sim.GlobalAvgPasZaRontgenom2.Average.ToString("F4") : "—";
            lblGlobalAvgPasPredSpoluValue.Text = rep > 0 ? _sim.GlobalAvgPasPredRontgenomSpolu.Average.ToString("F4") : "—";
            lblGlobalAvgPasZaSpoluValue.Text = rep > 0 ? _sim.GlobalAvgPasZaRontgenomSpolu.Average.ToString("F4") : "—";

            foreach (var f in _simulationForms) f.Update(_sim);
        }

        // 2.1.9 Live zobrazenie — aktualizácia jedného terminálu
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

            FillListBox(lstPasPred, SafeToArray(rontgen.PrepravkyPredRontgenom, sim),
                p => $"ID {p.ID}  (ces. {p.ID_Cestujuci})");
            FillListBox(lstPasZa, SafeToArray(rontgen.PrepravkyZaRontgenom, sim),
                p => $"ID {p.ID}  (ces. {p.ID_Cestujuci})");

            lblDetektorValue.Text = detektor.JeVolny ? "Voľný" : "Zaneprázdnený";
            lblDetektorValue.ForeColor = detektor.JeVolny ? Color.Green : Color.Red;
            FillListBox(lstRadDetektor, SafeToArray(radDetektor, sim), c => $"ID {c.ID}");

            lblZberValue.Text = zberVolny ? "Voľný" : "Zaneprázdnený";
            lblZberValue.ForeColor = zberVolny ? Color.Green : Color.Red;
            FillListBox(lstRadZber, SafeToArray(radZber, sim), c => $"ID {c.ID}");
        }

        // 2.1.9 Live zobrazenie — pomocná metóda pre naplnenie ListBoxu
        private static void FillListBox<T>(ListBox lb, T[] items, Func<T, string> format)
        {
            lb.BeginUpdate();
            lb.Items.Clear();
            foreach (var item in items)
                if (item != null) lb.Items.Add(format(item));
            lb.EndUpdate();
        }

        // 2.1.9 Live zobrazenie — thread-safe čítanie fronty
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