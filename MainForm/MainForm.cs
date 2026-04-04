using DIS_Semestralka_S2_Letisko.Letisko;
using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;

namespace MainForm
{
    public partial class MainForm : Form, ISimDelegate
    {
        private LetiskoSimulation? _sim;
        private readonly System.Windows.Forms.Timer _refreshTimer = new();
        private ReplicationForm? _replicationForm;
        private SimulationForm?  _simulationForm;

        public MainForm()
        {
            InitializeComponent();
            _refreshTimer.Interval = 200;
            _refreshTimer.Tick += (s, e) => UpdateLabels();
        }

        // ── Simulation control ────────────────────────────────────────────

        private void btnReplicationStats_Click(object sender, EventArgs e)
        {
            if (_replicationForm == null || _replicationForm.IsDisposed)
                _replicationForm = new ReplicationForm();
            _replicationForm.Show();
            _replicationForm.BringToFront();
        }

        private void btnSimulationStats_Click(object sender, EventArgs e)
        {
            if (_simulationForm == null || _simulationForm.IsDisposed)
                _simulationForm = new SimulationForm();
            _simulationForm.Show();
            _simulationForm.BringToFront();
        }

        private void numCestujucich_ValueChanged(object sender, EventArgs e)
        {
            double lambda = (double)numCestujucich.Value / 86400.0;
            lblLambdaValue.Text = $"{lambda:F6} /s";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_sim != null)
            {
                _sim.Pause = false;
                _sim.Run = false;
            }

            double lambda = (double)numCestujucich.Value / 86400.0;
            int replikacii = chkMaxSpeed.Checked ? (int)numReplikacii.Value : 1;

            _sim = new LetiskoSimulation(lambda);
            _sim.RegisterDelegate(this);
            ApplySpeedSettings();
            _simulationForm?.Reset();

            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            if (!chkMaxSpeed.Checked)
                _refreshTimer.Start();

            Task.Run(() => _sim.RunSimulation(replikacii))
                .ContinueWith(_ => BeginInvoke(OnSimulationFinished));
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_sim == null) return;
            _sim.Pause = !_sim.Pause;
            btnPause.Text = _sim.Pause ? "Resume" : "Pause";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_sim == null) return;
            _sim.Pause = false;
            _sim.Run = false;
        }

        private void OnSimulationFinished()
        {
            _refreshTimer.Stop();
            UpdateLabels();
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnPause.Text = "Pause";
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
                BeginInvoke(() => RefreshInternal());
            else
                RefreshInternal();
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

            double t = _sim.CurrentTime;
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
                _replicationForm?.Update(_sim);

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

            _simulationForm?.Update(_sim);
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
