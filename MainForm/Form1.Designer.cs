namespace MainForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnStart = new Button();
            btnPause = new Button();
            btnStop = new Button();

            grpSpeed = new GroupBox();
            chkMaxSpeed = new CheckBox();
            lblSleepTitle = new Label();
            sldSleep = new TrackBar();
            lblSleepValue = new Label();
            lblStepTitle = new Label();
            sldStep = new TrackBar();
            lblStepValue = new Label();

            lblTerminal1Header = new Label();
            lblQueue1Title = new Label();
            lblQueue1Value = new Label();
            lblTerminal2Header = new Label();
            lblQueue2Title = new Label();
            lblQueue2Value = new Label();

            grpSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sldSleep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sldStep).BeginInit();
            SuspendLayout();

            // btnStart
            btnStart.Location = new System.Drawing.Point(15, 15);
            btnStart.Size = new System.Drawing.Size(90, 32);
            btnStart.Text = "Start";
            btnStart.Click += btnStart_Click;

            // btnPause
            btnPause.Location = new System.Drawing.Point(115, 15);
            btnPause.Size = new System.Drawing.Size(90, 32);
            btnPause.Text = "Pause";
            btnPause.Enabled = false;
            btnPause.Click += btnPause_Click;

            // btnStop
            btnStop.Location = new System.Drawing.Point(215, 15);
            btnStop.Size = new System.Drawing.Size(90, 32);
            btnStop.Text = "Stop";
            btnStop.Enabled = false;
            btnStop.Click += btnStop_Click;

            // grpSpeed
            grpSpeed.Location = new System.Drawing.Point(15, 60);
            grpSpeed.Size = new System.Drawing.Size(490, 140);
            grpSpeed.Text = "Rýchlosť simulácie";
            grpSpeed.Controls.Add(chkMaxSpeed);
            grpSpeed.Controls.Add(lblSleepTitle);
            grpSpeed.Controls.Add(sldSleep);
            grpSpeed.Controls.Add(lblSleepValue);
            grpSpeed.Controls.Add(lblStepTitle);
            grpSpeed.Controls.Add(sldStep);
            grpSpeed.Controls.Add(lblStepValue);

            // chkMaxSpeed
            chkMaxSpeed.Location = new System.Drawing.Point(12, 22);
            chkMaxSpeed.Size = new System.Drawing.Size(120, 22);
            chkMaxSpeed.Text = "Max rýchlosť";
            chkMaxSpeed.Checked = true;
            chkMaxSpeed.CheckedChanged += chkMaxSpeed_CheckedChanged;

            // lblSleepTitle
            lblSleepTitle.Location = new System.Drawing.Point(12, 55);
            lblSleepTitle.Size = new System.Drawing.Size(130, 20);
            lblSleepTitle.Text = "Trvanie pauzy (ms):";

            // sldSleep
            sldSleep.Location = new System.Drawing.Point(150, 50);
            sldSleep.Size = new System.Drawing.Size(270, 30);
            sldSleep.Minimum = 10;
            sldSleep.Maximum = 2000;
            sldSleep.Value = 200;
            sldSleep.TickFrequency = 100;
            sldSleep.Enabled = false;
            sldSleep.Scroll += sldSleep_Scroll;

            // lblSleepValue
            lblSleepValue.Location = new System.Drawing.Point(428, 55);
            lblSleepValue.Size = new System.Drawing.Size(55, 20);
            lblSleepValue.Text = "200 ms";

            // lblStepTitle
            lblStepTitle.Location = new System.Drawing.Point(12, 100);
            lblStepTitle.Size = new System.Drawing.Size(130, 20);
            lblStepTitle.Text = "Krok simulácie:";

            // sldStep
            sldStep.Location = new System.Drawing.Point(150, 95);
            sldStep.Size = new System.Drawing.Size(270, 30);
            sldStep.Minimum = 1;
            sldStep.Maximum = 500;
            sldStep.Value = 5;
            sldStep.TickFrequency = 25;
            sldStep.Enabled = false;
            sldStep.Scroll += sldStep_Scroll;

            // lblStepValue
            lblStepValue.Location = new System.Drawing.Point(428, 100);
            lblStepValue.Size = new System.Drawing.Size(55, 20);
            lblStepValue.Text = "5";

            // lblTerminal1Header
            lblTerminal1Header.Location = new System.Drawing.Point(15, 220);
            lblTerminal1Header.Size = new System.Drawing.Size(490, 22);
            lblTerminal1Header.Text = "Terminál 1";
            lblTerminal1Header.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // lblQueue1Title
            lblQueue1Title.Location = new System.Drawing.Point(15, 247);
            lblQueue1Title.Size = new System.Drawing.Size(250, 22);
            lblQueue1Title.Text = "Rad pred Rontgenom:";
            lblQueue1Title.Font = new System.Drawing.Font("Segoe UI", 10);

            // lblQueue1Value
            lblQueue1Value.Location = new System.Drawing.Point(270, 247);
            lblQueue1Value.Size = new System.Drawing.Size(80, 22);
            lblQueue1Value.Text = "0";
            lblQueue1Value.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblQueue1Value.ForeColor = System.Drawing.Color.DarkBlue;

            // lblTerminal2Header
            lblTerminal2Header.Location = new System.Drawing.Point(15, 282);
            lblTerminal2Header.Size = new System.Drawing.Size(490, 22);
            lblTerminal2Header.Text = "Terminál 2";
            lblTerminal2Header.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // lblQueue2Title
            lblQueue2Title.Location = new System.Drawing.Point(15, 309);
            lblQueue2Title.Size = new System.Drawing.Size(250, 22);
            lblQueue2Title.Text = "Rad pred Rontgenom:";
            lblQueue2Title.Font = new System.Drawing.Font("Segoe UI", 10);

            // lblQueue2Value
            lblQueue2Value.Location = new System.Drawing.Point(270, 309);
            lblQueue2Value.Size = new System.Drawing.Size(80, 22);
            lblQueue2Value.Text = "0";
            lblQueue2Value.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblQueue2Value.ForeColor = System.Drawing.Color.DarkBlue;

            // Form1
            ClientSize = new System.Drawing.Size(520, 350);
            Text = "Letisko Simulácia";
            Controls.Add(btnStart);
            Controls.Add(btnPause);
            Controls.Add(btnStop);
            Controls.Add(grpSpeed);
            Controls.Add(lblTerminal1Header);
            Controls.Add(lblQueue1Title);
            Controls.Add(lblQueue1Value);
            Controls.Add(lblTerminal2Header);
            Controls.Add(lblQueue2Title);
            Controls.Add(lblQueue2Value);

            grpSpeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sldSleep).EndInit();
            ((System.ComponentModel.ISupportInitialize)sldStep).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnPause;
        private Button btnStop;
        private GroupBox grpSpeed;
        private CheckBox chkMaxSpeed;
        private Label lblSleepTitle;
        private TrackBar sldSleep;
        private Label lblSleepValue;
        private Label lblStepTitle;
        private TrackBar sldStep;
        private Label lblStepValue;
        private Label lblTerminal1Header;
        private Label lblQueue1Title;
        private Label lblQueue1Value;
        private Label lblTerminal2Header;
        private Label lblQueue2Title;
        private Label lblQueue2Value;
    }
}
