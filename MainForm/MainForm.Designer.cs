namespace MainForm
{
    partial class MainForm
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
            // ── Buttons ──────────────────────────────────────────────────────
            btnStart            = new Button();
            btnPause            = new Button();
            btnStop             = new Button();
            btnReplicationStats = new Button();
            btnSimulationStats  = new Button();
            chkDependency       = new CheckBox();
            lblTestPointsTitle  = new Label();
            numTestPoints       = new NumericUpDown();
            btnDependency       = new Button();
            chkSaveCsv             = new CheckBox();
            chkCollectByInterval   = new CheckBox();
            numCollectInterval     = new NumericUpDown();
            chkWarmup           = new CheckBox();
            lblWarmupTimeTitle  = new Label();
            numWarmupTime       = new NumericUpDown();

            // ── Speed group ───────────────────────────────────────────────────
            grpSpeed      = new GroupBox();
            chkMaxSpeed   = new CheckBox();
            lblSleepTitle = new Label();
            sldSleep      = new TrackBar();
            lblSleepValue = new Label();
            lblStepTitle  = new Label();
            sldStep       = new TrackBar();
            lblStepValue  = new Label();

            // ── Global info ───────────────────────────────────────────────────
            lblSimTimeTitle = new Label();
            lblSimTimeValue = new Label();
            lblPocetTitle   = new Label();
            lblPocetValue   = new Label();

            // ── Terminal 1 ────────────────────────────────────────────────────
            grpTerminal1                = new GroupBox();
            lblRontgenCestujuci1Title   = new Label();
            lblRontgenCestujuci1Value   = new Label();
            lblRontgenPrepravka1Title   = new Label();
            lblRontgenPrepravka1Value   = new Label();
            lblQueue1Title              = new Label();
            lstQueue1                   = new ListBox();
            lblPasPred1Title            = new Label();
            lstPasPred1                 = new ListBox();
            lblPasZa1Title              = new Label();
            lstPasZa1                   = new ListBox();
            lblDetektor1Title           = new Label();
            lblDetektor1Value           = new Label();
            lblRadDetektor1Title        = new Label();
            lstRadDetektor1             = new ListBox();
            lblZber1Title               = new Label();
            lblZber1Value               = new Label();
            lblRadZber1Title            = new Label();
            lstRadZber1                 = new ListBox();

            // ── Statistics ───────────────────────────────────────────────────
            grpStats                       = new GroupBox();
            lblSecRontgen                  = new Label();
            lblSecDetektor                 = new Label();
            lblSecZber                     = new Label();
            lblCasVSystemeTitle            = new Label(); lblCasVSystemeValue            = new Label();
            lblAvgCasVRadeTitle            = new Label(); lblAvgCasVRadeValue            = new Label();
            lblAvgRadRontgen1Title         = new Label(); lblAvgRadRontgen1Value         = new Label();
            lblAvgRadRontgen2Title         = new Label(); lblAvgRadRontgen2Value         = new Label();
            lblAvgRadRontgenSpoluTitle     = new Label(); lblAvgRadRontgenSpoluValue     = new Label();
            lblAvgCasPasPredTitle          = new Label(); lblAvgCasPasPredValue          = new Label();
            lblAvgCasPasZaTitle            = new Label(); lblAvgCasPasZaValue            = new Label();
            lblAvgPasPred1Title            = new Label(); lblAvgPasPred1Value            = new Label();
            lblAvgPasPred2Title            = new Label(); lblAvgPasPred2Value            = new Label();
            lblAvgPasPredSpoluTitle        = new Label(); lblAvgPasPredSpoluValue        = new Label();
            lblAvgPasZa1Title              = new Label(); lblAvgPasZa1Value              = new Label();
            lblAvgPasZa2Title              = new Label(); lblAvgPasZa2Value              = new Label();
            lblAvgPasZaSpoluTitle          = new Label(); lblAvgPasZaSpoluValue          = new Label();
            lblAvgCasVRadeDetektorTitle    = new Label(); lblAvgCasVRadeDetektorValue    = new Label();
            lblAvgRadDetektor1Title        = new Label(); lblAvgRadDetektor1Value        = new Label();
            lblAvgRadDetektor2Title        = new Label(); lblAvgRadDetektor2Value        = new Label();
            lblAvgRadDetektorSpoluTitle    = new Label(); lblAvgRadDetektorSpoluValue    = new Label();
            lblAvgCasVRadeZberomTitle      = new Label(); lblAvgCasVRadeZberomValue      = new Label();
            lblAvgRadZber1Title            = new Label(); lblAvgRadZber1Value            = new Label();
            lblAvgRadZber2Title            = new Label(); lblAvgRadZber2Value            = new Label();
            lblAvgRadZberSpoluTitle        = new Label(); lblAvgRadZberSpoluValue        = new Label();

            // ── Global statistics ─────────────────────────────────────────────
            grpGlobalStats                        = new GroupBox();
            lblGlobalSecRontgen                   = new Label();
            lblGlobalSecDetektor                  = new Label();
            lblGlobalSecZber                      = new Label();
            lblReplikacieTitle                    = new Label(); lblReplikacieValue                    = new Label();
            lblGlobalCasVSystemeTitle             = new Label(); lblGlobalCasVSystemeValue             = new Label();
            lblGlobalAvgCasVRadeTitle             = new Label(); lblGlobalAvgCasVRadeValue             = new Label();
            lblGlobalAvgRadRontgen1Title          = new Label(); lblGlobalAvgRadRontgen1Value          = new Label();
            lblGlobalAvgRadRontgen2Title          = new Label(); lblGlobalAvgRadRontgen2Value          = new Label();
            lblGlobalAvgRadRontgenSpoluTitle      = new Label(); lblGlobalAvgRadRontgenSpoluValue      = new Label();
            lblGlobalAvgCasPasPredTitle           = new Label(); lblGlobalAvgCasPasPredValue           = new Label();
            lblGlobalAvgCasPasZaTitle             = new Label(); lblGlobalAvgCasPasZaValue             = new Label();
            lblGlobalAvgPasPred1Title             = new Label(); lblGlobalAvgPasPred1Value             = new Label();
            lblGlobalAvgPasPred2Title             = new Label(); lblGlobalAvgPasPred2Value             = new Label();
            lblGlobalAvgPasPredSpoluTitle         = new Label(); lblGlobalAvgPasPredSpoluValue         = new Label();
            lblGlobalAvgPasZa1Title               = new Label(); lblGlobalAvgPasZa1Value               = new Label();
            lblGlobalAvgPasZa2Title               = new Label(); lblGlobalAvgPasZa2Value               = new Label();
            lblGlobalAvgPasZaSpoluTitle           = new Label(); lblGlobalAvgPasZaSpoluValue           = new Label();
            lblGlobalAvgCasVRadeDetektorTitle     = new Label(); lblGlobalAvgCasVRadeDetektorValue     = new Label();
            lblGlobalAvgRadDetektor1Title         = new Label(); lblGlobalAvgRadDetektor1Value         = new Label();
            lblGlobalAvgRadDetektor2Title         = new Label(); lblGlobalAvgRadDetektor2Value         = new Label();
            lblGlobalAvgRadDetektorSpoluTitle     = new Label(); lblGlobalAvgRadDetektorSpoluValue     = new Label();
            lblGlobalAvgCasVRadeZberomTitle       = new Label(); lblGlobalAvgCasVRadeZberomValue       = new Label();
            lblGlobalAvgRadZber1Title             = new Label(); lblGlobalAvgRadZber1Value             = new Label();
            lblGlobalAvgRadZber2Title             = new Label(); lblGlobalAvgRadZber2Value             = new Label();
            lblGlobalAvgRadZberSpoluTitle         = new Label(); lblGlobalAvgRadZberSpoluValue         = new Label();

            // ── Parameters group ─────────────────────────────────────────────
            grpParams              = new GroupBox();
            lblReplikaciiTitle     = new Label();
            numReplikacii          = new NumericUpDown();
            chkProgressiveLambda   = new CheckBox();
            lblCestujucichTitle    = new Label();
            numCestujucich         = new NumericUpDown();
            lblLambdaTitle         = new Label();
            lblLambdaValue         = new Label();
            lblOdTitle             = new Label();
            numCestujucichOd       = new NumericUpDown();
            lblDoTitle             = new Label();
            numCestujucichDo       = new NumericUpDown();

            // ── Röntgen belt size ─────────────────────────────────────────────
            lblMaxPasPredTitle = new Label();
            numMaxPasPred      = new NumericUpDown();
            lblMaxPasZaTitle   = new Label();
            numMaxPasZa        = new NumericUpDown();

            // ── Simulation duration ───────────────────────────────────────────
            lblSimDurationTitle = new Label();
            numSimDuration      = new NumericUpDown();
            cmbSimDurationUnit  = new ComboBox();

            // ── Seed ─────────────────────────────────────────────────────────
            chkFixedSeed = new CheckBox();
            lblSeedTitle = new Label();
            numSeed      = new NumericUpDown();

            // ── Terminal 2 ────────────────────────────────────────────────────
            grpTerminal2                = new GroupBox();
            lblRontgenCestujuci2Title   = new Label();
            lblRontgenCestujuci2Value   = new Label();
            lblRontgenPrepravka2Title   = new Label();
            lblRontgenPrepravka2Value   = new Label();
            lblQueue2Title              = new Label();
            lstQueue2                   = new ListBox();
            lblPasPred2Title            = new Label();
            lstPasPred2                 = new ListBox();
            lblPasZa2Title              = new Label();
            lstPasZa2                   = new ListBox();
            lblDetektor2Title           = new Label();
            lblDetektor2Value           = new Label();
            lblRadDetektor2Title        = new Label();
            lstRadDetektor2             = new ListBox();
            lblZber2Title               = new Label();
            lblZber2Value               = new Label();
            lblRadZber2Title            = new Label();
            lstRadZber2                 = new ListBox();

            grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numReplikacii).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucich).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTestPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucichOd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucichDo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPasPred).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPasZa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSimDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeed).BeginInit();
            grpSpeed.SuspendLayout();
            grpTerminal1.SuspendLayout();
            grpTerminal2.SuspendLayout();
            grpGlobalStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sldSleep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sldStep).BeginInit();
            SuspendLayout();

            // ── btnStart ──────────────────────────────────────────────────────
            btnStart.Location = new Point(15, 15);
            btnStart.Size     = new Size(90, 32);
            btnStart.Text     = "Start";
            btnStart.Click   += btnStart_Click;

            // ── btnPause ──────────────────────────────────────────────────────
            btnPause.Location = new Point(115, 15);
            btnPause.Size     = new Size(90, 32);
            btnPause.Text     = "Pause";
            btnPause.Enabled  = false;
            btnPause.Click   += btnPause_Click;

            // ── btnStop ───────────────────────────────────────────────────────
            btnStop.Location = new Point(215, 15);
            btnStop.Size     = new Size(90, 32);
            btnStop.Text     = "Stop";
            btnStop.Enabled  = false;
            btnStop.Click   += btnStop_Click;

            btnReplicationStats.Location = new Point(325, 15);
            btnReplicationStats.Size     = new Size(130, 32);
            btnReplicationStats.Text     = "Replikácia...";
            btnReplicationStats.Click   += btnReplicationStats_Click;

            btnSimulationStats.Location = new Point(465, 15);
            btnSimulationStats.Size     = new Size(130, 32);
            btnSimulationStats.Text     = "Simulácia...";
            btnSimulationStats.Click   += btnSimulationStats_Click;

            chkDependency.Location       = new Point(615, 20);
            chkDependency.Size           = new Size(115, 22);
            chkDependency.Text           = "Závislosť";
            chkDependency.CheckedChanged += chkDependency_CheckedChanged;

            lblTestPointsTitle.Location = new Point(738, 21);
            lblTestPointsTitle.Size     = new Size(48, 18);
            lblTestPointsTitle.Text     = "Body:";
            lblTestPointsTitle.Visible  = false;

            numTestPoints.Location = new Point(786, 15);
            numTestPoints.Size     = new Size(58, 26);
            numTestPoints.Minimum  = 1;
            numTestPoints.Maximum  = 99;
            numTestPoints.Value    = 5;
            numTestPoints.Visible  = false;

            btnDependency.Location = new Point(856, 15);
            btnDependency.Size     = new Size(160, 32);
            btnDependency.Text     = "Spustiť závislosť";
            btnDependency.Visible  = false;
            btnDependency.Click   += btnDependency_Click;

            // chkSaveCsv
            chkSaveCsv.Location = new Point(640, 70);
            chkSaveCsv.Size     = new Size(220, 22);
            chkSaveCsv.Text     = "Uložiť výsledky do CSV";

            // chkCollectByInterval
            chkCollectByInterval.Location        = new Point(640, 122);
            chkCollectByInterval.Size            = new Size(160, 22);
            chkCollectByInterval.Text            = "Zber po intervaloch";
            chkCollectByInterval.CheckedChanged += chkCollectByInterval_CheckedChanged;

            // numCollectInterval
            ((System.ComponentModel.ISupportInitialize)numCollectInterval).BeginInit();
            numCollectInterval.Location  = new Point(810, 120);
            numCollectInterval.Size      = new Size(90, 26);
            numCollectInterval.Minimum   = 60;
            numCollectInterval.Maximum   = 86400;
            numCollectInterval.Value     = 3600;
            numCollectInterval.Visible   = false;
            ((System.ComponentModel.ISupportInitialize)numCollectInterval).EndInit();

            // chkWarmup
            chkWarmup.Location       = new Point(640, 95);
            chkWarmup.Size           = new Size(150, 22);
            chkWarmup.Text           = "Zahriatie (warmup)";
            chkWarmup.CheckedChanged += chkWarmup_CheckedChanged;

            // chkFixedSeed
            chkFixedSeed.Location       = new Point(640, 148);
            chkFixedSeed.Size           = new Size(130, 22);
            chkFixedSeed.Text           = "Pevný seed";
            chkFixedSeed.CheckedChanged += chkFixedSeed_CheckedChanged;

            // lblSeedTitle
            lblSeedTitle.Location = new Point(775, 149);
            lblSeedTitle.Size     = new Size(42, 20);
            lblSeedTitle.Text     = "Seed:";
            lblSeedTitle.Visible  = false;

            // numSeed
            numSeed.Location  = new Point(817, 146);
            numSeed.Size      = new Size(100, 26);
            numSeed.Minimum   = 0;
            numSeed.Maximum   = int.MaxValue;
            numSeed.Value     = 42;
            numSeed.Visible   = false;

            // lblWarmupTimeTitle
            lblWarmupTimeTitle.Location = new Point(795, 96);
            lblWarmupTimeTitle.Size     = new Size(30, 20);
            lblWarmupTimeTitle.Text     = "t =";
            lblWarmupTimeTitle.Visible  = false;

            // numWarmupTime
            ((System.ComponentModel.ISupportInitialize)numWarmupTime).BeginInit();
            numWarmupTime.Location  = new Point(825, 93);
            numWarmupTime.Size      = new Size(90, 26);
            numWarmupTime.Minimum   = 0;
            numWarmupTime.Maximum   = 86400;
            numWarmupTime.Value     = 3600;
            numWarmupTime.Visible   = false;
            ((System.ComponentModel.ISupportInitialize)numWarmupTime).EndInit();

            // ── grpSpeed ──────────────────────────────────────────────────────
            grpSpeed.Location = new Point(15, 220);
            grpSpeed.Size     = new Size(600, 140);
            grpSpeed.Text     = "Rýchlosť simulácie";
            grpSpeed.Controls.Add(chkMaxSpeed);
            grpSpeed.Controls.Add(lblSleepTitle);
            grpSpeed.Controls.Add(sldSleep);
            grpSpeed.Controls.Add(lblSleepValue);
            grpSpeed.Controls.Add(lblStepTitle);
            grpSpeed.Controls.Add(sldStep);
            grpSpeed.Controls.Add(lblStepValue);

            // chkMaxSpeed
            chkMaxSpeed.Location       = new Point(12, 22);
            chkMaxSpeed.Size           = new Size(120, 22);
            chkMaxSpeed.Text           = "Max rýchlosť";
            chkMaxSpeed.Checked        = true;
            chkMaxSpeed.CheckedChanged += chkMaxSpeed_CheckedChanged;

            // lblSleepTitle
            lblSleepTitle.Location = new Point(12, 55);
            lblSleepTitle.Size     = new Size(130, 20);
            lblSleepTitle.Text     = "Trvanie pauzy (ms):";

            // sldSleep
            sldSleep.Location      = new Point(150, 50);
            sldSleep.Size          = new Size(380, 30);
            sldSleep.Minimum       = 10;
            sldSleep.Maximum       = 2000;
            sldSleep.Value         = 200;
            sldSleep.TickFrequency = 100;
            sldSleep.Enabled       = false;
            sldSleep.Scroll       += sldSleep_Scroll;

            // lblSleepValue
            lblSleepValue.Location = new Point(538, 55);
            lblSleepValue.Size     = new Size(55, 20);
            lblSleepValue.Text     = "200 ms";

            // lblStepTitle
            lblStepTitle.Location = new Point(12, 100);
            lblStepTitle.Size     = new Size(130, 20);
            lblStepTitle.Text     = "Krok simulácie:";

            // sldStep
            sldStep.Location      = new Point(150, 95);
            sldStep.Size          = new Size(380, 30);
            sldStep.Minimum       = 1;
            sldStep.Maximum       = 500;
            sldStep.Value         = 5;
            sldStep.TickFrequency = 25;
            sldStep.Enabled       = false;
            sldStep.Scroll       += sldStep_Scroll;

            // lblStepValue
            lblStepValue.Location = new Point(538, 100);
            lblStepValue.Size     = new Size(55, 20);
            lblStepValue.Text     = "5";

            // ── Global info row ───────────────────────────────────────────────
            var boldNormal = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            var plainNormal = new Font("Segoe UI", 9.5f);

            lblSimTimeTitle.Location = new Point(15, 373);
            lblSimTimeTitle.Size     = new Size(105, 22);
            lblSimTimeTitle.Text     = "Čas simulácie:";
            lblSimTimeTitle.Font     = boldNormal;

            lblSimTimeValue.Location = new Point(125, 373);
            lblSimTimeValue.Size     = new Size(120, 22);
            lblSimTimeValue.Text     = "00:00:00";
            lblSimTimeValue.Font     = plainNormal;

            lblPocetTitle.Location = new Point(285, 373);
            lblPocetTitle.Size     = new Size(165, 22);
            lblPocetTitle.Text     = "Počet cestujúcich:";
            lblPocetTitle.Font     = boldNormal;

            lblPocetValue.Location = new Point(455, 373);
            lblPocetValue.Size     = new Size(80, 22);
            lblPocetValue.Text     = "0";
            lblPocetValue.Font     = plainNormal;

            // ── Helper fonts for inner controls ───────────────────────────────
            var fTitle  = new Font("Segoe UI", 9f, FontStyle.Regular);
            var fStatus = new Font("Segoe UI", 9f, FontStyle.Bold);
            var fMono   = new Font("Consolas", 8.5f);

            // ══════════════════════════════════════════════════════════════════
            // ── Parameters GroupBox ───────────────────────────────────────────
            // ══════════════════════════════════════════════════════════════════
            grpParams.Location = new Point(15, 60);
            grpParams.Size     = new Size(600, 157);
            grpParams.Text     = "Parametre simulácie";

            lblReplikaciiTitle.Location = new Point(12, 25);
            lblReplikaciiTitle.Size     = new Size(160, 20);
            lblReplikaciiTitle.Text     = "Počet replikácií:";
            lblReplikaciiTitle.Font     = fTitle;

            numReplikacii.Location = new Point(178, 22);
            numReplikacii.Size     = new Size(120, 26);
            numReplikacii.Minimum  = 1;
            numReplikacii.Maximum  = 1000000;
            numReplikacii.Value    = 1000;

            chkProgressiveLambda.Location       = new Point(315, 25);
            chkProgressiveLambda.Size           = new Size(260, 22);
            chkProgressiveLambda.Text           = "Progresívna lambda (Od → Do → CSV)";
            chkProgressiveLambda.CheckedChanged += chkProgressiveLambda_CheckedChanged;

            lblCestujucichTitle.Location = new Point(12, 57);
            lblCestujucichTitle.Size     = new Size(160, 20);
            lblCestujucichTitle.Text     = "Cestujúci za 24h:";
            lblCestujucichTitle.Font     = fTitle;

            numCestujucich.Location      = new Point(178, 54);
            numCestujucich.Size          = new Size(120, 26);
            numCestujucich.Minimum       = 1;
            numCestujucich.Maximum       = 1000000;
            numCestujucich.Value         = 5760;
            numCestujucich.ValueChanged += numCestujucich_ValueChanged;

            lblLambdaTitle.Location = new Point(315, 57);
            lblLambdaTitle.Size     = new Size(45, 20);
            lblLambdaTitle.Text     = "λ =";
            lblLambdaTitle.Font     = fTitle;

            lblLambdaValue.Location = new Point(360, 57);
            lblLambdaValue.Size     = new Size(200, 20);
            lblLambdaValue.Text     = "0.066667 /s";
            lblLambdaValue.Font     = fStatus;

            // Od / Do — viditeľné iba v progresívnom móde
            lblOdTitle.Location = new Point(12, 57);
            lblOdTitle.Size     = new Size(110, 20);
            lblOdTitle.Text     = "Od (ces./deň):";
            lblOdTitle.Font     = fTitle;
            lblOdTitle.Visible  = false;

            numCestujucichOd.Location = new Point(128, 54);
            numCestujucichOd.Size     = new Size(95, 26);
            numCestujucichOd.Minimum  = 1;
            numCestujucichOd.Maximum  = 1000000;
            numCestujucichOd.Value    = 4000;
            numCestujucichOd.Visible  = false;

            lblDoTitle.Location = new Point(238, 57);
            lblDoTitle.Size     = new Size(30, 20);
            lblDoTitle.Text     = "Do:";
            lblDoTitle.Font     = fTitle;
            lblDoTitle.Visible  = false;

            numCestujucichDo.Location = new Point(273, 54);
            numCestujucichDo.Size     = new Size(95, 26);
            numCestujucichDo.Minimum  = 1;
            numCestujucichDo.Maximum  = 1000000;
            numCestujucichDo.Value    = 6000;
            numCestujucichDo.Visible  = false;

            // Belt size row (3rd row in grpParams)
            lblMaxPasPredTitle.Location = new Point(12, 90);
            lblMaxPasPredTitle.Size     = new Size(130, 20);
            lblMaxPasPredTitle.Text     = "Max pas pred:";
            lblMaxPasPredTitle.Font     = fTitle;

            numMaxPasPred.Location = new Point(148, 87);
            numMaxPasPred.Size     = new Size(70, 26);
            numMaxPasPred.Minimum  = 1;
            numMaxPasPred.Maximum  = 50;
            numMaxPasPred.Value    = 4;

            lblMaxPasZaTitle.Location = new Point(235, 90);
            lblMaxPasZaTitle.Size     = new Size(130, 20);
            lblMaxPasZaTitle.Text     = "Max pas za:";
            lblMaxPasZaTitle.Font     = fTitle;

            numMaxPasZa.Location = new Point(371, 87);
            numMaxPasZa.Size     = new Size(70, 26);
            numMaxPasZa.Minimum  = 1;
            numMaxPasZa.Maximum  = 50;
            numMaxPasZa.Value    = 5;

            // Belt size row (3rd row in grpParams)
            // [already positioned above at y=90]

            // Duration row (4th row in grpParams, y=125)
            lblSimDurationTitle.Location = new Point(12, 128);
            lblSimDurationTitle.Size     = new Size(130, 20);
            lblSimDurationTitle.Text     = "Trvanie sim.:";
            lblSimDurationTitle.Font     = fTitle;

            numSimDuration.Location = new Point(148, 125);
            numSimDuration.Size     = new Size(75, 26);
            numSimDuration.Minimum  = 1;
            numSimDuration.Maximum  = 99999;
            numSimDuration.Value    = 24;

            cmbSimDurationUnit.Location      = new Point(232, 124);
            cmbSimDurationUnit.Size          = new Size(90, 26);
            cmbSimDurationUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSimDurationUnit.Items.AddRange(new object[] { "minút", "hodín", "dní" });
            cmbSimDurationUnit.SelectedIndex = 1; // hodín

            grpParams.Controls.Add(lblReplikaciiTitle);
            grpParams.Controls.Add(numReplikacii);
            grpParams.Controls.Add(chkProgressiveLambda);
            grpParams.Controls.Add(lblCestujucichTitle);
            grpParams.Controls.Add(numCestujucich);
            grpParams.Controls.Add(lblLambdaTitle);
            grpParams.Controls.Add(lblLambdaValue);
            grpParams.Controls.Add(lblOdTitle);
            grpParams.Controls.Add(numCestujucichOd);
            grpParams.Controls.Add(lblDoTitle);
            grpParams.Controls.Add(numCestujucichDo);
            grpParams.Controls.Add(lblMaxPasPredTitle);
            grpParams.Controls.Add(numMaxPasPred);
            grpParams.Controls.Add(lblMaxPasZaTitle);
            grpParams.Controls.Add(numMaxPasZa);
            grpParams.Controls.Add(lblSimDurationTitle);
            grpParams.Controls.Add(numSimDuration);
            grpParams.Controls.Add(cmbSimDurationUnit);

            // ══════════════════════════════════════════════════════════════════
            // ── Terminal 1 GroupBox ───────────────────────────────────────────
            // ══════════════════════════════════════════════════════════════════
            grpTerminal1.Location = new Point(10, 403);
            grpTerminal1.Size     = new Size(520, 518);
            grpTerminal1.Text     = "Terminál 1";
            grpTerminal1.Font     = new Font("Segoe UI", 10f, FontStyle.Bold);

            // Röntgen – cestujúci
            lblRontgenCestujuci1Title.Location  = new Point(10, 26);
            lblRontgenCestujuci1Title.Size       = new Size(175, 20);
            lblRontgenCestujuci1Title.Text       = "Röntgen (ces.):";
            lblRontgenCestujuci1Title.Font       = fTitle;

            lblRontgenCestujuci1Value.Location   = new Point(190, 26);
            lblRontgenCestujuci1Value.Size        = new Size(150, 20);
            lblRontgenCestujuci1Value.Text        = "Voľný";
            lblRontgenCestujuci1Value.Font        = fStatus;
            lblRontgenCestujuci1Value.ForeColor   = Color.Green;

            // Röntgen – prepravka
            lblRontgenPrepravka1Title.Location   = new Point(10, 48);
            lblRontgenPrepravka1Title.Size        = new Size(175, 20);
            lblRontgenPrepravka1Title.Text        = "Röntgen (prep.):";
            lblRontgenPrepravka1Title.Font        = fTitle;

            lblRontgenPrepravka1Value.Location    = new Point(190, 48);
            lblRontgenPrepravka1Value.Size         = new Size(150, 20);
            lblRontgenPrepravka1Value.Text         = "Voľný";
            lblRontgenPrepravka1Value.Font         = fStatus;
            lblRontgenPrepravka1Value.ForeColor    = Color.Green;

            // Queue before röntgen
            lblQueue1Title.Location = new Point(10, 72);
            lblQueue1Title.Size     = new Size(350, 18);
            lblQueue1Title.Text     = "Rad pred röntgenom (ID cestujúci):";
            lblQueue1Title.Font     = fTitle;

            lstQueue1.Location     = new Point(10, 91);
            lstQueue1.Size         = new Size(500, 56);
            lstQueue1.Font         = fMono;

            // Luggage before röntgen
            lblPasPred1Title.Location = new Point(10, 153);
            lblPasPred1Title.Size     = new Size(300, 18);
            lblPasPred1Title.Text     = "Prepravky pred röntgenom:";
            lblPasPred1Title.Font     = fTitle;

            lstPasPred1.Location     = new Point(10, 172);
            lstPasPred1.Size         = new Size(500, 46);
            lstPasPred1.Font         = fMono;

            // Luggage after röntgen
            lblPasZa1Title.Location = new Point(10, 224);
            lblPasZa1Title.Size     = new Size(300, 18);
            lblPasZa1Title.Text     = "Prepravky za röntgenom:";
            lblPasZa1Title.Font     = fTitle;

            lstPasZa1.Location     = new Point(10, 243);
            lstPasZa1.Size         = new Size(500, 46);
            lstPasZa1.Font         = fMono;

            // Metal detector
            lblDetektor1Title.Location  = new Point(10, 297);
            lblDetektor1Title.Size      = new Size(175, 20);
            lblDetektor1Title.Text      = "Detektor kovu:";
            lblDetektor1Title.Font      = fTitle;

            lblDetektor1Value.Location  = new Point(190, 297);
            lblDetektor1Value.Size      = new Size(150, 20);
            lblDetektor1Value.Text      = "Voľný";
            lblDetektor1Value.Font      = fStatus;
            lblDetektor1Value.ForeColor = Color.Green;

            lblRadDetektor1Title.Location = new Point(10, 321);
            lblRadDetektor1Title.Size     = new Size(350, 18);
            lblRadDetektor1Title.Text     = "Rad pred detektorom (ID cestujúci):";
            lblRadDetektor1Title.Font     = fTitle;

            lstRadDetektor1.Location     = new Point(10, 340);
            lstRadDetektor1.Size         = new Size(500, 56);
            lstRadDetektor1.Font         = fMono;

            // Luggage collection
            lblZber1Title.Location  = new Point(10, 403);
            lblZber1Title.Size      = new Size(175, 20);
            lblZber1Title.Text      = "Zber prepraviek:";
            lblZber1Title.Font      = fTitle;

            lblZber1Value.Location  = new Point(190, 403);
            lblZber1Value.Size      = new Size(150, 20);
            lblZber1Value.Text      = "Voľný";
            lblZber1Value.Font      = fStatus;
            lblZber1Value.ForeColor = Color.Green;

            lblRadZber1Title.Location = new Point(10, 427);
            lblRadZber1Title.Size     = new Size(300, 18);
            lblRadZber1Title.Text     = "Rad pred zberom (ID cestujúci):";
            lblRadZber1Title.Font     = fTitle;

            lstRadZber1.Location     = new Point(10, 446);
            lstRadZber1.Size         = new Size(500, 56);
            lstRadZber1.Font         = fMono;

            grpTerminal1.Controls.Add(lblRontgenCestujuci1Title);
            grpTerminal1.Controls.Add(lblRontgenCestujuci1Value);
            grpTerminal1.Controls.Add(lblRontgenPrepravka1Title);
            grpTerminal1.Controls.Add(lblRontgenPrepravka1Value);
            grpTerminal1.Controls.Add(lblQueue1Title);
            grpTerminal1.Controls.Add(lstQueue1);
            grpTerminal1.Controls.Add(lblPasPred1Title);
            grpTerminal1.Controls.Add(lstPasPred1);
            grpTerminal1.Controls.Add(lblPasZa1Title);
            grpTerminal1.Controls.Add(lstPasZa1);
            grpTerminal1.Controls.Add(lblDetektor1Title);
            grpTerminal1.Controls.Add(lblDetektor1Value);
            grpTerminal1.Controls.Add(lblRadDetektor1Title);
            grpTerminal1.Controls.Add(lstRadDetektor1);
            grpTerminal1.Controls.Add(lblZber1Title);
            grpTerminal1.Controls.Add(lblZber1Value);
            grpTerminal1.Controls.Add(lblRadZber1Title);
            grpTerminal1.Controls.Add(lstRadZber1);

            // ══════════════════════════════════════════════════════════════════
            // ── Terminal 2 GroupBox ───────────────────────────────────────────
            // ══════════════════════════════════════════════════════════════════
            grpTerminal2.Location = new Point(540, 403);
            grpTerminal2.Size     = new Size(520, 518);
            grpTerminal2.Text     = "Terminál 2";
            grpTerminal2.Font     = new Font("Segoe UI", 10f, FontStyle.Bold);

            // Röntgen – cestujúci
            lblRontgenCestujuci2Title.Location  = new Point(10, 26);
            lblRontgenCestujuci2Title.Size       = new Size(175, 20);
            lblRontgenCestujuci2Title.Text       = "Röntgen (ces.):";
            lblRontgenCestujuci2Title.Font       = fTitle;

            lblRontgenCestujuci2Value.Location   = new Point(190, 26);
            lblRontgenCestujuci2Value.Size        = new Size(150, 20);
            lblRontgenCestujuci2Value.Text        = "Voľný";
            lblRontgenCestujuci2Value.Font        = fStatus;
            lblRontgenCestujuci2Value.ForeColor   = Color.Green;

            // Röntgen – prepravka
            lblRontgenPrepravka2Title.Location   = new Point(10, 48);
            lblRontgenPrepravka2Title.Size        = new Size(175, 20);
            lblRontgenPrepravka2Title.Text        = "Röntgen (prep.):";
            lblRontgenPrepravka2Title.Font        = fTitle;

            lblRontgenPrepravka2Value.Location    = new Point(190, 48);
            lblRontgenPrepravka2Value.Size         = new Size(150, 20);
            lblRontgenPrepravka2Value.Text         = "Voľný";
            lblRontgenPrepravka2Value.Font         = fStatus;
            lblRontgenPrepravka2Value.ForeColor    = Color.Green;

            // Queue before röntgen
            lblQueue2Title.Location = new Point(10, 72);
            lblQueue2Title.Size     = new Size(350, 18);
            lblQueue2Title.Text     = "Rad pred röntgenom (ID cestujúci):";
            lblQueue2Title.Font     = fTitle;

            lstQueue2.Location     = new Point(10, 91);
            lstQueue2.Size         = new Size(500, 56);
            lstQueue2.Font         = fMono;

            // Luggage before röntgen
            lblPasPred2Title.Location = new Point(10, 153);
            lblPasPred2Title.Size     = new Size(300, 18);
            lblPasPred2Title.Text     = "Prepravky pred röntgenom:";
            lblPasPred2Title.Font     = fTitle;

            lstPasPred2.Location     = new Point(10, 172);
            lstPasPred2.Size         = new Size(500, 46);
            lstPasPred2.Font         = fMono;

            // Luggage after röntgen
            lblPasZa2Title.Location = new Point(10, 224);
            lblPasZa2Title.Size     = new Size(300, 18);
            lblPasZa2Title.Text     = "Prepravky za röntgenom:";
            lblPasZa2Title.Font     = fTitle;

            lstPasZa2.Location     = new Point(10, 243);
            lstPasZa2.Size         = new Size(500, 46);
            lstPasZa2.Font         = fMono;

            // Metal detector
            lblDetektor2Title.Location  = new Point(10, 297);
            lblDetektor2Title.Size      = new Size(175, 20);
            lblDetektor2Title.Text      = "Detektor kovu:";
            lblDetektor2Title.Font      = fTitle;

            lblDetektor2Value.Location  = new Point(190, 297);
            lblDetektor2Value.Size      = new Size(150, 20);
            lblDetektor2Value.Text      = "Voľný";
            lblDetektor2Value.Font      = fStatus;
            lblDetektor2Value.ForeColor = Color.Green;

            lblRadDetektor2Title.Location = new Point(10, 321);
            lblRadDetektor2Title.Size     = new Size(350, 18);
            lblRadDetektor2Title.Text     = "Rad pred detektorom (ID cestujúci):";
            lblRadDetektor2Title.Font     = fTitle;

            lstRadDetektor2.Location     = new Point(10, 340);
            lstRadDetektor2.Size         = new Size(500, 56);
            lstRadDetektor2.Font         = fMono;

            // Luggage collection
            lblZber2Title.Location  = new Point(10, 403);
            lblZber2Title.Size      = new Size(175, 20);
            lblZber2Title.Text      = "Zber prepraviek:";
            lblZber2Title.Font      = fTitle;

            lblZber2Value.Location  = new Point(190, 403);
            lblZber2Value.Size      = new Size(150, 20);
            lblZber2Value.Text      = "Voľný";
            lblZber2Value.Font      = fStatus;
            lblZber2Value.ForeColor = Color.Green;

            lblRadZber2Title.Location = new Point(10, 427);
            lblRadZber2Title.Size     = new Size(300, 18);
            lblRadZber2Title.Text     = "Rad pred zberom (ID cestujúci):";
            lblRadZber2Title.Font     = fTitle;

            lstRadZber2.Location     = new Point(10, 446);
            lstRadZber2.Size         = new Size(500, 56);
            lstRadZber2.Font         = fMono;

            grpTerminal2.Controls.Add(lblRontgenCestujuci2Title);
            grpTerminal2.Controls.Add(lblRontgenCestujuci2Value);
            grpTerminal2.Controls.Add(lblRontgenPrepravka2Title);
            grpTerminal2.Controls.Add(lblRontgenPrepravka2Value);
            grpTerminal2.Controls.Add(lblQueue2Title);
            grpTerminal2.Controls.Add(lstQueue2);
            grpTerminal2.Controls.Add(lblPasPred2Title);
            grpTerminal2.Controls.Add(lstPasPred2);
            grpTerminal2.Controls.Add(lblPasZa2Title);
            grpTerminal2.Controls.Add(lstPasZa2);
            grpTerminal2.Controls.Add(lblDetektor2Title);
            grpTerminal2.Controls.Add(lblDetektor2Value);
            grpTerminal2.Controls.Add(lblRadDetektor2Title);
            grpTerminal2.Controls.Add(lstRadDetektor2);
            grpTerminal2.Controls.Add(lblZber2Title);
            grpTerminal2.Controls.Add(lblZber2Value);
            grpTerminal2.Controls.Add(lblRadZber2Title);
            grpTerminal2.Controls.Add(lstRadZber2);

            // ── Statistics GroupBox ───────────────────────────────────────────
            // Layout constants
            const int xL = 10, xLv = 240, xR = 430, xRv = 665;
            const int rh = 22; // row height
            grpStats.Location = new Point(10, 935);
            grpStats.Size     = new Size(1052, 470);
            grpStats.Text     = "Štatistiky (priemery za replikáciu)";
            grpStats.Font     = new Font("Segoe UI", 10f, FontStyle.Bold);
            grpStats.SuspendLayout();

            var fSecHdr = new Font("Segoe UI", 9f, FontStyle.Bold);
            var secBg   = System.Drawing.Color.FromArgb(220, 230, 245);

            void SecHdr(Label l, string text, int y)
            {
                l.Location  = new Point(xL, y);
                l.Size      = new Size(1020, 18);
                l.Text      = text;
                l.Font      = fSecHdr;
                l.BackColor = secBg;
                l.AutoSize  = false;
            }
            void TitleLbl(Label l, string text, int x, int y)
            {
                l.Location = new Point(x, y); l.Size = new Size(185, 18);
                l.Text = text; l.Font = fTitle;
            }
            void ValLbl(Label l, int x, int y)
            {
                l.Location = new Point(x, y); l.Size = new Size(110, 18);
                l.Text = "—"; l.Font = fStatus;
            }

            // ── RÖNTGEN section ───────────────────────────────────────────────
            int y0 = 20;
            SecHdr(lblSecRontgen, "  Röntgen", y0);

            TitleLbl(lblCasVSystemeTitle,       "Čas v systéme (s):",          xL,  y0 + rh*1);
            ValLbl(lblCasVSystemeValue,                                         xLv, y0 + rh*1);
            TitleLbl(lblAvgCasVRadeTitle,       "Čas čakania v rade (s):",      xR,  y0 + rh*1);
            ValLbl(lblAvgCasVRadeValue,                                         xRv, y0 + rh*1);

            TitleLbl(lblAvgRadRontgen1Title,    "Rad röntgen 1:",               xL,  y0 + rh*2);
            ValLbl(lblAvgRadRontgen1Value,                                      xLv, y0 + rh*2);
            TitleLbl(lblAvgRadRontgen2Title,    "Rad röntgen 2:",               xR,  y0 + rh*2);
            ValLbl(lblAvgRadRontgen2Value,                                      xRv, y0 + rh*2);

            TitleLbl(lblAvgRadRontgenSpoluTitle,"Rad röntgen (spolu):",         xL,  y0 + rh*3);
            ValLbl(lblAvgRadRontgenSpoluValue,                                  xLv, y0 + rh*3);

            TitleLbl(lblAvgCasPasPredTitle,     "Čas čakania pas pred (s):",    xL,  y0 + rh*4);
            ValLbl(lblAvgCasPasPredValue,                                       xLv, y0 + rh*4);
            TitleLbl(lblAvgCasPasZaTitle,       "Čas čakania pas za (s):",      xR,  y0 + rh*4);
            ValLbl(lblAvgCasPasZaValue,                                         xRv, y0 + rh*4);

            TitleLbl(lblAvgPasPred1Title,       "Pas pred röntgen 1:",          xL,  y0 + rh*5);
            ValLbl(lblAvgPasPred1Value,                                         xLv, y0 + rh*5);
            TitleLbl(lblAvgPasPred2Title,       "Pas pred röntgen 2:",          xR,  y0 + rh*5);
            ValLbl(lblAvgPasPred2Value,                                         xRv, y0 + rh*5);

            TitleLbl(lblAvgPasPredSpoluTitle,   "Pas pred röntgen (spolu):",    xL,  y0 + rh*6);
            ValLbl(lblAvgPasPredSpoluValue,                                     xLv, y0 + rh*6);

            TitleLbl(lblAvgPasZa1Title,         "Pas za röntgen 1:",            xL,  y0 + rh*7);
            ValLbl(lblAvgPasZa1Value,                                           xLv, y0 + rh*7);
            TitleLbl(lblAvgPasZa2Title,         "Pas za röntgen 2:",            xR,  y0 + rh*7);
            ValLbl(lblAvgPasZa2Value,                                           xRv, y0 + rh*7);

            TitleLbl(lblAvgPasZaSpoluTitle,     "Pas za röntgen (spolu):",      xL,  y0 + rh*8);
            ValLbl(lblAvgPasZaSpoluValue,                                       xLv, y0 + rh*8);

            // ── DETEKTOR section ──────────────────────────────────────────────
            int yD = y0 + rh*9 + 6;
            SecHdr(lblSecDetektor, "  Detektor kovu", yD);

            TitleLbl(lblAvgCasVRadeDetektorTitle, "Čas čakania v rade (s):",    xL,  yD + rh*1);
            ValLbl(lblAvgCasVRadeDetektorValue,                                  xLv, yD + rh*1);

            TitleLbl(lblAvgRadDetektor1Title,   "Rad detektor 1:",              xL,  yD + rh*2);
            ValLbl(lblAvgRadDetektor1Value,                                     xLv, yD + rh*2);
            TitleLbl(lblAvgRadDetektor2Title,   "Rad detektor 2:",              xR,  yD + rh*2);
            ValLbl(lblAvgRadDetektor2Value,                                     xRv, yD + rh*2);

            TitleLbl(lblAvgRadDetektorSpoluTitle,"Rad detektor (spolu):",       xL,  yD + rh*3);
            ValLbl(lblAvgRadDetektorSpoluValue,                                 xLv, yD + rh*3);

            // ── ZBER section ──────────────────────────────────────────────────
            int yZ = yD + rh*4 + 6;
            SecHdr(lblSecZber, "  Zber prepraviek", yZ);

            TitleLbl(lblAvgCasVRadeZberomTitle, "Čas čakania v rade (s):",      xL,  yZ + rh*1);
            ValLbl(lblAvgCasVRadeZberomValue,                                   xLv, yZ + rh*1);

            TitleLbl(lblAvgRadZber1Title,       "Rad zber 1:",                  xL,  yZ + rh*2);
            ValLbl(lblAvgRadZber1Value,                                         xLv, yZ + rh*2);
            TitleLbl(lblAvgRadZber2Title,       "Rad zber 2:",                  xR,  yZ + rh*2);
            ValLbl(lblAvgRadZber2Value,                                         xRv, yZ + rh*2);

            TitleLbl(lblAvgRadZberSpoluTitle,   "Rad zber (spolu):",            xL,  yZ + rh*3);
            ValLbl(lblAvgRadZberSpoluValue,                                     xLv, yZ + rh*3);

            grpStats.Controls.AddRange(new Control[] {
                lblSecRontgen,
                lblCasVSystemeTitle, lblCasVSystemeValue,
                lblAvgCasVRadeTitle, lblAvgCasVRadeValue,
                lblAvgRadRontgen1Title, lblAvgRadRontgen1Value,
                lblAvgRadRontgen2Title, lblAvgRadRontgen2Value,
                lblAvgRadRontgenSpoluTitle, lblAvgRadRontgenSpoluValue,
                lblAvgCasPasPredTitle, lblAvgCasPasPredValue,
                lblAvgCasPasZaTitle, lblAvgCasPasZaValue,
                lblAvgPasPred1Title, lblAvgPasPred1Value,
                lblAvgPasPred2Title, lblAvgPasPred2Value,
                lblAvgPasPredSpoluTitle, lblAvgPasPredSpoluValue,
                lblAvgPasZa1Title, lblAvgPasZa1Value,
                lblAvgPasZa2Title, lblAvgPasZa2Value,
                lblAvgPasZaSpoluTitle, lblAvgPasZaSpoluValue,
                lblSecDetektor,
                lblAvgCasVRadeDetektorTitle, lblAvgCasVRadeDetektorValue,
                lblAvgRadDetektor1Title, lblAvgRadDetektor1Value,
                lblAvgRadDetektor2Title, lblAvgRadDetektor2Value,
                lblAvgRadDetektorSpoluTitle, lblAvgRadDetektorSpoluValue,
                lblSecZber,
                lblAvgCasVRadeZberomTitle, lblAvgCasVRadeZberomValue,
                lblAvgRadZber1Title, lblAvgRadZber1Value,
                lblAvgRadZber2Title, lblAvgRadZber2Value,
                lblAvgRadZberSpoluTitle, lblAvgRadZberSpoluValue
            });
            grpStats.ResumeLayout(false);

            // ── Global Statistics GroupBox ────────────────────────────────────
            grpGlobalStats.Location = new Point(10, 1415);
            grpGlobalStats.Size     = new Size(1052, 490);
            grpGlobalStats.Text     = "Celkové štatistiky naprieč replikáciami";
            grpGlobalStats.Font     = new Font("Segoe UI", 10f, FontStyle.Bold);
            grpGlobalStats.SuspendLayout();

            // header row: replications count + avg time in system
            TitleLbl(lblReplikacieTitle,          "Počet replikácií:",           xL,  20);
            ValLbl(lblReplikacieValue,                                            xLv, 20);
            lblReplikacieValue.Text = "0";
            TitleLbl(lblGlobalCasVSystemeTitle,   "Priem. čas v systéme (s):",   xR,  20);
            ValLbl(lblGlobalCasVSystemeValue,                                     xRv, 20);

            // ── Röntgen ──────────────────────────────────────────────────────
            int g0 = 20 + rh + 6;
            SecHdr(lblGlobalSecRontgen, "  Röntgen", g0);

            TitleLbl(lblGlobalAvgCasVRadeTitle,       "Čas čakania v rade (s):",      xL,  g0 + rh*1);
            ValLbl(lblGlobalAvgCasVRadeValue,                                          xLv, g0 + rh*1);

            TitleLbl(lblGlobalAvgCasPasPredTitle,     "Čas čakania pas pred (s):",    xL,  g0 + rh*2);
            ValLbl(lblGlobalAvgCasPasPredValue,                                        xLv, g0 + rh*2);
            TitleLbl(lblGlobalAvgCasPasZaTitle,       "Čas čakania pas za (s):",      xR,  g0 + rh*2);
            ValLbl(lblGlobalAvgCasPasZaValue,                                          xRv, g0 + rh*2);

            TitleLbl(lblGlobalAvgRadRontgen1Title,    "Rad röntgen 1:",               xL,  g0 + rh*3);
            ValLbl(lblGlobalAvgRadRontgen1Value,                                       xLv, g0 + rh*3);
            TitleLbl(lblGlobalAvgRadRontgen2Title,    "Rad röntgen 2:",               xR,  g0 + rh*3);
            ValLbl(lblGlobalAvgRadRontgen2Value,                                       xRv, g0 + rh*3);

            TitleLbl(lblGlobalAvgRadRontgenSpoluTitle,"Rad röntgen (spolu):",         xL,  g0 + rh*4);
            ValLbl(lblGlobalAvgRadRontgenSpoluValue,                                   xLv, g0 + rh*4);

            TitleLbl(lblGlobalAvgPasPred1Title,       "Pas pred röntgen 1:",          xL,  g0 + rh*5);
            ValLbl(lblGlobalAvgPasPred1Value,                                          xLv, g0 + rh*5);
            TitleLbl(lblGlobalAvgPasPred2Title,       "Pas pred röntgen 2:",          xR,  g0 + rh*5);
            ValLbl(lblGlobalAvgPasPred2Value,                                          xRv, g0 + rh*5);

            TitleLbl(lblGlobalAvgPasPredSpoluTitle,   "Pas pred röntgen (spolu):",    xL,  g0 + rh*6);
            ValLbl(lblGlobalAvgPasPredSpoluValue,                                      xLv, g0 + rh*6);

            TitleLbl(lblGlobalAvgPasZa1Title,         "Pas za röntgen 1:",            xL,  g0 + rh*7);
            ValLbl(lblGlobalAvgPasZa1Value,                                            xLv, g0 + rh*7);
            TitleLbl(lblGlobalAvgPasZa2Title,         "Pas za röntgen 2:",            xR,  g0 + rh*7);
            ValLbl(lblGlobalAvgPasZa2Value,                                            xRv, g0 + rh*7);

            TitleLbl(lblGlobalAvgPasZaSpoluTitle,     "Pas za röntgen (spolu):",      xL,  g0 + rh*8);
            ValLbl(lblGlobalAvgPasZaSpoluValue,                                        xLv, g0 + rh*8);

            // ── Detektor ─────────────────────────────────────────────────────
            int gD = g0 + rh*9 + 6;
            SecHdr(lblGlobalSecDetektor, "  Detektor kovu", gD);

            TitleLbl(lblGlobalAvgCasVRadeDetektorTitle, "Čas čakania v rade (s):",   xL,  gD + rh*1);
            ValLbl(lblGlobalAvgCasVRadeDetektorValue,                                  xLv, gD + rh*1);

            TitleLbl(lblGlobalAvgRadDetektor1Title,   "Rad detektor 1:",              xL,  gD + rh*2);
            ValLbl(lblGlobalAvgRadDetektor1Value,                                      xLv, gD + rh*2);
            TitleLbl(lblGlobalAvgRadDetektor2Title,   "Rad detektor 2:",              xR,  gD + rh*2);
            ValLbl(lblGlobalAvgRadDetektor2Value,                                      xRv, gD + rh*2);

            TitleLbl(lblGlobalAvgRadDetektorSpoluTitle,"Rad detektor (spolu):",       xL,  gD + rh*3);
            ValLbl(lblGlobalAvgRadDetektorSpoluValue,                                  xLv, gD + rh*3);

            // ── Zber ─────────────────────────────────────────────────────────
            int gZ = gD + rh*4 + 6;
            SecHdr(lblGlobalSecZber, "  Zber prepraviek", gZ);

            TitleLbl(lblGlobalAvgCasVRadeZberomTitle, "Čas čakania v rade (s):",      xL,  gZ + rh*1);
            ValLbl(lblGlobalAvgCasVRadeZberomValue,                                    xLv, gZ + rh*1);

            TitleLbl(lblGlobalAvgRadZber1Title,       "Rad zber 1:",                  xL,  gZ + rh*2);
            ValLbl(lblGlobalAvgRadZber1Value,                                          xLv, gZ + rh*2);
            TitleLbl(lblGlobalAvgRadZber2Title,       "Rad zber 2:",                  xR,  gZ + rh*2);
            ValLbl(lblGlobalAvgRadZber2Value,                                          xRv, gZ + rh*2);

            TitleLbl(lblGlobalAvgRadZberSpoluTitle,   "Rad zber (spolu):",            xL,  gZ + rh*3);
            ValLbl(lblGlobalAvgRadZberSpoluValue,                                      xLv, gZ + rh*3);

            grpGlobalStats.Controls.AddRange(new Control[] {
                lblReplikacieTitle, lblReplikacieValue,
                lblGlobalCasVSystemeTitle, lblGlobalCasVSystemeValue,
                lblGlobalSecRontgen,
                lblGlobalAvgCasVRadeTitle, lblGlobalAvgCasVRadeValue,
                lblGlobalAvgCasPasPredTitle, lblGlobalAvgCasPasPredValue,
                lblGlobalAvgCasPasZaTitle, lblGlobalAvgCasPasZaValue,
                lblGlobalAvgRadRontgen1Title, lblGlobalAvgRadRontgen1Value,
                lblGlobalAvgRadRontgen2Title, lblGlobalAvgRadRontgen2Value,
                lblGlobalAvgRadRontgenSpoluTitle, lblGlobalAvgRadRontgenSpoluValue,
                lblGlobalAvgPasPred1Title, lblGlobalAvgPasPred1Value,
                lblGlobalAvgPasPred2Title, lblGlobalAvgPasPred2Value,
                lblGlobalAvgPasPredSpoluTitle, lblGlobalAvgPasPredSpoluValue,
                lblGlobalAvgPasZa1Title, lblGlobalAvgPasZa1Value,
                lblGlobalAvgPasZa2Title, lblGlobalAvgPasZa2Value,
                lblGlobalAvgPasZaSpoluTitle, lblGlobalAvgPasZaSpoluValue,
                lblGlobalSecDetektor,
                lblGlobalAvgCasVRadeDetektorTitle, lblGlobalAvgCasVRadeDetektorValue,
                lblGlobalAvgRadDetektor1Title, lblGlobalAvgRadDetektor1Value,
                lblGlobalAvgRadDetektor2Title, lblGlobalAvgRadDetektor2Value,
                lblGlobalAvgRadDetektorSpoluTitle, lblGlobalAvgRadDetektorSpoluValue,
                lblGlobalSecZber,
                lblGlobalAvgCasVRadeZberomTitle, lblGlobalAvgCasVRadeZberomValue,
                lblGlobalAvgRadZber1Title, lblGlobalAvgRadZber1Value,
                lblGlobalAvgRadZber2Title, lblGlobalAvgRadZber2Value,
                lblGlobalAvgRadZberSpoluTitle, lblGlobalAvgRadZberSpoluValue
            });
            grpGlobalStats.ResumeLayout(false);

            // ── Form ──────────────────────────────────────────────────────────
            ClientSize   = new Size(1072, 900);
            AutoScroll   = true;
            AutoScrollMinSize = new Size(1072, 1925);
            Text         = "Letisko Simulácia";
            Controls.Add(btnStart);
            Controls.Add(btnPause);
            Controls.Add(btnStop);
            Controls.Add(btnReplicationStats);
            Controls.Add(btnSimulationStats);
            Controls.Add(chkDependency);
            Controls.Add(lblTestPointsTitle);
            Controls.Add(numTestPoints);
            Controls.Add(btnDependency);
            Controls.Add(grpParams);
            Controls.Add(grpSpeed);
            Controls.Add(lblSimTimeTitle);
            Controls.Add(lblSimTimeValue);
            Controls.Add(lblPocetTitle);
            Controls.Add(lblPocetValue);
            Controls.Add(grpTerminal1);
            Controls.Add(grpTerminal2);
            Controls.Add(grpStats);
            Controls.Add(grpGlobalStats);
            Controls.Add(chkSaveCsv);
            Controls.Add(chkCollectByInterval);
            Controls.Add(numCollectInterval);
            Controls.Add(chkWarmup);
            Controls.Add(lblWarmupTimeTitle);
            Controls.Add(numWarmupTime);
            Controls.Add(chkFixedSeed);
            Controls.Add(lblSeedTitle);
            Controls.Add(numSeed);

            grpParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numReplikacii).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucich).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTestPoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucichOd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucichDo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPasPred).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPasZa).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSimDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeed).EndInit();
            grpSpeed.ResumeLayout(false);
            grpTerminal1.ResumeLayout(false);
            grpTerminal2.ResumeLayout(false);
            // grpGlobalStats already resumed above
            ((System.ComponentModel.ISupportInitialize)sldSleep).EndInit();
            ((System.ComponentModel.ISupportInitialize)sldStep).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // ── Control fields ────────────────────────────────────────────────────
        private Button    btnStart;
        private Button    btnPause;
        private Button    btnStop;
        private Button    btnReplicationStats;
        private Button    btnSimulationStats;
        private GroupBox  grpSpeed;
        private CheckBox  chkMaxSpeed;
        private Label     lblSleepTitle;
        private TrackBar  sldSleep;
        private Label     lblSleepValue;
        private Label     lblStepTitle;
        private TrackBar  sldStep;
        private Label     lblStepValue;

        private Label     lblSimTimeTitle;
        private Label     lblSimTimeValue;
        private Label     lblPocetTitle;
        private Label     lblPocetValue;

        // Terminal 1
        private GroupBox  grpTerminal1;
        private Label     lblRontgenCestujuci1Title;
        private Label     lblRontgenCestujuci1Value;
        private Label     lblRontgenPrepravka1Title;
        private Label     lblRontgenPrepravka1Value;
        private Label     lblQueue1Title;
        private ListBox   lstQueue1;
        private Label     lblPasPred1Title;
        private ListBox   lstPasPred1;
        private Label     lblPasZa1Title;
        private ListBox   lstPasZa1;
        private Label     lblDetektor1Title;
        private Label     lblDetektor1Value;
        private Label     lblRadDetektor1Title;
        private ListBox   lstRadDetektor1;
        private Label     lblZber1Title;
        private Label     lblZber1Value;
        private Label     lblRadZber1Title;
        private ListBox   lstRadZber1;

        // Terminal 2
        private GroupBox  grpTerminal2;
        private Label     lblRontgenCestujuci2Title;
        private Label     lblRontgenCestujuci2Value;
        private Label     lblRontgenPrepravka2Title;
        private Label     lblRontgenPrepravka2Value;
        private Label     lblQueue2Title;
        private ListBox   lstQueue2;
        private Label     lblPasPred2Title;
        private ListBox   lstPasPred2;
        private Label     lblPasZa2Title;
        private ListBox   lstPasZa2;
        private Label     lblDetektor2Title;
        private Label     lblDetektor2Value;
        private Label     lblRadDetektor2Title;
        private ListBox   lstRadDetektor2;
        private Label     lblZber2Title;
        private Label     lblZber2Value;
        private Label     lblRadZber2Title;
        private ListBox   lstRadZber2;

        // CSV export
        private CheckBox       chkSaveCsv;
        private CheckBox       chkCollectByInterval;
        private NumericUpDown  numCollectInterval;
        private CheckBox       chkWarmup;
        private Label          lblWarmupTimeTitle;
        private NumericUpDown  numWarmupTime;

        // Dependency mode
        private CheckBox       chkDependency;
        private Label          lblTestPointsTitle;
        private NumericUpDown  numTestPoints;
        private Button         btnDependency;

        // Parameters
        private GroupBox       grpParams;
        private Label          lblReplikaciiTitle;
        private NumericUpDown  numReplikacii;
        private CheckBox       chkProgressiveLambda;
        private Label          lblOdTitle;
        private NumericUpDown  numCestujucichOd;
        private Label          lblDoTitle;
        private NumericUpDown  numCestujucichDo;
        private Label          lblCestujucichTitle;
        private NumericUpDown  numCestujucich;
        private Label          lblLambdaTitle;
        private Label          lblLambdaValue;
        private Label          lblMaxPasPredTitle;
        private NumericUpDown  numMaxPasPred;
        private Label          lblMaxPasZaTitle;
        private NumericUpDown  numMaxPasZa;
        private Label          lblSimDurationTitle;
        private NumericUpDown  numSimDuration;
        private ComboBox       cmbSimDurationUnit;
        private CheckBox       chkFixedSeed;
        private Label          lblSeedTitle;
        private NumericUpDown  numSeed;

        // Statistics (per-replication)
        private GroupBox  grpStats;
        private Label     lblCasVSystemeTitle;
        private Label     lblCasVSystemeValue;
        private Label     lblAvgRadRontgen1Title;
        private Label     lblAvgRadRontgen1Value;
        private Label     lblAvgRadRontgen2Title;
        private Label     lblAvgRadRontgen2Value;
        private Label     lblAvgRadDetektor1Title;
        private Label     lblAvgRadDetektor1Value;
        private Label     lblAvgRadDetektor2Title;
        private Label     lblAvgRadDetektor2Value;
        private Label     lblAvgRadZber1Title;
        private Label     lblAvgRadZber1Value;
        private Label     lblAvgRadZber2Title;
        private Label     lblAvgRadZber2Value;
        private Label     lblAvgRadRontgenSpoluTitle;
        private Label     lblAvgRadRontgenSpoluValue;
        private Label     lblAvgRadDetektorSpoluTitle;
        private Label     lblAvgRadDetektorSpoluValue;
        private Label     lblAvgRadZberSpoluTitle;
        private Label     lblAvgRadZberSpoluValue;
        private Label     lblSecRontgen;
        private Label     lblSecDetektor;
        private Label     lblSecZber;
        private Label     lblAvgCasVRadeTitle;
        private Label     lblAvgCasVRadeValue;
        private Label     lblAvgCasPasPredTitle;
        private Label     lblAvgCasPasPredValue;
        private Label     lblAvgCasPasZaTitle;
        private Label     lblAvgCasPasZaValue;
        private Label     lblAvgCasVRadeDetektorTitle;
        private Label     lblAvgCasVRadeDetektorValue;
        private Label     lblAvgCasVRadeZberomTitle;
        private Label     lblAvgCasVRadeZberomValue;
        private Label     lblAvgPasPred1Title;
        private Label     lblAvgPasPred1Value;
        private Label     lblAvgPasPred2Title;
        private Label     lblAvgPasPred2Value;
        private Label     lblAvgPasZa1Title;
        private Label     lblAvgPasZa1Value;
        private Label     lblAvgPasZa2Title;
        private Label     lblAvgPasZa2Value;
        private Label     lblAvgPasPredSpoluTitle;
        private Label     lblAvgPasPredSpoluValue;
        private Label     lblAvgPasZaSpoluTitle;
        private Label     lblAvgPasZaSpoluValue;

        // Global statistics (across replications)
        private GroupBox  grpGlobalStats;
        private Label     lblReplikacieTitle;
        private Label     lblReplikacieValue;
        private Label     lblGlobalCasVSystemeTitle;
        private Label     lblGlobalCasVSystemeValue;
        private Label     lblGlobalAvgRadRontgen1Title;
        private Label     lblGlobalAvgRadRontgen1Value;
        private Label     lblGlobalAvgRadRontgen2Title;
        private Label     lblGlobalAvgRadRontgen2Value;
        private Label     lblGlobalAvgRadDetektor1Title;
        private Label     lblGlobalAvgRadDetektor1Value;
        private Label     lblGlobalAvgRadDetektor2Title;
        private Label     lblGlobalAvgRadDetektor2Value;
        private Label     lblGlobalAvgRadZber1Title;
        private Label     lblGlobalAvgRadZber1Value;
        private Label     lblGlobalAvgRadZber2Title;
        private Label     lblGlobalAvgRadZber2Value;
        private Label     lblGlobalAvgRadRontgenSpoluTitle;
        private Label     lblGlobalAvgRadRontgenSpoluValue;
        private Label     lblGlobalAvgRadDetektorSpoluTitle;
        private Label     lblGlobalAvgRadDetektorSpoluValue;
        private Label     lblGlobalAvgRadZberSpoluTitle;
        private Label     lblGlobalAvgRadZberSpoluValue;
        private Label     lblGlobalSecRontgen;
        private Label     lblGlobalSecDetektor;
        private Label     lblGlobalSecZber;
        private Label     lblGlobalAvgCasVRadeTitle;
        private Label     lblGlobalAvgCasVRadeValue;
        private Label     lblGlobalAvgCasPasPredTitle;
        private Label     lblGlobalAvgCasPasPredValue;
        private Label     lblGlobalAvgCasPasZaTitle;
        private Label     lblGlobalAvgCasPasZaValue;
        private Label     lblGlobalAvgCasVRadeDetektorTitle;
        private Label     lblGlobalAvgCasVRadeDetektorValue;
        private Label     lblGlobalAvgCasVRadeZberomTitle;
        private Label     lblGlobalAvgCasVRadeZberomValue;
        private Label     lblGlobalAvgPasPred1Title;
        private Label     lblGlobalAvgPasPred1Value;
        private Label     lblGlobalAvgPasPred2Title;
        private Label     lblGlobalAvgPasPred2Value;
        private Label     lblGlobalAvgPasZa1Title;
        private Label     lblGlobalAvgPasZa1Value;
        private Label     lblGlobalAvgPasZa2Title;
        private Label     lblGlobalAvgPasZa2Value;
        private Label     lblGlobalAvgPasPredSpoluTitle;
        private Label     lblGlobalAvgPasPredSpoluValue;
        private Label     lblGlobalAvgPasZaSpoluTitle;
        private Label     lblGlobalAvgPasZaSpoluValue;
    }
}
