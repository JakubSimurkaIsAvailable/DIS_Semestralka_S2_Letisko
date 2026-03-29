using DIS_Semestralka_S2_Letisko.Generators;
using DIS_Semestralka_S2_Letisko.Generators.Components;
using DIS_Semestralka_S2_Letisko.Simulation.Collectors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using DIS_Semestralka_S2_Letisko.Test_Simulation.Eventy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Test_Simulation
{
    public class JednoduchaSimulacia : Event_Core
    {
        public ExponencialnyGenerator generatorPrichodov;
        public RozdelenieSpojite generatorDlzkyObsluhy;
        public Queue<Student> radaPredObsluhou;
        public StatisticsCollector casCakaniaZakaznikov;
        public WeightedStatisticsCollector pocetZakaznikovRada;
        public bool obsluhaVolna;
        public JednoduchaSimulacia(double endTime)
        {
            Random random = new Random();
            TimeLimit = endTime;
            EventQueue = new PriorityQueue<Event, double>();
            CurrentTime = 0;
            generatorPrichodov = new ExponencialnyGenerator(random,0.2); 
            generatorDlzkyObsluhy = new RozdelenieSpojite(random, 2, 4); 
            radaPredObsluhou = new Queue<Student>();
            obsluhaVolna = true;
            casCakaniaZakaznikov = new StatisticsCollector();
            pocetZakaznikovRada = new WeightedStatisticsCollector();
        }
        protected override void AfterReplication()
        {
            
            this.pocetZakaznikovRada.AddWeightedValue(0, CurrentTime);
        }

        protected override void AfterSimulation()
        {
            Console.WriteLine("Priemerny cas cakania zakaznikov: " + casCakaniaZakaznikov.Average);
            Console.WriteLine("Priemerny pocet zakaznikov v rade: " + pocetZakaznikovRada.WeightedAverage);
        }

        protected override void BeforeReplication()
        {
            double cas = generatorPrichodov.Generate();
            this.ScheduleEvent(new PrichodStudenta(this, new Student(cas)), cas);
        }

        protected override void BeforeSimulation()
        {
            return;
        }
    }
}
