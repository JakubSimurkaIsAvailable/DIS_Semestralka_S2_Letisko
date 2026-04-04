using DIS_Semestralka_S2_Letisko.Generators;
using DIS_Semestralka_S2_Letisko.Generators.Components;
using DIS_Semestralka_S2_Letisko.Letisko.Actors;
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
        public StatisticsCollector CasVSystemeCollector { get; private set; }
        // -----------------------------------------------

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
        public StatisticsCollector GlobalAvgCasVSysteme { get; private set; }
        // --------------------------------------------------------------

        public LetiskoSimulation()
        {
            // ----------------------- Generatory ----------------------
            GeneratorGeneratorov = new Random();
            double lambda = 1.0 / 15.0; // Priemerny cas medzi prichodmi je 15 sekund
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
            CasVSystemeCollector = new StatisticsCollector();
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
            GlobalAvgCasVSysteme = new StatisticsCollector();
        }

        protected override void BeforeSimulation() { }

        protected override void BeforeReplication()
        {
            EventQueue = new PriorityQueue<Event, double>();
            CurrentTime = 0;
            PocetCestujucich = 0;
            // Reset queues and objects
            RadPredRontgenom1 = new Queue<Cestujuci>();
            RadPredRontgenom2 = new Queue<Cestujuci>();
            Rontgen1 = new Rontgen(4, 5);
            Rontgen2 = new Rontgen(4, 5);
            RadPredDetektorom1 = new Queue<Cestujuci>();
            RadPredDetektorom2 = new Queue<Cestujuci>();
            Detektor1 = new DetektorKovu();
            Detektor2 = new DetektorKovu();
            RadPredZberomPrepraviek1 = new Queue<Cestujuci>();
            RadPredZberomPrepraviek2 = new Queue<Cestujuci>();
            ZberPrepraviek1Volny = true;
            ZberPrepraviek2Volny = true;
            double firstArrival = GeneratorPrichodov.Generate();
            ScheduleEvent(new EPrichodCestujuceho(this, new Cestujuci(firstArrival, PocetCestujucich)), firstArrival);
            if (Slowdown)
                ScheduleEvent(new SleepEvent(this, Length), 0);
            PocetVRadePredRontgenom1 = new WeightedStatisticsCollector();
            PocetVRadePredRontgenom2 = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom1 = new WeightedStatisticsCollector();
            PocetVRadePredDetektorom2 = new WeightedStatisticsCollector();
            PocetVRadePredZberom1 = new WeightedStatisticsCollector();
            PocetVRadePredZberom2 = new WeightedStatisticsCollector();
            PocetVRadePredRontgenomSpolu = new WeightedStatisticsCollector();
            PocetVRadePredDetektoromSpolu = new WeightedStatisticsCollector();
            PocetVRadePredZberomSpolu = new WeightedStatisticsCollector();
            CasVSystemeCollector = new StatisticsCollector();

            PocetVRadePredRontgenom1.AddWeightedValue(0, 0);
            PocetVRadePredRontgenom2.AddWeightedValue(0, 0);
            PocetVRadePredDetektorom1.AddWeightedValue(0, 0);
            PocetVRadePredDetektorom2.AddWeightedValue(0, 0);
            PocetVRadePredZberom1.AddWeightedValue(0, 0);
            PocetVRadePredZberom2.AddWeightedValue(0, 0);
            PocetVRadePredRontgenomSpolu.AddWeightedValue(0, 0);
            PocetVRadePredDetektoromSpolu.AddWeightedValue(0, 0);
            PocetVRadePredZberomSpolu.AddWeightedValue(0, 0);
        }

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

            GlobalAvgRadPredRontgenom1.AddValue(PocetVRadePredRontgenom1.WeightedAverage);
            GlobalAvgRadPredRontgenom2.AddValue(PocetVRadePredRontgenom2.WeightedAverage);
            GlobalAvgRadPredDetektorom1.AddValue(PocetVRadePredDetektorom1.WeightedAverage);
            GlobalAvgRadPredDetektorom2.AddValue(PocetVRadePredDetektorom2.WeightedAverage);
            GlobalAvgRadPredZberom1.AddValue(PocetVRadePredZberom1.WeightedAverage);
            GlobalAvgRadPredZberom2.AddValue(PocetVRadePredZberom2.WeightedAverage);
            GlobalAvgRadPredRontgenomSpolu.AddValue(PocetVRadePredRontgenomSpolu.WeightedAverage);
            GlobalAvgRadPredDetektoromSpolu.AddValue(PocetVRadePredDetektoromSpolu.WeightedAverage);
            GlobalAvgRadPredZberomSpolu.AddValue(PocetVRadePredZberomSpolu.WeightedAverage);
            GlobalAvgCasVSysteme.AddValue(CasVSystemeCollector.Average);

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
