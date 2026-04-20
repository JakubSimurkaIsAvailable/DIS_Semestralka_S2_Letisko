using DIS_Semestralka_S2_Letisko.Letisko;
using ScottPlot;
using ScottPlot.WinForms;
using Label     = System.Windows.Forms.Label;
using Color     = ScottPlot.Color;
using Font      = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;

namespace MainForm
{
    //2.3
    public partial class ReplicationForm : Form
    {
        // ── Labels ───────────────────────────────────────────────────────────
        private readonly Label _lblRepValue                   = new();
        private readonly Label _lblCasVSystemeValue           = new();
        private readonly Label _lblCasVRadeRontgenValue       = new();
        private readonly Label _lblCasVRadeDetektorValue      = new();
        private readonly Label _lblCasVRadeZberValue          = new();
        private readonly Label _lblCasVPasPredValue           = new();
        private readonly Label _lblCasVPasZaValue             = new();
        private readonly Label _lblRadRontgenSpoluValue       = new();
        private readonly Label _lblRadDetektorSpoluValue      = new();
        private readonly Label _lblRadZberSpoluValue          = new();
        private readonly Label _lblPasPredSpoluValue          = new();
        private readonly Label _lblPasZaSpoluValue            = new();

        // ── Charts ───────────────────────────────────────────────────────────
        private readonly FormsPlot _chartRontgen  = new();
        private readonly FormsPlot _chartDetektor = new();
        private readonly FormsPlot _chartZber     = new();
        private readonly FormsPlot _chartCas      = new();
        private readonly FormsPlot _chartCasVRade = new();
        private readonly FormsPlot _chartPasPred  = new();
        private readonly FormsPlot _chartPasZa    = new();

        // ── DataLoggers ──────────────────────────────────────────────────────
        private ScottPlot.Plottables.DataLogger? _dlRontgen;
        private ScottPlot.Plottables.DataLogger? _dlDetektor;
        private ScottPlot.Plottables.DataLogger? _dlZber;
        private ScottPlot.Plottables.DataLogger? _dlCas;
        private ScottPlot.Plottables.DataLogger? _dlCasVRade;
        private ScottPlot.Plottables.DataLogger? _dlPasPred;
        private ScottPlot.Plottables.DataLogger? _dlPasZa;

        private static readonly (double Min, double Max) NoData = (double.MaxValue, double.MinValue);
        private (double Min, double Max) _limRontgen  = NoData;
        private (double Min, double Max) _limDetektor = NoData;
        private (double Min, double Max) _limZber     = NoData;
        private (double Min, double Max) _limCas      = NoData;
        private (double Min, double Max) _limCasVRade = NoData;
        private (double Min, double Max) _limPasPred  = NoData;
        private (double Min, double Max) _limPasZa    = NoData;

        private int _tickCount       = 0;
        private int _lastReplication = -1;
        //2.3
        public ReplicationForm()
        {
            InitializeComponent();
            BuildLayout();
            InitCharts();
        }
        //2.3
        private void BuildLayout()
        {
            Text        = "Štatistiky replikácie";
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
            AddChartTab(tabs, "Röntgen",           _chartRontgen);
            AddChartTab(tabs, "Detektor",           _chartDetektor);
            AddChartTab(tabs, "Zber prepraviek",    _chartZber);
            AddChartTab(tabs, "Čas v systéme",      _chartCas);
            AddChartTab(tabs, "Čas čakania v rade", _chartCasVRade);
            AddChartTab(tabs, "Pas pred röntgenom", _chartPasPred);
            AddChartTab(tabs, "Pas za röntgenom",   _chartPasZa);
            split.Panel2.Controls.Add(tabs);

            Controls.Add(split);
        }
        //2.3
        private TableLayoutPanel BuildLabelsTable()
        {
            var fTitle = new Font("Segoe UI", 9f);
            var fValue = new Font("Segoe UI", 9f, FontStyle.Bold);
            var table  = new TableLayoutPanel
            {
                Dock        = DockStyle.Top,
                ColumnCount = 2,
                AutoSize    = true,
                Padding     = new Padding(10)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));

            void Row(string title, Label val)
            {
                val.Text   = "—";
                val.Font   = fValue;
                val.Anchor = AnchorStyles.Left;
                table.Controls.Add(new Label { Text = title, Font = fTitle, AutoSize = true, Anchor = AnchorStyles.Left });
                table.Controls.Add(val);
            }

            Row("Replikácia:",                        _lblRepValue);
            Row("Čas v systéme (s):",               _lblCasVSystemeValue);
            Row("Čas čakania pred röntgenom (s):",  _lblCasVRadeRontgenValue);
            Row("Čas čakania pred detektorom (s):", _lblCasVRadeDetektorValue);
            Row("Čas čakania pred zberom (s):",     _lblCasVRadeZberValue);
            Row("Čas na pase pred röntgenom (s):",  _lblCasVPasPredValue);
            Row("Čas na pase za röntgenom (s):",    _lblCasVPasZaValue);
            Row("Rad röntgen (spolu):",              _lblRadRontgenSpoluValue);
            Row("Rad detektor (spolu):",             _lblRadDetektorSpoluValue);
            Row("Rad zber (spolu):",                 _lblRadZberSpoluValue);
            Row("Pas pred röntgenom (spolu):",       _lblPasPredSpoluValue);
            Row("Pas za röntgenom (spolu):",         _lblPasZaSpoluValue);

            return table;
        }
        //2.3
        private static void AddChartTab(TabControl tabs, string title, FormsPlot fp)
        {
            var page = new TabPage(title);
            fp.Dock = DockStyle.Fill;
            page.Controls.Add(fp);
            tabs.TabPages.Add(page);
        }
        //2.3
        private void InitCharts()
        {
            InitSingleChart(_chartRontgen,  "Rad pred röntgenom",          out _dlRontgen,  Colors.Blue);
            InitSingleChart(_chartDetektor, "Rad pred detektorom kovu",    out _dlDetektor, Colors.Orange);
            InitSingleChart(_chartZber,     "Rad pred zberom prepraviek",  out _dlZber,     Colors.Green);
            InitSingleChart(_chartPasPred,  "Pas pred röntgenom",          out _dlPasPred,  Colors.SteelBlue);
            InitSingleChart(_chartPasZa,    "Pas za röntgenom",            out _dlPasZa,    Colors.Teal);

            _chartCas.Plot.Clear();
            _chartCas.Plot.Title("Priemerný čas v systéme");
            _chartCas.Plot.YLabel("Čas (s)");
            _dlCas = _chartCas.Plot.Add.DataLogger();
            _dlCas.Color = Colors.Purple;
            _dlCas.ManageAxisLimits = false;
            _chartCas.Plot.Axes.Margins(0, 0);

            _chartCasVRade.Plot.Clear();
            _chartCasVRade.Plot.Title("Priemerný čas čakania v rade");
            _chartCasVRade.Plot.YLabel("Čas (s)");
            _dlCasVRade = _chartCasVRade.Plot.Add.DataLogger();
            _dlCasVRade.Color = Colors.Crimson;
            _dlCasVRade.ManageAxisLimits = false;
            _chartCasVRade.Plot.Axes.Margins(0, 0);
        }
        //2.3
        private static void InitSingleChart(
            FormsPlot fp, string title,
            out ScottPlot.Plottables.DataLogger dl,
            Color color)
        {
            fp.Plot.Clear();
            fp.Plot.Title(title);
            fp.Plot.YLabel("Počet prepraviek / cestujúcich (spolu)");
            dl = fp.Plot.Add.DataLogger();
            dl.Color = color;
            dl.ManageAxisLimits = false;
            fp.Plot.Axes.Margins(0, 0);
        }

        private static (double Min, double Max) Track((double Min, double Max) lim, double v)
            => (Math.Min(lim.Min, v), Math.Max(lim.Max, v));

        private static void ApplyLimits(FormsPlot fp, (double Min, double Max) lim, int count)
        {
            if (lim.Min > lim.Max) { fp.Refresh(); return; }
            double lo = lim.Min, hi = lim.Max;
            if (lo == hi) { lo -= 0.5; hi += 0.5; }
            fp.Plot.Axes.SetLimits(0, count, lo, hi);
            fp.Refresh();
        }
        //2.3
        public void Update(LetiskoSimulation sim)
        {
            if (sim.CurrentReplication != _lastReplication)
            {
                _lastReplication = sim.CurrentReplication;
                _tickCount = 0;
                _limRontgen = _limDetektor = _limZber =
                    _limCas = _limCasVRade = _limPasPred = _limPasZa = NoData;
                InitCharts();
            }

            _lblRepValue.Text                  = sim.CurrentReplication.ToString();
            _lblCasVSystemeValue.Text          = sim.CasVSystemeCollector.Average.ToString("F2");
            _lblCasVRadeRontgenValue.Text      = sim.CasVRadePredRontgenomCollector.Average.ToString("F2");
            _lblCasVRadeDetektorValue.Text     = sim.CasVRadePredDetektoromCollector.Average.ToString("F2");
            _lblCasVRadeZberValue.Text         = sim.CasVRadePredZberomCollector.Average.ToString("F2");
            _lblCasVPasPredValue.Text          = sim.CasVPasPredRontgenomCollector.Average.ToString("F2");
            _lblCasVPasZaValue.Text            = sim.CasVPasZaRontgenomCollector.Average.ToString("F2");
            _lblRadRontgenSpoluValue.Text      = sim.PocetVRadePredRontgenomSpolu.WeightedAverage.ToString("F4");
            _lblRadDetektorSpoluValue.Text     = sim.PocetVRadePredDetektoromSpolu.WeightedAverage.ToString("F4");
            _lblRadZberSpoluValue.Text         = sim.PocetVRadePredZberomSpolu.WeightedAverage.ToString("F4");
            _lblPasPredSpoluValue.Text         = sim.PocetVPasPredRontgenomSpolu.WeightedAverage.ToString("F4");
            _lblPasZaSpoluValue.Text           = sim.PocetVPasZaRontgenomSpolu.WeightedAverage.ToString("F4");

            double vRontgen  = sim.RadPredRontgenom1.Count + sim.RadPredRontgenom2.Count;
            double vDetektor = sim.RadPredDetektorom1.Count + sim.RadPredDetektorom2.Count;
            double vZber     = sim.RadPredZberomPrepraviek1.Count + sim.RadPredZberomPrepraviek2.Count;
            double vCas      = sim.CasVSystemeCollector.Average;
            double vCasVRade = sim.CasVRadePredRontgenomCollector.Average;
            double vPasPred  = sim.Rontgen1.PocetPrepraviekPred + sim.Rontgen2.PocetPrepraviekPred;
            double vPasZa    = sim.Rontgen1.PocetPrepraviekZa + sim.Rontgen2.PocetPrepraviekZa;

            _dlRontgen!.Add(vRontgen);   _limRontgen  = Track(_limRontgen,  vRontgen);
            _dlDetektor!.Add(vDetektor); _limDetektor = Track(_limDetektor, vDetektor);
            _dlZber!.Add(vZber);         _limZber     = Track(_limZber,     vZber);
            _dlCas!.Add(vCas);           _limCas      = Track(_limCas,      vCas);
            _dlCasVRade!.Add(vCasVRade); _limCasVRade = Track(_limCasVRade, vCasVRade);
            _dlPasPred!.Add(vPasPred);   _limPasPred  = Track(_limPasPred,  vPasPred);
            _dlPasZa!.Add(vPasZa);       _limPasZa    = Track(_limPasZa,    vPasZa);
            _tickCount++;

            ApplyLimits(_chartRontgen,  _limRontgen,  _tickCount);
            ApplyLimits(_chartDetektor, _limDetektor, _tickCount);
            ApplyLimits(_chartZber,     _limZber,     _tickCount);
            ApplyLimits(_chartCas,      _limCas,      _tickCount);
            ApplyLimits(_chartCasVRade, _limCasVRade, _tickCount);
            ApplyLimits(_chartPasPred,  _limPasPred,  _tickCount);
            ApplyLimits(_chartPasZa,    _limPasZa,    _tickCount);
        }
    }
}
