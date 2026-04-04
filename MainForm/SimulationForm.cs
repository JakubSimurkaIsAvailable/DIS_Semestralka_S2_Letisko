using DIS_Semestralka_S2_Letisko.Letisko;
using ScottPlot;
using ScottPlot.WinForms;
using Label     = System.Windows.Forms.Label;
using Color     = ScottPlot.Color;
using Font      = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;

namespace MainForm
{
    public partial class SimulationForm : Form
    {
        // ── Labels ───────────────────────────────────────────────────────────
        private readonly Label _lblRepValue              = new();
        private readonly Label _lblCasVSystemeValue      = new();
        private readonly Label _lblRadRontgenSpoluValue  = new();
        private readonly Label _lblRadDetektorSpoluValue = new();
        private readonly Label _lblRadZberSpoluValue     = new();

        // ── CI labels ────────────────────────────────────────────────────────
        private readonly Label _lblCasVSystemeCi      = new();
        private readonly Label _lblRadRontgenSpoluCi  = new();
        private readonly Label _lblRadDetektorSpoluCi = new();
        private readonly Label _lblRadZberSpoluCi     = new();

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

        private int _lastRepCount = 0;

        public SimulationForm()
        {
            InitializeComponent();
            BuildLayout();
            InitCharts();
        }

        // ── Layout ───────────────────────────────────────────────────────────

        private void BuildLayout()
        {
            Text        = "Globálne štatistiky simulácie";
            Size        = new Size(1100, 720);
            MinimumSize = new Size(800, 500);

            var split = new SplitContainer { Dock = DockStyle.Fill };
            Load += (s, e) =>
            {
                split.Panel1MinSize    = 280;
                split.Panel2MinSize    = 200;
                split.SplitterDistance = 330;
            };

            var scrollPanel = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            scrollPanel.Controls.Add(BuildLabelsTable());
            split.Panel1.Controls.Add(scrollPanel);

            var tabs = new TabControl { Dock = DockStyle.Fill };
            AddChartTab(tabs, "Röntgen",        _chartRontgen);
            AddChartTab(tabs, "Detektor",        _chartDetektor);
            AddChartTab(tabs, "Zber prepraviek", _chartZber);
            AddChartTab(tabs, "Čas v systéme",   _chartCas);
            split.Panel2.Controls.Add(tabs);

            Controls.Add(split);
        }

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
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));

            void Row(string title, Label val, Label? ci = null)
            {
                val.Text   = "—";
                val.Font   = fValue;
                val.Anchor = AnchorStyles.Left;
                table.Controls.Add(new Label { Text = title, Font = fTitle, AutoSize = true, Anchor = AnchorStyles.Left });
                table.Controls.Add(val);
                if (ci != null)
                {
                    ci.Text      = "—";
                    ci.Font      = fCi;
                    ci.ForeColor = SystemColors.GrayText;
                    ci.Anchor    = AnchorStyles.Left;
                    table.Controls.Add(ci);
                }
                else
                {
                    table.Controls.Add(new Label());
                }
            }

            Row("Počet replikácií:",          _lblRepValue);
            Row("Čas v systéme (s):",         _lblCasVSystemeValue,     _lblCasVSystemeCi);
            Row("Rad röntgen (spolu):",        _lblRadRontgenSpoluValue, _lblRadRontgenSpoluCi);
            Row("Rad detektor (spolu):",       _lblRadDetektorSpoluValue,_lblRadDetektorSpoluCi);
            Row("Rad zber (spolu):",           _lblRadZberSpoluValue,    _lblRadZberSpoluCi);

            return table;
        }

        private static string FormatCi(DIS_Semestralka_S2_Letisko.Simulation.Collectors.StatisticsCollector col)
        {
            var ci = col.GetConfidenceInterval();
            return ci.HasValue ? $"[{ci.Value.Lower:F4}; {ci.Value.Upper:F4}]" : "< 30 rep.";
        }

        private static void AddChartTab(TabControl tabs, string title, FormsPlot fp)
        {
            var page = new TabPage(title);
            fp.Dock = DockStyle.Fill;
            page.Controls.Add(fp);
            tabs.TabPages.Add(page);
        }

        // ── Chart initialisation ──────────────────────────────────────────────

        private void InitCharts()
        {
            InitSingleChart(_chartRontgen,  "Rad pred röntgenom (priemer)",         out _dlRontgen,  Colors.Blue);
            InitSingleChart(_chartDetektor, "Rad pred detektorom kovu (priemer)",   out _dlDetektor, Colors.Orange);
            InitSingleChart(_chartZber,     "Rad pred zberom prepraviek (priemer)", out _dlZber,     Colors.Green);

            _chartCas.Plot.Clear();
            _chartCas.Plot.Title("Priemerný čas v systéme");
            _chartCas.Plot.XLabel("Replikácia");
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
            fp.Plot.XLabel("Replikácia");
            fp.Plot.YLabel("Priemerný počet (spolu)");
            dl = fp.Plot.Add.DataLogger();
            dl.Color = color;
        }

        // ── Public API ────────────────────────────────────────────────────────

        public void Reset()
        {
            _lastRepCount = 0;
            InitCharts();
            _chartRontgen.Refresh();
            _chartDetektor.Refresh();
            _chartZber.Refresh();
            _chartCas.Refresh();
        }

        public void Update(LetiskoSimulation sim)
        {
            int rep = sim.GlobalAvgCasVSysteme.ValueCounter;

            _lblRepValue.Text             = rep.ToString();
            _lblCasVSystemeValue.Text     = rep > 0 ? sim.GlobalAvgCasVSysteme.Average.ToString("F2")            : "—";
            _lblRadRontgenSpoluValue.Text = rep > 0 ? sim.GlobalAvgRadPredRontgenomSpolu.Average.ToString("F4")  : "—";
            _lblRadDetektorSpoluValue.Text= rep > 0 ? sim.GlobalAvgRadPredDetektoromSpolu.Average.ToString("F4") : "—";
            _lblRadZberSpoluValue.Text    = rep > 0 ? sim.GlobalAvgRadPredZberomSpolu.Average.ToString("F4")     : "—";

            _lblCasVSystemeCi.Text      = rep > 0 ? FormatCi(sim.GlobalAvgCasVSysteme)              : "—";
            _lblRadRontgenSpoluCi.Text  = rep > 0 ? FormatCi(sim.GlobalAvgRadPredRontgenomSpolu)     : "—";
            _lblRadDetektorSpoluCi.Text = rep > 0 ? FormatCi(sim.GlobalAvgRadPredDetektoromSpolu)    : "—";
            _lblRadZberSpoluCi.Text     = rep > 0 ? FormatCi(sim.GlobalAvgRadPredZberomSpolu)        : "—";

            while (_lastRepCount < rep)
            {
                _lastRepCount++;
                _dlRontgen!.Add(sim.GlobalAvgRadPredRontgenomSpolu.Average);
                _dlDetektor!.Add(sim.GlobalAvgRadPredDetektoromSpolu.Average);
                _dlZber!.Add(sim.GlobalAvgRadPredZberomSpolu.Average);
                _dlCas!.Add(sim.GlobalAvgCasVSysteme.Average);
            }

            _chartRontgen.Plot.Axes.AutoScale();
            _chartRontgen.Refresh();
            _chartDetektor.Plot.Axes.AutoScale();
            _chartDetektor.Refresh();
            _chartZber.Plot.Axes.AutoScale();
            _chartZber.Refresh();
            _chartCas.Plot.Axes.AutoScale();
            _chartCas.Refresh();
        }
    }
}
