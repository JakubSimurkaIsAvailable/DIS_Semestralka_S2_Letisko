using DIS_Semestralka_S2_Letisko.Letisko;
using ScottPlot;
using ScottPlot.WinForms;
using Label     = System.Windows.Forms.Label;
using Color     = ScottPlot.Color;
using Font      = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;

namespace MainForm
{
    // 2.2
    public partial class SimulationForm : Form
    {
        // ── Labels ───────────────────────────────────────────────────────────
        private readonly Label _lblRepValue                  = new();
        private readonly Label _lblCasVSystemeValue          = new();
        private readonly Label _lblCasVRadeValue             = new();
        private readonly Label _lblCasPasPredValue           = new();
        private readonly Label _lblCasPasZaValue             = new();
        private readonly Label _lblCasVRadeDetektorValue     = new();
        private readonly Label _lblCasVRadeZberomValue       = new();
        private readonly Label _lblRadRontgenSpoluValue      = new();
        private readonly Label _lblRadDetektorSpoluValue     = new();
        private readonly Label _lblRadZberSpoluValue         = new();
        private readonly Label _lblPasPredSpoluValue         = new();
        private readonly Label _lblPasZaSpoluValue           = new();

        // ── CI labels ────────────────────────────────────────────────────────
        private readonly Label _lblCasVSystemeCi          = new();
        private readonly Label _lblCasVRadeCi             = new();
        private readonly Label _lblCasPasPredCi           = new();
        private readonly Label _lblCasPasZaCi             = new();
        private readonly Label _lblCasVRadeDetektorCi     = new();
        private readonly Label _lblCasVRadeZberomCi       = new();
        private readonly Label _lblRadRontgenSpoluCi      = new();
        private readonly Label _lblRadDetektorSpoluCi     = new();
        private readonly Label _lblRadZberSpoluCi         = new();
        private readonly Label _lblPasPredSpoluCi         = new();
        private readonly Label _lblPasZaSpoluCi           = new();

        // ── Charts ───────────────────────────────────────────────────────────
        private readonly FormsPlot _chartRontgen          = new();
        private readonly FormsPlot _chartDetektor         = new();
        private readonly FormsPlot _chartZber             = new();
        private readonly FormsPlot _chartCas              = new();
        private readonly FormsPlot _chartCasVRade         = new();
        private readonly FormsPlot _chartCasPasPred       = new();
        private readonly FormsPlot _chartCasPasZa         = new();
        private readonly FormsPlot _chartCasVRadeDetektor = new();
        private readonly FormsPlot _chartCasVRadeZber     = new();
        private readonly FormsPlot _chartPasPred          = new();
        private readonly FormsPlot _chartPasZa            = new();

        // ── DataLoggers ──────────────────────────────────────────────────────
        private ScottPlot.Plottables.DataLogger? _dlRontgen;
        private ScottPlot.Plottables.DataLogger? _dlDetektor;
        private ScottPlot.Plottables.DataLogger? _dlZber;
        private ScottPlot.Plottables.DataLogger? _dlCas;
        private ScottPlot.Plottables.DataLogger? _dlCasVRade;
        private ScottPlot.Plottables.DataLogger? _dlCasPasPred;
        private ScottPlot.Plottables.DataLogger? _dlCasPasZa;
        private ScottPlot.Plottables.DataLogger? _dlCasVRadeDetektor;
        private ScottPlot.Plottables.DataLogger? _dlCasVRadeZber;
        private ScottPlot.Plottables.DataLogger? _dlPasPred;
        private ScottPlot.Plottables.DataLogger? _dlPasZa;

        private readonly List<double> _dataRontgen          = new();
        private readonly List<double> _dataDetektor         = new();
        private readonly List<double> _dataZber             = new();
        private readonly List<double> _dataCas              = new();
        private readonly List<double> _dataCasVRade         = new();
        private readonly List<double> _dataCasPasPred       = new();
        private readonly List<double> _dataCasPasZa         = new();
        private readonly List<double> _dataCasVRadeDetektor = new();
        private readonly List<double> _dataCasVRadeZber     = new();
        private readonly List<double> _dataPasPred          = new();
        private readonly List<double> _dataPasZa            = new();

        private int _lastRepCount = 0;
        //2.2
        public SimulationForm()
        {
            InitializeComponent();
            BuildLayout();
            InitCharts();
        }
        //2.2
        private void BuildLayout()
        {
            Text        = "Globálne štatistiky simulácie";
            Size        = new Size(1400, 750);
            MinimumSize = new Size(1000, 500);

            var split = new SplitContainer { Dock = DockStyle.Fill };
            Load += (s, e) =>
            {
                split.Panel1MinSize    = 420;
                split.Panel2MinSize    = 300;
                split.SplitterDistance = 480;
            };

            var scrollPanel = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            scrollPanel.Controls.Add(BuildLabelsTable());
            split.Panel1.Controls.Add(scrollPanel);

            var tabs = new TabControl { Dock = DockStyle.Fill };
            AddChartTab(tabs, "Röntgen",              _chartRontgen);
            AddChartTab(tabs, "Detektor",             _chartDetektor);
            AddChartTab(tabs, "Zber prepraviek",      _chartZber);
            AddChartTab(tabs, "Čas v systéme",        _chartCas);
            AddChartTab(tabs, "Čas čakania – röntgen",_chartCasVRade);
            AddChartTab(tabs, "Čas čakania – detektor",_chartCasVRadeDetektor);
            AddChartTab(tabs, "Čas čakania – zber",   _chartCasVRadeZber);
            AddChartTab(tabs, "Čas pas pred",         _chartCasPasPred);
            AddChartTab(tabs, "Čas pas za",           _chartCasPasZa);
            AddChartTab(tabs, "Pas pred röntgenom",   _chartPasPred);
            AddChartTab(tabs, "Pas za röntgenom",     _chartPasZa);
            split.Panel2.Controls.Add(tabs);

            Controls.Add(split);
        }
        //2.2
        private TableLayoutPanel BuildLabelsTable()
        {
            var fTitle = new Font("Segoe UI", 9f);
            var fValue = new Font("Segoe UI", 9f, FontStyle.Bold);
            var fCi    = new Font("Segoe UI", 8.5f, FontStyle.Italic);
            var table  = new TableLayoutPanel
            {
                Dock        = DockStyle.Top,
                ColumnCount = 3,
                AutoSize    = true,
                Padding     = new Padding(10)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46));
            //2.2
            void Row(string title, Label val, Label? ci = null)
            {
                val.Text     = "—";
                val.Font     = fValue;
                val.Anchor   = AnchorStyles.Left;
                val.AutoSize = true;
                table.Controls.Add(new Label { Text = title, Font = fTitle, AutoSize = true, Anchor = AnchorStyles.Left });
                table.Controls.Add(val);
                if (ci != null)
                {
                    ci.Text      = "—";
                    ci.Font      = fCi;
                    ci.ForeColor = SystemColors.GrayText;
                    ci.Anchor    = AnchorStyles.Left;
                    ci.AutoSize  = true;
                    table.Controls.Add(ci);
                }
                else
                {
                    table.Controls.Add(new Label());
                }
            }

            Row("Počet replikácií:",                  _lblRepValue);
            Row("Čas v systéme (s):",               _lblCasVSystemeValue,        _lblCasVSystemeCi);
            Row("Čas čakania v rade – röntgen (s):", _lblCasVRadeValue,           _lblCasVRadeCi);
            Row("Čas čakania v rade – detektor (s):",_lblCasVRadeDetektorValue,   _lblCasVRadeDetektorCi);
            Row("Čas čakania v rade – zber (s):",   _lblCasVRadeZberomValue,      _lblCasVRadeZberomCi);
            Row("Čas čakania pas pred (s):",         _lblCasPasPredValue,         _lblCasPasPredCi);
            Row("Čas čakania pas za (s):",           _lblCasPasZaValue,           _lblCasPasZaCi);
            Row("Rad röntgen (spolu):",              _lblRadRontgenSpoluValue,    _lblRadRontgenSpoluCi);
            Row("Rad detektor (spolu):",             _lblRadDetektorSpoluValue,   _lblRadDetektorSpoluCi);
            Row("Rad zber (spolu):",                 _lblRadZberSpoluValue,       _lblRadZberSpoluCi);
            Row("Pas pred röntgenom (spolu):",       _lblPasPredSpoluValue,       _lblPasPredSpoluCi);
            Row("Pas za röntgenom (spolu):",         _lblPasZaSpoluValue,         _lblPasZaSpoluCi);

            return table;
        }
        //2.2
        private static string FormatCi(DIS_Semestralka_S2_Letisko.Simulation.Collectors.StatisticsCollector col)
        {
            var ci = col.GetConfidenceInterval();
            return ci.HasValue ? $"[{ci.Value.Lower:F4}; {ci.Value.Upper:F4}]" : "< 30 rep.";
        }
        //2.2
        private static void AddChartTab(TabControl tabs, string title, FormsPlot fp)
        {
            var page = new TabPage(title);
            fp.Dock = DockStyle.Fill;
            page.Controls.Add(fp);
            tabs.TabPages.Add(page);
        }
        //2.2
        private void InitCharts()
        {
            InitSingleChart(_chartRontgen,  "Rad pred röntgenom (priemer)",         out _dlRontgen,  Colors.Blue);
            InitSingleChart(_chartDetektor, "Rad pred detektorom kovu (priemer)",   out _dlDetektor, Colors.Orange);
            InitSingleChart(_chartZber,     "Rad pred zberom prepraviek (priemer)", out _dlZber,     Colors.Green);
            InitSingleChart(_chartPasPred,  "Pas pred röntgenom (priemer)",         out _dlPasPred,  Colors.SteelBlue);
            InitSingleChart(_chartPasZa,    "Pas za röntgenom (priemer)",           out _dlPasZa,    Colors.Teal);

            InitTimeChart(_chartCas,              "Priemerný čas v systéme",                         out _dlCas,              Colors.Purple);
            InitTimeChart(_chartCasVRade,         "Priemerný čas čakania v rade pred röntgenom",     out _dlCasVRade,         Colors.Crimson);
            InitTimeChart(_chartCasVRadeDetektor, "Priemerný čas čakania v rade pred detektorom",    out _dlCasVRadeDetektor, Colors.DarkOrange);
            InitTimeChart(_chartCasVRadeZber,     "Priemerný čas čakania v rade pred zberom",        out _dlCasVRadeZber,     Colors.DarkGreen);
            InitTimeChart(_chartCasPasPred,       "Priemerný čas čakania na páse pred röntgenom",    out _dlCasPasPred,       Colors.SlateBlue);
            InitTimeChart(_chartCasPasZa,         "Priemerný čas čakania na páse za röntgenom",      out _dlCasPasZa,         Colors.DarkCyan);
        }
        //2.2
        private static void InitSingleChart(
            FormsPlot fp, string title,
            out ScottPlot.Plottables.DataLogger dl,
            Color color)
        {
            fp.Plot.Clear();
            fp.Plot.Title(title);
            fp.Plot.XLabel("Replikácia");
            fp.Plot.YLabel("Priemerný počet (spolu)");
            dl = fp.Plot.Add.DataLogger();
            dl.Color = color;
            dl.ManageAxisLimits = false;
            fp.Plot.Axes.Margins(0, 0);
        }
        //2.2
        private static void InitTimeChart(
            FormsPlot fp, string title,
            out ScottPlot.Plottables.DataLogger dl,
            Color color)
        {
            fp.Plot.Clear();
            fp.Plot.Title(title);
            fp.Plot.XLabel("Replikácia");
            fp.Plot.YLabel("Čas (s)");
            dl = fp.Plot.Add.DataLogger();
            dl.Color = color;
            dl.ManageAxisLimits = false;
            fp.Plot.Axes.Margins(0, 0);
        }
        //2.2
        private FormsPlot[] AllCharts => new[] {
            _chartRontgen, _chartDetektor, _chartZber,
            _chartCas, _chartCasVRade, _chartCasVRadeDetektor, _chartCasVRadeZber,
            _chartCasPasPred, _chartCasPasZa,
            _chartPasPred, _chartPasZa
        };
        //2.2
        public void Reset()
        {
            _lastRepCount = 0;
            _dataRontgen.Clear(); _dataDetektor.Clear(); _dataZber.Clear();
            _dataCas.Clear(); _dataCasVRade.Clear(); _dataCasPasPred.Clear();
            _dataCasPasZa.Clear(); _dataCasVRadeDetektor.Clear();
            _dataCasVRadeZber.Clear(); _dataPasPred.Clear(); _dataPasZa.Clear();
            InitCharts();
            foreach (var fp in AllCharts) fp.Refresh();
        }
        //2.2
        private static void ApplyLimits(FormsPlot fp, List<double> data, double startX, double endX)
        {
            int from = (int)startX;
            if (from >= data.Count) { fp.Refresh(); return; }
            double lo = double.MaxValue, hi = double.MinValue;
            for (int i = from; i < data.Count; i++)
            {
                if (data[i] < lo) lo = data[i];
                if (data[i] > hi) hi = data[i];
            }
            if (lo == hi) { lo -= 0.5; hi += 0.5; }
            fp.Plot.Axes.SetLimits(startX, endX, lo, hi);
            fp.Refresh();
        }
        //2.2
        public void Update(LetiskoSimulation sim)
        {
            int rep = sim.GlobalAvgCasVSysteme.ValueCounter;

            _lblRepValue.Text                  = rep.ToString();
            _lblCasVSystemeValue.Text          = rep > 0 ? sim.GlobalAvgCasVSysteme.Average.ToString("F2")              : "—";
            _lblCasVRadeValue.Text             = rep > 0 ? sim.GlobalAvgCasVRadePredRontgenom.Average.ToString("F2")    : "—";
            _lblCasVRadeDetektorValue.Text     = rep > 0 ? sim.GlobalAvgCasVRadePredDetektorom.Average.ToString("F2")   : "—";
            _lblCasVRadeZberomValue.Text       = rep > 0 ? sim.GlobalAvgCasVRadePredZberom.Average.ToString("F2")       : "—";
            _lblCasPasPredValue.Text           = rep > 0 ? sim.GlobalAvgCasVPasPredRontgenom.Average.ToString("F2")     : "—";
            _lblCasPasZaValue.Text             = rep > 0 ? sim.GlobalAvgCasVPasZaRontgenom.Average.ToString("F2")       : "—";
            _lblRadRontgenSpoluValue.Text      = rep > 0 ? sim.GlobalAvgRadPredRontgenomSpolu.Average.ToString("F4")    : "—";
            _lblRadDetektorSpoluValue.Text     = rep > 0 ? sim.GlobalAvgRadPredDetektoromSpolu.Average.ToString("F4")   : "—";
            _lblRadZberSpoluValue.Text         = rep > 0 ? sim.GlobalAvgRadPredZberomSpolu.Average.ToString("F4")       : "—";
            _lblPasPredSpoluValue.Text         = rep > 0 ? sim.GlobalAvgPasPredRontgenomSpolu.Average.ToString("F4")    : "—";
            _lblPasZaSpoluValue.Text           = rep > 0 ? sim.GlobalAvgPasZaRontgenomSpolu.Average.ToString("F4")      : "—";

            _lblCasVSystemeCi.Text          = rep > 0 ? FormatCi(sim.GlobalAvgCasVSysteme)              : "—";
            _lblCasVRadeCi.Text             = rep > 0 ? FormatCi(sim.GlobalAvgCasVRadePredRontgenom)     : "—";
            _lblCasVRadeDetektorCi.Text     = rep > 0 ? FormatCi(sim.GlobalAvgCasVRadePredDetektorom)    : "—";
            _lblCasVRadeZberomCi.Text       = rep > 0 ? FormatCi(sim.GlobalAvgCasVRadePredZberom)        : "—";
            _lblCasPasPredCi.Text           = rep > 0 ? FormatCi(sim.GlobalAvgCasVPasPredRontgenom)      : "—";
            _lblCasPasZaCi.Text             = rep > 0 ? FormatCi(sim.GlobalAvgCasVPasZaRontgenom)        : "—";
            _lblRadRontgenSpoluCi.Text      = rep > 0 ? FormatCi(sim.GlobalAvgRadPredRontgenomSpolu)     : "—";
            _lblRadDetektorSpoluCi.Text     = rep > 0 ? FormatCi(sim.GlobalAvgRadPredDetektoromSpolu)    : "—";
            _lblRadZberSpoluCi.Text         = rep > 0 ? FormatCi(sim.GlobalAvgRadPredZberomSpolu)        : "—";
            _lblPasPredSpoluCi.Text         = rep > 0 ? FormatCi(sim.GlobalAvgPasPredRontgenomSpolu)     : "—";
            _lblPasZaSpoluCi.Text           = rep > 0 ? FormatCi(sim.GlobalAvgPasZaRontgenomSpolu)       : "—";

            while (_lastRepCount < rep)
            {
                _lastRepCount++;
                double vRontgen  = sim.GlobalAvgRadPredRontgenomSpolu.Average;
                double vDetektor = sim.GlobalAvgRadPredDetektoromSpolu.Average;
                double vZber     = sim.GlobalAvgRadPredZberomSpolu.Average;
                double vCas      = sim.GlobalAvgCasVSysteme.Average;
                double vCasVRade = sim.GlobalAvgCasVRadePredRontgenom.Average;
                double vCasDet   = sim.GlobalAvgCasVRadePredDetektorom.Average;
                double vCasZber  = sim.GlobalAvgCasVRadePredZberom.Average;
                double vCasPred  = sim.GlobalAvgCasVPasPredRontgenom.Average;
                double vCasZa    = sim.GlobalAvgCasVPasZaRontgenom.Average;
                double vPasPred  = sim.GlobalAvgPasPredRontgenomSpolu.Average;
                double vPasZa    = sim.GlobalAvgPasZaRontgenomSpolu.Average;

                _dlRontgen!.Add(vRontgen);          _dataRontgen.Add(vRontgen);
                _dlDetektor!.Add(vDetektor);        _dataDetektor.Add(vDetektor);
                _dlZber!.Add(vZber);                _dataZber.Add(vZber);
                _dlCas!.Add(vCas);                  _dataCas.Add(vCas);
                _dlCasVRade!.Add(vCasVRade);        _dataCasVRade.Add(vCasVRade);
                _dlCasVRadeDetektor!.Add(vCasDet);  _dataCasVRadeDetektor.Add(vCasDet);
                _dlCasVRadeZber!.Add(vCasZber);     _dataCasVRadeZber.Add(vCasZber);
                _dlCasPasPred!.Add(vCasPred);       _dataCasPasPred.Add(vCasPred);
                _dlCasPasZa!.Add(vCasZa);           _dataCasPasZa.Add(vCasZa);
                _dlPasPred!.Add(vPasPred);          _dataPasPred.Add(vPasPred);
                _dlPasZa!.Add(vPasZa);              _dataPasZa.Add(vPasZa);
            }

            double startX = rep * 0.4;
            ApplyLimits(_chartRontgen,          _dataRontgen,          startX, rep);
            ApplyLimits(_chartDetektor,         _dataDetektor,         startX, rep);
            ApplyLimits(_chartZber,             _dataZber,             startX, rep);
            ApplyLimits(_chartCas,              _dataCas,              startX, rep);
            ApplyLimits(_chartCasVRade,         _dataCasVRade,         startX, rep);
            ApplyLimits(_chartCasVRadeDetektor, _dataCasVRadeDetektor, startX, rep);
            ApplyLimits(_chartCasVRadeZber,     _dataCasVRadeZber,     startX, rep);
            ApplyLimits(_chartCasPasPred,       _dataCasPasPred,       startX, rep);
            ApplyLimits(_chartCasPasZa,         _dataCasPasZa,         startX, rep);
            ApplyLimits(_chartPasPred,          _dataPasPred,          startX, rep);
            ApplyLimits(_chartPasZa,            _dataPasZa,            startX, rep);
        }
    }
}
