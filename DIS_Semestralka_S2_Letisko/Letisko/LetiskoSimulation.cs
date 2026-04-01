using DIS_Semestralka_S2_Letisko.Generators;
using DIS_Semestralka_S2_Letisko.Generators.Components;
using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Arrival;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
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

        // ------------------------------

        // --------= Terminal 2 =--------
        public Queue<Cestujuci> RadPredRontgenom2 { get; private set; }
        public Rontgen Rontgen2 { get; private set; }
        public Queue<Cestujuci> RadPredDetektorom2 { get; private set; }
        public DetektorKovu Detektor2 { get; private set; }
        public Queue<Cestujuci> RadPredZberomPrepraviek2 { get; private set; }
        // ------------------------------
        public LetiskoSimulation()
        {
            // ----------------------- Generatory ----------------------
            GeneratorGeneratorov = new Random();
            GeneratorRontgenPrepravky = new RozdelenieSpojite(GeneratorGeneratorov, 9, 46);
            GeneratorPrichodov = new ExponencialnyGenerator(GeneratorGeneratorov, 0.2);
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
            //---------------------- Terminal 2 -----------------
            RadPredRontgenom2 = new Queue<Cestujuci>();
            Rontgen2 = new Rontgen(4, 5);
            RadPredDetektorom2 = new Queue<Cestujuci>();
            Detektor2 = new DetektorKovu();
            RadPredZberomPrepraviek2 = new Queue<Cestujuci>();
            TimeLimit = 60 * 60 * 24; //60 sekund * 60 minut * 24 hodin = 1 den

        }

        protected override void BeforeSimulation() { }

        protected override void BeforeReplication()
        {
            EventQueue = new PriorityQueue<Event, double>();
            CurrentTime = 0;
            PocetCestujucich = 0;
            double firstArrival = GeneratorPrichodov.Generate();
            ScheduleEvent(new EPrichodCestujuceho(this, new Cestujuci(firstArrival, PocetCestujucich)), firstArrival);
            if (Slowdown)
                ScheduleEvent(new SleepEvent(this, Length), 0);
        }

        protected override void AfterReplication() { }

        protected override void AfterSimulation() { }
    }
}
