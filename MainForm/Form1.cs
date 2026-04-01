using DIS_Semestralka_S2_Letisko.Letisko;
using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;

namespace MainForm
{
    public partial class Form1 : Form, ISimDelegate
    {
        private LetiskoSimulation? _sim;
        private readonly System.Windows.Forms.Timer _refreshTimer = new();

        public Form1()
        {
            InitializeComponent();
            _refreshTimer.Interval = 200;
            _refreshTimer.Tick += (s, e) => UpdateLabels();
        }

        // ── Simulation control ────────────────────────────────────────────

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_sim != null)
            {
                _sim.Pause = false;
                _sim.Run = false;
            }

            _sim = new LetiskoSimulation();
            _sim.RegisterDelegate(this);
            ApplySpeedSettings();

            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            _refreshTimer.Start();

            Task.Run(() => _sim.RunSimulation(1))
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

        // ── ISimDelegate ──────────────────────────────────────────────────

        public void Refresh(Event_Core simulation)
        {
            if (InvokeRequired)
                BeginInvoke(UpdateLabels);
            else
                UpdateLabels();
        }

        // ── Label update ──────────────────────────────────────────────────

        private void UpdateLabels()
        {
            if (_sim == null) return;

            double t = _sim.CurrentTime;
            lblSimTimeValue.Text = $"{(int)(t / 3600):D2}:{(int)(t / 60) % 60:D2}:{(int)(t % 60):D2}";
            lblPocetValue.Text = _sim.PocetCestujucich.ToString();

            UpdateTerminal(
                lstQueue1, lblRontgenCestujuci1Value, lblRontgenPrepravka1Value, lstPasPred1, lstPasZa1,
                _sim.RadPredRontgenom1, _sim.Rontgen1);

            UpdateTerminal(
                lstQueue2, lblRontgenCestujuci2Value, lblRontgenPrepravka2Value, lstPasPred2, lstPasZa2,
                _sim.RadPredRontgenom2, _sim.Rontgen2);
        }

        private static void UpdateTerminal(
            ListBox lstQueue,
            Label lblRontgenCestujuciValue,
            Label lblRontgenPrepravkaValue,
            ListBox lstPasPred,
            ListBox lstPasZa,
            Queue<Cestujuci> rad,
            Rontgen rontgen)
        {
            FillListBox(lstQueue, SafeToArray(rad), c => $"ID {c.ID}");

            lblRontgenCestujuciValue.Text = rontgen.JeVolnyCestujuci ? "Voľný" : "Zaneprázdnený";
            lblRontgenCestujuciValue.ForeColor = rontgen.JeVolnyCestujuci ? Color.Green : Color.Red;

            lblRontgenPrepravkaValue.Text = rontgen.JeVolnyPrepravka ? "Voľný" : "Zaneprázdnený";
            lblRontgenPrepravkaValue.ForeColor = rontgen.JeVolnyPrepravka ? Color.Green : Color.Red;

            FillListBox(lstPasPred, SafeToArray(rontgen.PrepravkyPredRontgenom), p => $"ID {p.ID}  (ces. {p.ID_Cestujuci})");
            FillListBox(lstPasZa,   SafeToArray(rontgen.PrepravkyZaRontgenom),   p => $"ID {p.ID}  (ces. {p.ID_Cestujuci})");
        }

        private static void FillListBox<T>(ListBox lb, T[] items, Func<T, string> format)
        {
            lb.BeginUpdate();
            lb.Items.Clear();
            foreach (var item in items)
                lb.Items.Add(format(item));
            lb.EndUpdate();
        }

        private static T[] SafeToArray<T>(Queue<T> queue)
        {
            try { return queue.ToArray(); }
            catch { return Array.Empty<T>(); }
        }
    }
}
