using DIS_Semestralka_S2_Letisko.Generators;
using DIS_Semestralka_S2_Letisko.Generators.Components;
using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Arrival;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
using DIS_Semestralka_S2_Letisko.Simulation.Collectors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko
{
    public class LetiskoSimulation : Event_Core
    {
        // Synchronization lock for thread-safe queue access
        // 2.1.9
        public readonly object QueueAccessLock = new();

        // Generatory
        public Random GeneratorGeneratorov { get; private set; }
        public RozdelenieSpojite GeneratorRontgenPrepravky { get; private set; }
        public ExponencialnyGenerator GeneratorPrichodov { get; private set; }
        public RozdelenieSpojite GeneratorDetektor { get; private set; }
        public TrojuholnikovyGenerator GeneratorDodatocnejPrehliadky { get; private set; }
        public PercentTable GeneratorPercentTable { get; private set; }
        public int PocetCestujucich { get; set; }

        // --------= Terminal 1 =--------
        public Queue<Cestujuci> RadPredRontgenom1 { get; private set; }
        public Rontgen Rontgen1 { get; private set; }
        public Queue<Cestujuci> RadPredDetektorom1 { get; private set; }
        public DetektorKovu Detektor1 { get; private set; }
        public Queue<Cestujuci> RadPredZberomPrepraviek1 { get; private set; }
        public bool ZberPrepraviek1Volny { get; set; }

        // ------------------------------

        // --------= Terminal 2 =--------
        public Queue<Cestujuci> RadPredRontgenom2 { get; private set; }
        public Rontgen Rontgen2 { get; private set; }
        public Queue<Cestujuci> RadPredDetektorom2 { get; private set; }
        public DetektorKovu Detektor2 { get; private set; }
        public Queue<Cestujuci> RadPredZberomPrepraviek2 { get; private set; }
        public bool ZberPrepraviek2Volny { get; set; }
        // ------------------------------

        //2.5.1
        // --------= Statistiky (per replikacia) =--------
        public WeightedStatisticsCollector PocetVRadePredRontgenom1 { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredRontgenom2 { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredDetektorom1 { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredDetektorom2 { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredZberom1 { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredZberom2 { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredRontgenomSpolu { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredDetektoromSpolu { get; private set; }
        public WeightedStatisticsCollector PocetVRadePredZberomSpolu { get; private set; }
        // Pasy (vstupný / výstupný pas röntgenu)
        public WeightedStatisticsCollector PocetVPasPredRontgenom1 { get; private set; }
        public WeightedStatisticsCollector PocetVPasPredRontgenom2 { get; private set; }
        public WeightedStatisticsCollector PocetVPasPredRontgenomSpolu { get; private set; }
        public WeightedStatisticsCollector PocetVPasZaRontgenom1 { get; private set; }
        public WeightedStatisticsCollector PocetVPasZaRontgenom2 { get; private set; }
        public WeightedStatisticsCollector PocetVPasZaRontgenomSpolu { get; private set; }
        public StatisticsCollector CasVSystemeCollector { get; private set; }
        public StatisticsCollector CasVRadePredRontgenomCollector { get; private set; }
        public StatisticsCollector CasVRadePredDetektoromCollector { get; private set; }
        public StatisticsCollector CasVRadePredZberomCollector { get; private set; }
        public StatisticsCollector CasVPasPredRontgenomCollector { get; private set; }
        public StatisticsCollector CasVPasZaRontgenomCollector { get; private set; }
        // -----------------------------------------------
        //2.5.1
        // --------= Globalne statistiky (napriec replikaciami) =--------
        public StatisticsCollector GlobalAvgRadPredRontgenom1 { get; private set; }
        public StatisticsCollector GlobalAvgRadPredRontgenom2 { get; private set; }
        public StatisticsCollector GlobalAvgRadPredDetektorom1 { get; private set; }
        public StatisticsCollector GlobalAvgRadPredDetektorom2 { get; private set; }
        public StatisticsCollector GlobalAvgRadPredZberom1 { get; private set; }
        public StatisticsCollector GlobalAvgRadPredZberom2 { get; private set; }
        public StatisticsCollector GlobalAvgRadPredRontgenomSpolu { get; private set; }
        public StatisticsCollector GlobalAvgRadPredDetektoromSpolu { get; private set; }
        public StatisticsCollector GlobalAvgRadPredZberomSpolu { get; private set; }
        public StatisticsCollector GlobalAvgPasPredRontgenom1 { get; private set; }
        public StatisticsCollector GlobalAvgPasPredRontgenom2 { get; private set; }
        public StatisticsCollector GlobalAvgPasPredRontgenomSpolu { get; private set; }
        public StatisticsCollector GlobalAvgPasZaRontgenom1 { get; private set; }
        public StatisticsCollector GlobalAvgPasZaRontgenom2 { get; private set; }
        public StatisticsCollector GlobalAvgPasZaRontgenomSpolu { get; private set; }
        public StatisticsCollector GlobalAvgCasVSysteme { get; private set; }
        public StatisticsCollector GlobalAvgCasVRadePredRontgenom { get; private set; }
        public StatisticsCollector GlobalAvgCasVRadePredDetektorom { get; private set; }
        public StatisticsCollector GlobalAvgCasVRadePredZberom { get; private set; }
        public StatisticsCollector GlobalAvgCasVPasPredRontgenom { get; private set; }
        public StatisticsCollector GlobalAvgCasVPasZaRontgenom { get; private set; }
        // --------------------------------------------------------------

        // Trvanie jednej replikácie v sekundách (bez warmup). Default = 1 deň.
        public double SimDuration { get; set; } = 86400;

        // Ak je nastavené, ECollectData zapisuje pozorovania pre Welchovu analýzu.
        public TextWriter? CsvOutput { get; set; }
        // Interval zberu v sekundách (0 = vypnutý).
        public double CollectInterval { get; set; } = 0;
        private int _obsIndex;

        public LetiskoSimulation(double lambda, int? seed = null)
        {
            // ----------------------- Generatory ----------------------
            GeneratorGeneratorov = seed.HasValue ? new Random(seed.Value) : new Random();
            GeneratorRontgenPrepravky = new RozdelenieSpojite(GeneratorGeneratorov, 9, 46);
            GeneratorPrichodov = new ExponencialnyGenerator(GeneratorGeneratorov, lambda);
            GeneratorDetektor = new RozdelenieSpojite(GeneratorGeneratorov, 6, 27);
            GeneratorDodatocnejPrehliadky = new TrojuholnikovyGenerator(GeneratorGeneratorov, 10, 35, 120);
            double[] pravdepodobnosti = new double[] { 0.15, 0.68, 0.17 };
            double[] hodnoty = new double[] { 0, 1, 2 };
            GeneratorPercentTable = new PercentTable(GeneratorGeneratorov, pravdepodobnosti, hodnoty);
            //---------------------- Terminal 1 -----------------
            RadPredRontgenom1 = new Queue<Cestujuci>();
            Rontgen1 = new Rontgen(4, 5);
            RadPredDetektorom1 = new Queue<Cestujuci>();
            Detektor1 = new DetektorKovu();
            RadPredZberomPrepraviek1 = new Queue<Cestujuci>();
            ZberPrepraviek1Volny = true;
            //---------------------- Terminal 2 -----------------
            RadPredRontgenom2 = new Queue<Cestujuci>();
            Rontgen2 = new Rontgen(4, 5);
            RadPredDetektorom2 = new Queue<Cestujuci>();
            Detektor2 = new DetektorKovu();
            RadPredZberomPrepraviek2 = new Queue<Cestujuci>();
            ZberPrepraviek2Volny = true;
            TimeLimit = 60 * 60 * 24; //60 sekund * 60 minut * 24 hodin = 1 den
            //2.5.1
            //---------------------- Per-replikacia statistiky (inicialne) -----------------
            PocetVRadePredRontgenom1 = new WeightedStatisticsCollector();
            PocetVRadePredRontgenom2 = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom1 = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom2 = new WeightedStatisticsCollector();
            PocetVRadePredZberom1 = new WeightedStatisticsCollector();
            PocetVRadePredZberom2 = new WeightedStatisticsCollector();
            PocetVRadePredRontgenomSpolu = new WeightedStatisticsCollector();
            PocetVRadePredDetektoromSpolu = new WeightedStatisticsCollector();
            PocetVRadePredZberomSpolu = new WeightedStatisticsCollector();
            PocetVPasPredRontgenom1 = new WeightedStatisticsCollector();
            PocetVPasPredRontgenom2 = new WeightedStatisticsCollector();
            PocetVPasPredRontgenomSpolu = new WeightedStatisticsCollector();
            PocetVPasZaRontgenom1 = new WeightedStatisticsCollector();
            PocetVPasZaRontgenom2 = new WeightedStatisticsCollector();
            PocetVPasZaRontgenomSpolu = new WeightedStatisticsCollector();
            CasVSystemeCollector              = new StatisticsCollector();
            CasVRadePredRontgenomCollector    = new StatisticsCollector();
            CasVRadePredDetektoromCollector   = new StatisticsCollector();
            CasVRadePredZberomCollector       = new StatisticsCollector();
            CasVPasPredRontgenomCollector     = new StatisticsCollector();
            CasVPasZaRontgenomCollector       = new StatisticsCollector();
            //2.5.1
            //---------------------- Globalne statistiky -----------------
            GlobalAvgRadPredRontgenom1 = new StatisticsCollector();
            GlobalAvgRadPredRontgenom2 = new StatisticsCollector();
            GlobalAvgRadPredDetektorom1 = new StatisticsCollector();
            GlobalAvgRadPredDetektorom2 = new StatisticsCollector();
            GlobalAvgRadPredZberom1 = new StatisticsCollector();
            GlobalAvgRadPredZberom2 = new StatisticsCollector();
            GlobalAvgRadPredRontgenomSpolu = new StatisticsCollector();
            GlobalAvgRadPredDetektoromSpolu = new StatisticsCollector();
            GlobalAvgRadPredZberomSpolu = new StatisticsCollector();
            GlobalAvgPasPredRontgenom1 = new StatisticsCollector();
            GlobalAvgPasPredRontgenom2 = new StatisticsCollector();
            GlobalAvgPasPredRontgenomSpolu = new StatisticsCollector();
            GlobalAvgPasZaRontgenom1 = new StatisticsCollector();
            GlobalAvgPasZaRontgenom2 = new StatisticsCollector();
            GlobalAvgPasZaRontgenomSpolu = new StatisticsCollector();
            GlobalAvgCasVSysteme                  = new StatisticsCollector();
            GlobalAvgCasVRadePredRontgenom        = new StatisticsCollector();
            GlobalAvgCasVRadePredDetektorom       = new StatisticsCollector();
            GlobalAvgCasVRadePredZberom           = new StatisticsCollector();
            GlobalAvgCasVPasPredRontgenom         = new StatisticsCollector();
            GlobalAvgCasVPasZaRontgenom           = new StatisticsCollector();
        }

        // Cas v sekundach, kedy sa v replikacii spusti EWarmupEnd a resetuju sa statistiky.
        // 0 = warmup vypnuty.
        public double WarmupTime { get; set; }

        public int MaxPasPred { get; set; } = 4;
        public int MaxPasZa  { get; set; } = 5;

        //2.5.1
        // Resetuje per-replikacne statistiky od aktualneho casu s aktualnymi hodnotami frontov.
        // Volane z EWarmupEnd.
        public void ResetPerReplicationStats()
        {
            PocetVRadePredRontgenom1      = new WeightedStatisticsCollector();
            PocetVRadePredRontgenom2      = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom1     = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom2     = new WeightedStatisticsCollector();
            PocetVRadePredZberom1         = new WeightedStatisticsCollector();
            PocetVRadePredZberom2         = new WeightedStatisticsCollector();
            PocetVRadePredRontgenomSpolu  = new WeightedStatisticsCollector();
            PocetVRadePredDetektoromSpolu = new WeightedStatisticsCollector();
            PocetVRadePredZberomSpolu     = new WeightedStatisticsCollector();
            PocetVPasPredRontgenom1       = new WeightedStatisticsCollector();
            PocetVPasPredRontgenom2       = new WeightedStatisticsCollector();
            PocetVPasPredRontgenomSpolu   = new WeightedStatisticsCollector();
            PocetVPasZaRontgenom1         = new WeightedStatisticsCollector();
            PocetVPasZaRontgenom2         = new WeightedStatisticsCollector();
            PocetVPasZaRontgenomSpolu     = new WeightedStatisticsCollector();
            CasVSystemeCollector              = new StatisticsCollector();
            CasVRadePredRontgenomCollector    = new StatisticsCollector();
            CasVRadePredDetektoromCollector   = new StatisticsCollector();
            CasVRadePredZberomCollector       = new StatisticsCollector();
            CasVPasPredRontgenomCollector     = new StatisticsCollector();
            CasVPasZaRontgenomCollector       = new StatisticsCollector();

            PocetVRadePredRontgenom1.AddWeightedValue(RadPredRontgenom1.Count, CurrentTime);
            PocetVRadePredRontgenom2.AddWeightedValue(RadPredRontgenom2.Count, CurrentTime);
            PocetVRadePredDetektorom1.AddWeightedValue(RadPredDetektorom1.Count, CurrentTime);
            PocetVRadePredDetektorom2.AddWeightedValue(RadPredDetektorom2.Count, CurrentTime);
            PocetVRadePredZberom1.AddWeightedValue(RadPredZberomPrepraviek1.Count, CurrentTime);
            PocetVRadePredZberom2.AddWeightedValue(RadPredZberomPrepraviek2.Count, CurrentTime);
            PocetVRadePredRontgenomSpolu.AddWeightedValue(
                RadPredRontgenom1.Count + RadPredRontgenom2.Count, CurrentTime);
            PocetVRadePredDetektoromSpolu.AddWeightedValue(
                RadPredDetektorom1.Count + RadPredDetektorom2.Count, CurrentTime);
            PocetVRadePredZberomSpolu.AddWeightedValue(
                RadPredZberomPrepraviek1.Count + RadPredZberomPrepraviek2.Count, CurrentTime);
            PocetVPasPredRontgenom1.AddWeightedValue(Rontgen1.PocetPrepraviekPred, CurrentTime);
            PocetVPasPredRontgenom2.AddWeightedValue(Rontgen2.PocetPrepraviekPred, CurrentTime);
            PocetVPasPredRontgenomSpolu.AddWeightedValue(
                Rontgen1.PocetPrepraviekPred + Rontgen2.PocetPrepraviekPred, CurrentTime);
            PocetVPasZaRontgenom1.AddWeightedValue(Rontgen1.PocetPrepraviekZa, CurrentTime);
            PocetVPasZaRontgenom2.AddWeightedValue(Rontgen2.PocetPrepraviekZa, CurrentTime);
            PocetVPasZaRontgenomSpolu.AddWeightedValue(
                Rontgen1.PocetPrepraviekZa + Rontgen2.PocetPrepraviekZa, CurrentTime);
        }

        public static string CsvObservationHeader =>
            "Replikacia,ObsIndex,SimCas," +
            "CasVSysteme,RadRontgenSpolu,RadDetektorSpolu,RadZberSpolu";

        public static string CsvReplicationHeader =>
            "Replikacia," +
            "CasVSysteme,CasVRadePredRontgenom,CasVRadePredDetektorom,CasVRadePredZberom," +
            "CasVPasPredRontgenom,CasVPasZaRontgenom," +
            "RadRontgenSpolu,RadDetektorSpolu,RadZberSpolu,PasPredSpolu,PasZaSpolu";
        //2.5.2
        private void WriteReplicationRow()
        {
            if (CsvOutput == null) return;
            static string F(double v) => v.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);
            CsvOutput.WriteLine(string.Join(",",
                CurrentReplication,
                F(CasVSystemeCollector.Average),
                F(CasVRadePredRontgenomCollector.Average),
                F(CasVRadePredDetektoromCollector.Average),
                F(CasVRadePredZberomCollector.Average),
                F(CasVPasPredRontgenomCollector.Average),
                F(CasVPasZaRontgenomCollector.Average),
                F(PocetVRadePredRontgenomSpolu.WeightedAverage),
                F(PocetVRadePredDetektoromSpolu.WeightedAverage),
                F(PocetVRadePredZberomSpolu.WeightedAverage),
                F(PocetVPasPredRontgenomSpolu.WeightedAverage),
                F(PocetVPasZaRontgenomSpolu.WeightedAverage)));
        }
        //2.5.2
        internal void WriteObservationRow()
        {
            if (CsvOutput == null) return;
            _obsIndex++;
            static string F(double v) => v.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);
            CsvOutput.WriteLine(string.Join(",",
                CurrentReplication,
                _obsIndex,
                F(CurrentTime),
                F(CasVSystemeCollector.Average),
                RadPredRontgenom1.Count + RadPredRontgenom2.Count,
                RadPredDetektorom1.Count + RadPredDetektorom2.Count,
                RadPredZberomPrepraviek1.Count + RadPredZberomPrepraviek2.Count));
        }

        protected override void BeforeSimulation() { }

        //2.5.1
        protected override void BeforeReplication()
        {
            EventQueue = new PriorityQueue<Event, double>();
            CurrentTime = 0;
            PocetCestujucich = 0;
            RadPredRontgenom1        = new Queue<Cestujuci>();
            RadPredRontgenom2        = new Queue<Cestujuci>();
            Rontgen1                 = new Rontgen(MaxPasPred, MaxPasZa);
            Rontgen2                 = new Rontgen(MaxPasPred, MaxPasZa);
            RadPredDetektorom1       = new Queue<Cestujuci>();
            RadPredDetektorom2       = new Queue<Cestujuci>();
            Detektor1                = new DetektorKovu();
            Detektor2                = new DetektorKovu();
            RadPredZberomPrepraviek1 = new Queue<Cestujuci>();
            RadPredZberomPrepraviek2 = new Queue<Cestujuci>();
            ZberPrepraviek1Volny     = true;
            ZberPrepraviek2Volny     = true;
            TimeLimit = SimDuration + WarmupTime;
            double firstArrival = GeneratorPrichodov.Generate();
            ScheduleEvent(new EPrichodCestujuceho(this, new Cestujuci(firstArrival, PocetCestujucich)), firstArrival);
            if (WarmupTime > 0)
                ScheduleEvent(new EWarmupEnd(this), WarmupTime);
            if (Slowdown)
                ScheduleEvent(new SleepEvent(this, Length), 0);
            _obsIndex = 0;
            if (CollectInterval > 0)
                ScheduleEvent(new ECollectData(this), CollectInterval);
            PocetVRadePredRontgenom1      = new WeightedStatisticsCollector();
            PocetVRadePredRontgenom2      = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom1     = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom2     = new WeightedStatisticsCollector();
            PocetVRadePredZberom1         = new WeightedStatisticsCollector();
            PocetVRadePredZberom2         = new WeightedStatisticsCollector();
            PocetVRadePredRontgenomSpolu  = new WeightedStatisticsCollector();
            PocetVRadePredDetektoromSpolu = new WeightedStatisticsCollector();
            PocetVRadePredZberomSpolu     = new WeightedStatisticsCollector();
            PocetVPasPredRontgenom1       = new WeightedStatisticsCollector();
            PocetVPasPredRontgenom2       = new WeightedStatisticsCollector();
            PocetVPasPredRontgenomSpolu   = new WeightedStatisticsCollector();
            PocetVPasZaRontgenom1         = new WeightedStatisticsCollector();
            PocetVPasZaRontgenom2         = new WeightedStatisticsCollector();
            PocetVPasZaRontgenomSpolu     = new WeightedStatisticsCollector();
            CasVSystemeCollector              = new StatisticsCollector();
            CasVRadePredRontgenomCollector    = new StatisticsCollector();
            CasVRadePredDetektoromCollector   = new StatisticsCollector();
            CasVRadePredZberomCollector       = new StatisticsCollector();
            CasVPasPredRontgenomCollector     = new StatisticsCollector();
            CasVPasZaRontgenomCollector       = new StatisticsCollector();
            PocetVRadePredRontgenom1.AddWeightedValue(0, 0);
            PocetVRadePredRontgenom2.AddWeightedValue(0, 0);
            PocetVRadePredDetektorom1.AddWeightedValue(0, 0);
            PocetVRadePredDetektorom2.AddWeightedValue(0, 0);
            PocetVRadePredZberom1.AddWeightedValue(0, 0);
            PocetVRadePredZberom2.AddWeightedValue(0, 0);
            PocetVRadePredRontgenomSpolu.AddWeightedValue(0, 0);
            PocetVRadePredDetektoromSpolu.AddWeightedValue(0, 0);
            PocetVRadePredZberomSpolu.AddWeightedValue(0, 0);
            PocetVPasPredRontgenom1.AddWeightedValue(0, 0);
            PocetVPasPredRontgenom2.AddWeightedValue(0, 0);
            PocetVPasPredRontgenomSpolu.AddWeightedValue(0, 0);
            PocetVPasZaRontgenom1.AddWeightedValue(0, 0);
            PocetVPasZaRontgenom2.AddWeightedValue(0, 0);
            PocetVPasZaRontgenomSpolu.AddWeightedValue(0, 0);
        }

        //2.5.1
        protected override void AfterReplication()
        {
            PocetVRadePredRontgenom1.AddWeightedValue(0, CurrentTime);
            PocetVRadePredRontgenom2.AddWeightedValue(0, CurrentTime);
            PocetVRadePredDetektorom1.AddWeightedValue(0, CurrentTime);
            PocetVRadePredDetektorom2.AddWeightedValue(0, CurrentTime);
            PocetVRadePredZberom1.AddWeightedValue(0, CurrentTime);
            PocetVRadePredZberom2.AddWeightedValue(0, CurrentTime);
            PocetVRadePredRontgenomSpolu.AddWeightedValue(0, CurrentTime);
            PocetVRadePredDetektoromSpolu.AddWeightedValue(0, CurrentTime);
            PocetVRadePredZberomSpolu.AddWeightedValue(0, CurrentTime);
            PocetVPasPredRontgenom1.AddWeightedValue(0, CurrentTime);
            PocetVPasPredRontgenom2.AddWeightedValue(0, CurrentTime);
            PocetVPasPredRontgenomSpolu.AddWeightedValue(0, CurrentTime);
            PocetVPasZaRontgenom1.AddWeightedValue(0, CurrentTime);
            PocetVPasZaRontgenom2.AddWeightedValue(0, CurrentTime);
            PocetVPasZaRontgenomSpolu.AddWeightedValue(0, CurrentTime);

            GlobalAvgRadPredRontgenom1.AddValue(PocetVRadePredRontgenom1.WeightedAverage);
            GlobalAvgRadPredRontgenom2.AddValue(PocetVRadePredRontgenom2.WeightedAverage);
            GlobalAvgRadPredDetektorom1.AddValue(PocetVRadePredDetektorom1.WeightedAverage);
            GlobalAvgRadPredDetektorom2.AddValue(PocetVRadePredDetektorom2.WeightedAverage);
            GlobalAvgRadPredZberom1.AddValue(PocetVRadePredZberom1.WeightedAverage);
            GlobalAvgRadPredZberom2.AddValue(PocetVRadePredZberom2.WeightedAverage);
            GlobalAvgRadPredRontgenomSpolu.AddValue(PocetVRadePredRontgenomSpolu.WeightedAverage);
            GlobalAvgRadPredDetektoromSpolu.AddValue(PocetVRadePredDetektoromSpolu.WeightedAverage);
            GlobalAvgRadPredZberomSpolu.AddValue(PocetVRadePredZberomSpolu.WeightedAverage);
            GlobalAvgPasPredRontgenom1.AddValue(PocetVPasPredRontgenom1.WeightedAverage);
            GlobalAvgPasPredRontgenom2.AddValue(PocetVPasPredRontgenom2.WeightedAverage);
            GlobalAvgPasPredRontgenomSpolu.AddValue(PocetVPasPredRontgenomSpolu.WeightedAverage);
            GlobalAvgPasZaRontgenom1.AddValue(PocetVPasZaRontgenom1.WeightedAverage);
            GlobalAvgPasZaRontgenom2.AddValue(PocetVPasZaRontgenom2.WeightedAverage);
            GlobalAvgPasZaRontgenomSpolu.AddValue(PocetVPasZaRontgenomSpolu.WeightedAverage);
            GlobalAvgCasVSysteme.AddValue(CasVSystemeCollector.Average);
            GlobalAvgCasVRadePredRontgenom.AddValue(CasVRadePredRontgenomCollector.Average);
            GlobalAvgCasVRadePredDetektorom.AddValue(CasVRadePredDetektoromCollector.Average);
            GlobalAvgCasVRadePredZberom.AddValue(CasVRadePredZberomCollector.Average);
            GlobalAvgCasVPasPredRontgenom.AddValue(CasVPasPredRontgenomCollector.Average);
            GlobalAvgCasVPasZaRontgenom.AddValue(CasVPasZaRontgenomCollector.Average);

            if (CollectInterval == 0)
                WriteReplicationRow();

            RefreshGUI();
        }

        protected override void AfterSimulation()
        {
            Console.WriteLine("Priemer dlzky radu pred rontgenom 1: " + GlobalAvgRadPredRontgenom1.Average);
            Console.WriteLine("Priemer dlzky radu pred rontgenom 2: " + GlobalAvgRadPredRontgenom2.Average);
            Console.WriteLine("Priemer dlzky radu pred rontgenom (spolu): " + GlobalAvgRadPredRontgenomSpolu.Average);
            Console.WriteLine("Priemer dlzky radu pred detektorom 1: " + GlobalAvgRadPredDetektorom1.Average);
            Console.WriteLine("Priemer dlzky radu pred detektorom 2: " + GlobalAvgRadPredDetektorom2.Average);
            Console.WriteLine("Priemer dlzky radu pred detektorom (spolu): " + GlobalAvgRadPredDetektoromSpolu.Average);
            Console.WriteLine("Priemer dlzky radu pred zberom prepraviek 1: " + GlobalAvgRadPredZberom1.Average);
            Console.WriteLine("Priemer dlzky radu pred zberom prepraviek 2: " + GlobalAvgRadPredZberom2.Average);
            Console.WriteLine("Priemer dlzky radu pred zberom prepraviek (spolu): " + GlobalAvgRadPredZberomSpolu.Average);
            Console.WriteLine("Priemerny cas cestujuceho v systeme: " + GlobalAvgCasVSysteme.Average);

            RefreshGUI();
        }
    }
}
