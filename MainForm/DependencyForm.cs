using DIS_Semestralka_S2_Letisko.Simulation.Collectors;
using ScottPlot;
using ScottPlot.WinForms;
using Font      = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;
using Color     = ScottPlot.Color;

namespace MainForm
{
    //2.4
    public record DependencyResult(
        int    Cestujuci,
        double Lambda,
        double CasVSysteme,  (double Lower, double Upper)? CiCas,
        double RadRontgen,   (double Lower, double Upper)? CiRontgen,
        double RadZber,      (double Lower, double Upper)? CiZber
    );
    //2.4
    public partial class DependencyForm : Form
    {
        // ── Grid ─────────────────────────────────────────────────────────────
        private readonly DataGridView _grid = new();

        // ── Charts ───────────────────────────────────────────────────────────
        private readonly FormsPlot _chartCas     = new();
        private readonly FormsPlot _chartRontgen = new();
        private readonly FormsPlot _chartZber    = new();

        // ── Data ─────────────────────────────────────────────────────────────
        private readonly List<DependencyResult> _results = new();
        //2.4
        public DependencyForm()
        {
            InitializeComponent();
            BuildLayout();
        }

        // ── Layout ───────────────────────────────────────────────────────────
        //2.4
        private void BuildLayout()
        {
            Text        = "Test závislosti";
            Size        = new Size(1300, 720);
            MinimumSize = new Size(900, 500);

            var split = new SplitContainer { Dock = DockStyle.Fill };
            Load += (s, e) =>
            {
                split.Panel1MinSize    = 400;
                split.Panel2MinSize    = 300;
                split.SplitterDistance = 520;
            };

            BuildGrid();
            split.Panel1.Controls.Add(_grid);

            var tabs = new TabControl { Dock = DockStyle.Fill };
            AddChartTab(tabs, "Čas v systéme",   _chartCas);
            AddChartTab(tabs, "Röntgen (spolu)", _chartRontgen);
            AddChartTab(tabs, "Zber (spolu)",    _chartZber);
            split.Panel2.Controls.Add(tabs);

            Controls.Add(split);
        }
        //2.4
        private void BuildGrid()
        {
            _grid.Dock                          = DockStyle.Fill;
            _grid.ReadOnly                      = true;
            _grid.AllowUserToAddRows            = false;
            _grid.AllowUserToDeleteRows         = false;
            _grid.SelectionMode                 = DataGridViewSelectionMode.FullRowSelect;
            _grid.AutoSizeColumnsMode           = DataGridViewAutoSizeColumnsMode.Fill;
            _grid.RowHeadersVisible             = false;
            _grid.ColumnHeadersHeightSizeMode   = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _grid.Font                          = new Font("Segoe UI", 8.5f);
            _grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);

            void Col(string name, string header, int weight)
                => _grid.Columns.Add(new DataGridViewTextBoxColumn
                    { Name = name, HeaderText = header, FillWeight = weight });

            Col("Cestujuci",  "Ces./24h",    55);
            Col("Lambda",     "λ (/s)",      60);
            Col("Cas",        "Čas v sys.",  60);
            Col("CiCas",      "IS čas",     120);
            Col("Rontgen",    "Röntgen",     60);
            Col("CiRontgen",  "IS röntgen", 120);
            Col("Zber",       "Zber",        55);
            Col("CiZber",     "IS zber",    120);
        }
        //2.4
        private static void AddChartTab(TabControl tabs, string title, FormsPlot fp)
        {
            fp.Dock = DockStyle.Fill;
            var page = new TabPage(title);
            page.Controls.Add(fp);
            tabs.TabPages.Add(page);
        }

        // ── Public API ────────────────────────────────────────────────────────
        //2.4
        public void Reset()
        {
            _results.Clear();
            _grid.Rows.Clear();
            ClearCharts();
        }
        //2.4
        public void AddResult(DependencyResult r)
        {
            _results.Add(r);

            _grid.Rows.Add(
                r.Cestujuci.ToString(),
                r.Lambda.ToString("F6"),
                r.CasVSysteme.ToString("F2"),
                FormatCi(r.CiCas),
                r.RadRontgen.ToString("F4"),
                FormatCi(r.CiRontgen),
                r.RadZber.ToString("F4"),
                FormatCi(r.CiZber)
            );

            RefreshCharts();
        }

        // ── Charts ───────────────────────────────────────────────────────────
        //2.4
        private void ClearCharts()
        {
            foreach (var fp in new[] { _chartCas, _chartRontgen, _chartZber })
            {
                fp.Plot.Clear();
                fp.Refresh();
            }
        }
        //2.4
        private void RefreshCharts()
        {
            if (_results.Count == 0) { ClearCharts(); return; }

            double[] xs = _results.Select(r => (double)r.Cestujuci).ToArray();

            DrawChart(_chartCas,     "Priemerný čas v systéme",          "Čas (s)",      xs,
                _results.Select(r => r.CasVSysteme).ToArray(), Colors.Purple, hLine: 600);
            DrawChart(_chartRontgen, "Rad pred röntgenom (spolu)",        "Priem. počet", xs,
                _results.Select(r => r.RadRontgen).ToArray(),  Colors.Blue,   hLine: 20);
            DrawChart(_chartZber,    "Rad pred zberom prepraviek (spolu)","Priem. počet", xs,
                _results.Select(r => r.RadZber).ToArray(),     Colors.Green,  hLine: 10);
        }
        //2.4
        private static void DrawChart(
            FormsPlot fp, string title, string yLabel,
            double[] xs, double[] ys, Color color, double? hLine = null)
        {
            fp.Plot.Clear();
            fp.Plot.Title(title);
            fp.Plot.XLabel("Cestujúci za 24h");
            fp.Plot.YLabel(yLabel);

            if (xs.Length >= 1)
            {
                var scatter = fp.Plot.Add.Scatter(xs, ys);
                scatter.Color      = color;
                scatter.LineWidth  = 2;
                scatter.MarkerSize = 8;
            }

            if (hLine.HasValue)
            {
                var hl = fp.Plot.Add.HorizontalLine(hLine.Value);
                hl.Color       = Colors.Red;
                hl.LineWidth   = 1.5f;
                hl.LinePattern = ScottPlot.LinePattern.Dashed;
            }

            fp.Plot.Axes.AutoScale();
            fp.Refresh();
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        //2.4
        private static string FormatCi((double Lower, double Upper)? ci)
            => ci.HasValue ? $"[{ci.Value.Lower:F4}; {ci.Value.Upper:F4}]" : "< 30 rep.";
    }
}
