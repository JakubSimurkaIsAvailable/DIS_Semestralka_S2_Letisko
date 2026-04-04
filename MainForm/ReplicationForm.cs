using DIS_Semestralka_S2_Letisko.Letisko;
using ScottPlot;
using ScottPlot.WinForms;
using Label     = System.Windows.Forms.Label;
using Color     = ScottPlot.Color;
using Font      = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;

namespace MainForm
{
    public partial class ReplicationForm : Form
    {
        // ── Labels ───────────────────────────────────────────────────────────
        private readonly Label _lblRepValue             = new();
        private readonly Label _lblCasVSystemeValue     = new();
        private readonly Label _lblRadRontgen1Value     = new();
        private readonly Label _lblRadRontgen2Value     = new();
        private readonly Label _lblRadRontgenSpoluValue = new();
        private readonly Label _lblRadDetektor1Value    = new();
        private readonly Label _lblRadDetektor2Value    = new();
        private readonly Label _lblRadDetektorSpoluValue= new();
        private readonly Label _lblRadZber1Value        = new();
        private readonly Label _lblRadZber2Value        = new();
        private readonly Label _lblRadZberSpoluValue    = new();

        // ── Charts ───────────────────────────────────────────────────────────
        private readonly FormsPlot _chartRontgen  = new();
        private readonly FormsPlot _chartDetektor = new();
        private readonly FormsPlot _chartZber     = new();
        private readonly FormsPlot _chartCas      = new();

        // ── DataLoggers (owned by ScottPlot) ─────────────────────────────────
        private ScottPlot.Plottables.DataLogger? _dlRontgen;
        private ScottPlot.Plottables.DataLogger? _dlDetektor;
        private ScottPlot.Plottables.DataLogger? _dlZber;
        private ScottPlot.Plottables.DataLogger? _dlCas;

        private int _lastReplication = -1;

        public ReplicationForm()
        {
            InitializeComponent();
            BuildLayout();
            InitCharts();
        }

        // ── Layout ───────────────────────────────────────────────────────────

        private void BuildLayout()
        {
            Text           = "Štatistiky replikácie";
            Size           = new Size(1100, 720);
            MinimumSize    = new Size(800, 500);

            var split = new SplitContainer { Dock = DockStyle.Fill };
            Load += (s, e) =>
            {
                split.Panel1MinSize    = 280;
                split.Panel2MinSize    = 200;
                split.SplitterDistance = 330;
            };

            // Left – labels
            var scrollPanel = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            scrollPanel.Controls.Add(BuildLabelsTable());
            split.Panel1.Controls.Add(scrollPanel);

            // Right – charts
            var tabs = new TabControl { Dock = DockStyle.Fill };
            AddChartTab(tabs, "Röntgen",          _chartRontgen);
            AddChartTab(tabs, "Detektor",          _chartDetektor);
            AddChartTab(tabs, "Zber prepraviek",   _chartZber);
            AddChartTab(tabs, "Čas v systéme",     _chartCas);
            split.Panel2.Controls.Add(tabs);

            Controls.Add(split);
        }

        private TableLayoutPanel BuildLabelsTable()
        {
            var fTitle  = new Font("Segoe UI", 9f);
            var fValue  = new Font("Segoe UI", 9f, FontStyle.Bold);
            var table   = new TableLayoutPanel
            {
                Dock        = DockStyle.Top,
                ColumnCount = 2,
                AutoSize    = true,
                Padding     = new Padding(10)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));

            void Row(string title, Label val)
            {
                val.Text   = "—";
                val.Font   = fValue;
                val.Anchor = AnchorStyles.Left;
                table.Controls.Add(new Label { Text = title, Font = fTitle, AutoSize = true, Anchor = AnchorStyles.Left });
                table.Controls.Add(val);
            }

            Row("Replikácia:",              _lblRepValue);
            Row("Čas v systéme (s):",       _lblCasVSystemeValue);
            Row("Rad röntgen 1:",           _lblRadRontgen1Value);
            Row("Rad röntgen 2:",           _lblRadRontgen2Value);
            Row("Rad röntgen (spolu):",     _lblRadRontgenSpoluValue);
            Row("Rad detektor 1:",          _lblRadDetektor1Value);
            Row("Rad detektor 2:",          _lblRadDetektor2Value);
            Row("Rad detektor (spolu):",    _lblRadDetektorSpoluValue);
            Row("Rad zber 1:",              _lblRadZber1Value);
            Row("Rad zber 2:",              _lblRadZber2Value);
            Row("Rad zber (spolu):",        _lblRadZberSpoluValue);

            return table;
        }

        private static void AddChartTab(TabControl tabs, string title, FormsPlot fp)
        {
            var page = new TabPage(title);
            fp.Dock = DockStyle.Fill;
            page.Controls.Add(fp);
            tabs.TabPages.Add(page);
        }

        // ── Chart initialisation (called on each new replication) ─────────────

        private void InitCharts()
        {
            InitSingleChart(_chartRontgen,  "Rad pred röntgenom",         out _dlRontgen,  Colors.Blue);
            InitSingleChart(_chartDetektor, "Rad pred detektorom kovu",   out _dlDetektor, Colors.Orange);
            InitSingleChart(_chartZber,     "Rad pred zberom prepraviek", out _dlZber,     Colors.Green);

            _chartCas.Plot.Clear();
            _chartCas.Plot.Title("Priemerný čas v systéme");
            _chartCas.Plot.YLabel("Čas (s)");
            _dlCas = _chartCas.Plot.Add.DataLogger();
            _dlCas.Color = Colors.Purple;
        }

        private static void InitSingleChart(
            FormsPlot fp, string title,
            out ScottPlot.Plottables.DataLogger dl,
            Color color)
        {
            fp.Plot.Clear();
            fp.Plot.Title(title);
            fp.Plot.YLabel("Počet cestujúcich (spolu)");
            dl = fp.Plot.Add.DataLogger();
            dl.Color = color;
        }

        // ── Public update (called from Form1 only when NOT max speed) ─────────

        public void Update(LetiskoSimulation sim)
        {
            // Detect new replication → reset charts
            if (sim.CurrentReplication != _lastReplication)
            {
                _lastReplication = sim.CurrentReplication;
                InitCharts();
            }

            // Labels
            _lblRepValue.Text              = sim.CurrentReplication.ToString();
            _lblCasVSystemeValue.Text      = sim.CasVSystemeCollector.Average.ToString("F2");
            _lblRadRontgen1Value.Text      = sim.PocetVRadePredRontgenom1.WeightedAverage.ToString("F4");
            _lblRadRontgen2Value.Text      = sim.PocetVRadePredRontgenom2.WeightedAverage.ToString("F4");
            _lblRadRontgenSpoluValue.Text  = sim.PocetVRadePredRontgenomSpolu.WeightedAverage.ToString("F4");
            _lblRadDetektor1Value.Text     = sim.PocetVRadePredDetektorom1.WeightedAverage.ToString("F4");
            _lblRadDetektor2Value.Text     = sim.PocetVRadePredDetektorom2.WeightedAverage.ToString("F4");
            _lblRadDetektorSpoluValue.Text = sim.PocetVRadePredDetektoromSpolu.WeightedAverage.ToString("F4");
            _lblRadZber1Value.Text         = sim.PocetVRadePredZberom1.WeightedAverage.ToString("F4");
            _lblRadZber2Value.Text         = sim.PocetVRadePredZberom2.WeightedAverage.ToString("F4");
            _lblRadZberSpoluValue.Text     = sim.PocetVRadePredZberomSpolu.WeightedAverage.ToString("F4");

            // Push combined queue counts directly into ScottPlot
            _dlRontgen!.Add(sim.RadPredRontgenom1.Count + sim.RadPredRontgenom2.Count);
            _dlDetektor!.Add(sim.RadPredDetektorom1.Count + sim.RadPredDetektorom2.Count);
            _dlZber!.Add(sim.RadPredZberomPrepraviek1.Count + sim.RadPredZberomPrepraviek2.Count);
            _dlCas!.Add(sim.CasVSystemeCollector.Average);

            _chartRontgen.Refresh();
            _chartDetektor.Refresh();
            _chartZber.Refresh();
            _chartCas.Refresh();
        }
    }
}
