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
            chkSaveCsv          = new CheckBox();
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
            grpStats                    = new GroupBox();
            lblCasVSystemeTitle         = new Label();
            lblCasVSystemeValue         = new Label();
            lblAvgRadRontgen1Title      = new Label();
            lblAvgRadRontgen1Value      = new Label();
            lblAvgRadRontgen2Title      = new Label();
            lblAvgRadRontgen2Value      = new Label();
            lblAvgRadDetektor1Title     = new Label();
            lblAvgRadDetektor1Value     = new Label();
            lblAvgRadDetektor2Title     = new Label();
            lblAvgRadDetektor2Value     = new Label();
            lblAvgRadZber1Title         = new Label();
            lblAvgRadZber1Value         = new Label();
            lblAvgRadZber2Title         = new Label();
            lblAvgRadZber2Value         = new Label();
            lblAvgRadRontgenSpoluTitle  = new Label();
            lblAvgRadRontgenSpoluValue  = new Label();
            lblAvgRadDetektorSpoluTitle = new Label();
            lblAvgRadDetektorSpoluValue = new Label();
            lblAvgRadZberSpoluTitle     = new Label();
            lblAvgRadZberSpoluValue     = new Label();

            // ── Global statistics ─────────────────────────────────────────────
            grpGlobalStats                      = new GroupBox();
            lblReplikacieTitle                  = new Label();
            lblReplikacieValue                  = new Label();
            lblGlobalCasVSystemeTitle           = new Label();
            lblGlobalCasVSystemeValue           = new Label();
            lblGlobalAvgRadRontgen1Title        = new Label();
            lblGlobalAvgRadRontgen1Value        = new Label();
            lblGlobalAvgRadRontgen2Title        = new Label();
            lblGlobalAvgRadRontgen2Value        = new Label();
            lblGlobalAvgRadDetektor1Title       = new Label();
            lblGlobalAvgRadDetektor1Value       = new Label();
            lblGlobalAvgRadDetektor2Title       = new Label();
            lblGlobalAvgRadDetektor2Value       = new Label();
            lblGlobalAvgRadZber1Title           = new Label();
            lblGlobalAvgRadZber1Value           = new Label();
            lblGlobalAvgRadZber2Title           = new Label();
            lblGlobalAvgRadZber2Value           = new Label();
            lblGlobalAvgRadRontgenSpoluTitle    = new Label();
            lblGlobalAvgRadRontgenSpoluValue    = new Label();
            lblGlobalAvgRadDetektorSpoluTitle   = new Label();
            lblGlobalAvgRadDetektorSpoluValue   = new Label();
            lblGlobalAvgRadZberSpoluTitle       = new Label();
            lblGlobalAvgRadZberSpoluValue       = new Label();

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

            // chkWarmup
            chkWarmup.Location       = new Point(640, 95);
            chkWarmup.Size           = new Size(150, 22);
            chkWarmup.Text           = "Zahriatie (warmup)";
            chkWarmup.CheckedChanged += chkWarmup_CheckedChanged;

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
            grpSpeed.Location = new Point(15, 160);
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

            lblSimTimeTitle.Location = new Point(15, 313);
            lblSimTimeTitle.Size     = new Size(105, 22);
            lblSimTimeTitle.Text     = "Čas simulácie:";
            lblSimTimeTitle.Font     = boldNormal;

            lblSimTimeValue.Location = new Point(125, 313);
            lblSimTimeValue.Size     = new Size(120, 22);
            lblSimTimeValue.Text     = "00:00:00";
            lblSimTimeValue.Font     = plainNormal;

            lblPocetTitle.Location = new Point(285, 313);
            lblPocetTitle.Size     = new Size(165, 22);
            lblPocetTitle.Text     = "Počet cestujúcich:";
            lblPocetTitle.Font     = boldNormal;

            lblPocetValue.Location = new Point(455, 313);
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
            grpParams.Size     = new Size(600, 120);
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

            // ══════════════════════════════════════════════════════════════════
            // ── Terminal 1 GroupBox ───────────────────────────────────────────
            // ══════════════════════════════════════════════════════════════════
            grpTerminal1.Location = new Point(10, 343);
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
            grpTerminal2.Location = new Point(540, 343);
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
            grpStats.Location = new Point(10, 875);
            grpStats.Size     = new Size(1052, 200);
            grpStats.Text     = "Štatistiky (priemery za replikáciu)";
            grpStats.Font     = new Font("Segoe UI", 10f, FontStyle.Bold);
            grpStats.SuspendLayout();

            lblCasVSystemeTitle.Location = new Point(10, 25);
            lblCasVSystemeTitle.Size     = new Size(230, 20);
            lblCasVSystemeTitle.Text     = "Priem. čas v systéme (s):";
            lblCasVSystemeTitle.Font     = fTitle;

            lblCasVSystemeValue.Location = new Point(245, 25);
            lblCasVSystemeValue.Size     = new Size(130, 20);
            lblCasVSystemeValue.Text     = "—";
            lblCasVSystemeValue.Font     = fStatus;

            lblAvgRadRontgen1Title.Location = new Point(10, 50);
            lblAvgRadRontgen1Title.Size     = new Size(210, 20);
            lblAvgRadRontgen1Title.Text     = "Priem. rad röntgen 1:";
            lblAvgRadRontgen1Title.Font     = fTitle;

            lblAvgRadRontgen1Value.Location = new Point(225, 50);
            lblAvgRadRontgen1Value.Size     = new Size(110, 20);
            lblAvgRadRontgen1Value.Text     = "—";
            lblAvgRadRontgen1Value.Font     = fStatus;

            lblAvgRadRontgen2Title.Location = new Point(536, 50);
            lblAvgRadRontgen2Title.Size     = new Size(210, 20);
            lblAvgRadRontgen2Title.Text     = "Priem. rad röntgen 2:";
            lblAvgRadRontgen2Title.Font     = fTitle;

            lblAvgRadRontgen2Value.Location = new Point(751, 50);
            lblAvgRadRontgen2Value.Size     = new Size(110, 20);
            lblAvgRadRontgen2Value.Text     = "—";
            lblAvgRadRontgen2Value.Font     = fStatus;

            lblAvgRadDetektor1Title.Location = new Point(10, 75);
            lblAvgRadDetektor1Title.Size     = new Size(210, 20);
            lblAvgRadDetektor1Title.Text     = "Priem. rad detektor 1:";
            lblAvgRadDetektor1Title.Font     = fTitle;

            lblAvgRadDetektor1Value.Location = new Point(225, 75);
            lblAvgRadDetektor1Value.Size     = new Size(110, 20);
            lblAvgRadDetektor1Value.Text     = "—";
            lblAvgRadDetektor1Value.Font     = fStatus;

            lblAvgRadDetektor2Title.Location = new Point(536, 75);
            lblAvgRadDetektor2Title.Size     = new Size(210, 20);
            lblAvgRadDetektor2Title.Text     = "Priem. rad detektor 2:";
            lblAvgRadDetektor2Title.Font     = fTitle;

            lblAvgRadDetektor2Value.Location = new Point(751, 75);
            lblAvgRadDetektor2Value.Size     = new Size(110, 20);
            lblAvgRadDetektor2Value.Text     = "—";
            lblAvgRadDetektor2Value.Font     = fStatus;

            lblAvgRadZber1Title.Location = new Point(10, 100);
            lblAvgRadZber1Title.Size     = new Size(210, 20);
            lblAvgRadZber1Title.Text     = "Priem. rad zber 1:";
            lblAvgRadZber1Title.Font     = fTitle;

            lblAvgRadZber1Value.Location = new Point(225, 100);
            lblAvgRadZber1Value.Size     = new Size(110, 20);
            lblAvgRadZber1Value.Text     = "—";
            lblAvgRadZber1Value.Font     = fStatus;

            lblAvgRadZber2Title.Location = new Point(536, 100);
            lblAvgRadZber2Title.Size     = new Size(210, 20);
            lblAvgRadZber2Title.Text     = "Priem. rad zber 2:";
            lblAvgRadZber2Title.Font     = fTitle;

            lblAvgRadZber2Value.Location = new Point(751, 100);
            lblAvgRadZber2Value.Size     = new Size(110, 20);
            lblAvgRadZber2Value.Text     = "—";
            lblAvgRadZber2Value.Font     = fStatus;

            lblAvgRadRontgenSpoluTitle.Location = new Point(10, 125);
            lblAvgRadRontgenSpoluTitle.Size     = new Size(210, 20);
            lblAvgRadRontgenSpoluTitle.Text     = "Priem. rad röntgen (spolu):";
            lblAvgRadRontgenSpoluTitle.Font     = fTitle;

            lblAvgRadRontgenSpoluValue.Location = new Point(225, 125);
            lblAvgRadRontgenSpoluValue.Size     = new Size(110, 20);
            lblAvgRadRontgenSpoluValue.Text     = "—";
            lblAvgRadRontgenSpoluValue.Font     = fStatus;

            lblAvgRadDetektorSpoluTitle.Location = new Point(10, 150);
            lblAvgRadDetektorSpoluTitle.Size     = new Size(210, 20);
            lblAvgRadDetektorSpoluTitle.Text     = "Priem. rad detektor (spolu):";
            lblAvgRadDetektorSpoluTitle.Font     = fTitle;

            lblAvgRadDetektorSpoluValue.Location = new Point(225, 150);
            lblAvgRadDetektorSpoluValue.Size     = new Size(110, 20);
            lblAvgRadDetektorSpoluValue.Text     = "—";
            lblAvgRadDetektorSpoluValue.Font     = fStatus;

            lblAvgRadZberSpoluTitle.Location = new Point(10, 175);
            lblAvgRadZberSpoluTitle.Size     = new Size(210, 20);
            lblAvgRadZberSpoluTitle.Text     = "Priem. rad zber (spolu):";
            lblAvgRadZberSpoluTitle.Font     = fTitle;

            lblAvgRadZberSpoluValue.Location = new Point(225, 175);
            lblAvgRadZberSpoluValue.Size     = new Size(110, 20);
            lblAvgRadZberSpoluValue.Text     = "—";
            lblAvgRadZberSpoluValue.Font     = fStatus;

            grpStats.Controls.Add(lblCasVSystemeTitle);
            grpStats.Controls.Add(lblCasVSystemeValue);
            grpStats.Controls.Add(lblAvgRadRontgen1Title);
            grpStats.Controls.Add(lblAvgRadRontgen1Value);
            grpStats.Controls.Add(lblAvgRadRontgen2Title);
            grpStats.Controls.Add(lblAvgRadRontgen2Value);
            grpStats.Controls.Add(lblAvgRadDetektor1Title);
            grpStats.Controls.Add(lblAvgRadDetektor1Value);
            grpStats.Controls.Add(lblAvgRadDetektor2Title);
            grpStats.Controls.Add(lblAvgRadDetektor2Value);
            grpStats.Controls.Add(lblAvgRadZber1Title);
            grpStats.Controls.Add(lblAvgRadZber1Value);
            grpStats.Controls.Add(lblAvgRadZber2Title);
            grpStats.Controls.Add(lblAvgRadZber2Value);
            grpStats.Controls.Add(lblAvgRadRontgenSpoluTitle);
            grpStats.Controls.Add(lblAvgRadRontgenSpoluValue);
            grpStats.Controls.Add(lblAvgRadDetektorSpoluTitle);
            grpStats.Controls.Add(lblAvgRadDetektorSpoluValue);
            grpStats.Controls.Add(lblAvgRadZberSpoluTitle);
            grpStats.Controls.Add(lblAvgRadZberSpoluValue);
            grpStats.ResumeLayout(false);

            // ── Global Statistics GroupBox ────────────────────────────────────
            grpGlobalStats.Location = new Point(10, 1085);
            grpGlobalStats.Size     = new Size(1052, 230);
            grpGlobalStats.Text     = "Celkové štatistiky naprieč replikáciami";
            grpGlobalStats.Font     = new Font("Segoe UI", 10f, FontStyle.Bold);

            lblReplikacieTitle.Location = new Point(10, 25);
            lblReplikacieTitle.Size     = new Size(150, 20);
            lblReplikacieTitle.Text     = "Počet replikácií:";
            lblReplikacieTitle.Font     = fTitle;

            lblReplikacieValue.Location = new Point(165, 25);
            lblReplikacieValue.Size     = new Size(100, 20);
            lblReplikacieValue.Text     = "0";
            lblReplikacieValue.Font     = fStatus;

            lblGlobalCasVSystemeTitle.Location = new Point(400, 25);
            lblGlobalCasVSystemeTitle.Size     = new Size(230, 20);
            lblGlobalCasVSystemeTitle.Text     = "Priem. čas v systéme (s):";
            lblGlobalCasVSystemeTitle.Font     = fTitle;

            lblGlobalCasVSystemeValue.Location = new Point(635, 25);
            lblGlobalCasVSystemeValue.Size     = new Size(130, 20);
            lblGlobalCasVSystemeValue.Text     = "—";
            lblGlobalCasVSystemeValue.Font     = fStatus;

            lblGlobalAvgRadRontgen1Title.Location = new Point(10, 55);
            lblGlobalAvgRadRontgen1Title.Size     = new Size(210, 20);
            lblGlobalAvgRadRontgen1Title.Text     = "Priem. rad röntgen 1:";
            lblGlobalAvgRadRontgen1Title.Font     = fTitle;

            lblGlobalAvgRadRontgen1Value.Location = new Point(225, 55);
            lblGlobalAvgRadRontgen1Value.Size     = new Size(110, 20);
            lblGlobalAvgRadRontgen1Value.Text     = "—";
            lblGlobalAvgRadRontgen1Value.Font     = fStatus;

            lblGlobalAvgRadRontgen2Title.Location = new Point(536, 55);
            lblGlobalAvgRadRontgen2Title.Size     = new Size(210, 20);
            lblGlobalAvgRadRontgen2Title.Text     = "Priem. rad röntgen 2:";
            lblGlobalAvgRadRontgen2Title.Font     = fTitle;

            lblGlobalAvgRadRontgen2Value.Location = new Point(751, 55);
            lblGlobalAvgRadRontgen2Value.Size     = new Size(110, 20);
            lblGlobalAvgRadRontgen2Value.Text     = "—";
            lblGlobalAvgRadRontgen2Value.Font     = fStatus;

            lblGlobalAvgRadDetektor1Title.Location = new Point(10, 80);
            lblGlobalAvgRadDetektor1Title.Size     = new Size(210, 20);
            lblGlobalAvgRadDetektor1Title.Text     = "Priem. rad detektor 1:";
            lblGlobalAvgRadDetektor1Title.Font     = fTitle;

            lblGlobalAvgRadDetektor1Value.Location = new Point(225, 80);
            lblGlobalAvgRadDetektor1Value.Size     = new Size(110, 20);
            lblGlobalAvgRadDetektor1Value.Text     = "—";
            lblGlobalAvgRadDetektor1Value.Font     = fStatus;

            lblGlobalAvgRadDetektor2Title.Location = new Point(536, 80);
            lblGlobalAvgRadDetektor2Title.Size     = new Size(210, 20);
            lblGlobalAvgRadDetektor2Title.Text     = "Priem. rad detektor 2:";
            lblGlobalAvgRadDetektor2Title.Font     = fTitle;

            lblGlobalAvgRadDetektor2Value.Location = new Point(751, 80);
            lblGlobalAvgRadDetektor2Value.Size     = new Size(110, 20);
            lblGlobalAvgRadDetektor2Value.Text     = "—";
            lblGlobalAvgRadDetektor2Value.Font     = fStatus;

            lblGlobalAvgRadZber1Title.Location = new Point(10, 105);
            lblGlobalAvgRadZber1Title.Size     = new Size(210, 20);
            lblGlobalAvgRadZber1Title.Text     = "Priem. rad zber 1:";
            lblGlobalAvgRadZber1Title.Font     = fTitle;

            lblGlobalAvgRadZber1Value.Location = new Point(225, 105);
            lblGlobalAvgRadZber1Value.Size     = new Size(110, 20);
            lblGlobalAvgRadZber1Value.Text     = "—";
            lblGlobalAvgRadZber1Value.Font     = fStatus;

            lblGlobalAvgRadZber2Title.Location = new Point(536, 105);
            lblGlobalAvgRadZber2Title.Size     = new Size(210, 20);
            lblGlobalAvgRadZber2Title.Text     = "Priem. rad zber 2:";
            lblGlobalAvgRadZber2Title.Font     = fTitle;

            lblGlobalAvgRadZber2Value.Location = new Point(751, 105);
            lblGlobalAvgRadZber2Value.Size     = new Size(110, 20);
            lblGlobalAvgRadZber2Value.Text     = "—";
            lblGlobalAvgRadZber2Value.Font     = fStatus;

            lblGlobalAvgRadRontgenSpoluTitle.Location = new Point(10, 135);
            lblGlobalAvgRadRontgenSpoluTitle.Size     = new Size(210, 20);
            lblGlobalAvgRadRontgenSpoluTitle.Text     = "Priem. rad röntgen (spolu):";
            lblGlobalAvgRadRontgenSpoluTitle.Font     = fTitle;

            lblGlobalAvgRadRontgenSpoluValue.Location = new Point(225, 135);
            lblGlobalAvgRadRontgenSpoluValue.Size     = new Size(110, 20);
            lblGlobalAvgRadRontgenSpoluValue.Text     = "—";
            lblGlobalAvgRadRontgenSpoluValue.Font     = fStatus;

            lblGlobalAvgRadDetektorSpoluTitle.Location = new Point(10, 160);
            lblGlobalAvgRadDetektorSpoluTitle.Size     = new Size(210, 20);
            lblGlobalAvgRadDetektorSpoluTitle.Text     = "Priem. rad detektor (spolu):";
            lblGlobalAvgRadDetektorSpoluTitle.Font     = fTitle;

            lblGlobalAvgRadDetektorSpoluValue.Location = new Point(225, 160);
            lblGlobalAvgRadDetektorSpoluValue.Size     = new Size(110, 20);
            lblGlobalAvgRadDetektorSpoluValue.Text     = "—";
            lblGlobalAvgRadDetektorSpoluValue.Font     = fStatus;

            lblGlobalAvgRadZberSpoluTitle.Location = new Point(10, 185);
            lblGlobalAvgRadZberSpoluTitle.Size     = new Size(210, 20);
            lblGlobalAvgRadZberSpoluTitle.Text     = "Priem. rad zber (spolu):";
            lblGlobalAvgRadZberSpoluTitle.Font     = fTitle;

            lblGlobalAvgRadZberSpoluValue.Location = new Point(225, 185);
            lblGlobalAvgRadZberSpoluValue.Size     = new Size(110, 20);
            lblGlobalAvgRadZberSpoluValue.Text     = "—";
            lblGlobalAvgRadZberSpoluValue.Font     = fStatus;

            grpGlobalStats.Controls.Add(lblReplikacieTitle);
            grpGlobalStats.Controls.Add(lblReplikacieValue);
            grpGlobalStats.Controls.Add(lblGlobalCasVSystemeTitle);
            grpGlobalStats.Controls.Add(lblGlobalCasVSystemeValue);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadRontgen1Title);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadRontgen1Value);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadRontgen2Title);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadRontgen2Value);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadDetektor1Title);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadDetektor1Value);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadDetektor2Title);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadDetektor2Value);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadZber1Title);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadZber1Value);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadZber2Title);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadZber2Value);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadRontgenSpoluTitle);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadRontgenSpoluValue);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadDetektorSpoluTitle);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadDetektorSpoluValue);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadZberSpoluTitle);
            grpGlobalStats.Controls.Add(lblGlobalAvgRadZberSpoluValue);
            grpGlobalStats.ResumeLayout(false);

            // ── Form ──────────────────────────────────────────────────────────
            ClientSize   = new Size(1072, 900);
            AutoScroll   = true;
            AutoScrollMinSize = new Size(1072, 1330);
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
            Controls.Add(chkWarmup);
            Controls.Add(lblWarmupTimeTitle);
            Controls.Add(numWarmupTime);

            grpParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numReplikacii).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucich).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTestPoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucichOd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCestujucichDo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPasPred).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxPasZa).EndInit();
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
    }
}
