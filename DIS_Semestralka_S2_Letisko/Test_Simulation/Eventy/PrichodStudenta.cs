using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Test_Simulation.Eventy
{
    public class PrichodStudenta : Event
    {
        public PrichodStudenta(Event_Core core, Student actor) : base(core, actor)
        {
        }

        /// <summary>
        /// Metoda vytvorena pomocou AI, zdokumentovana v kapitole 1.2.2
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            Student student = (Student)Actor;
            JednoduchaSimulacia simulacia = (JednoduchaSimulacia)Core;
            Console.WriteLine("Prichod studenta: " + Core.CurrentTime);
            double nextArrivalTime = student.CasPrichodu + simulacia.generatorPrichodov.Generate();
            Core.ScheduleEvent(new PrichodStudenta(Core, new Student(nextArrivalTime)), nextArrivalTime);

            if (simulacia.obsluhaVolna)
            {
                
                simulacia.obsluhaVolna = false;
                simulacia.ScheduleEvent(new PlatbaZaKavu(simulacia, student), student.CasPrichodu);
                student.ZacniObsluhu(student.CasPrichodu);
                simulacia.pocetZakaznikovRada.AddWeightedValue(0, student.CasPrichodu);
            }
            else
            {
                
                simulacia.radaPredObsluhou.Enqueue(student);
                simulacia.pocetZakaznikovRada.AddWeightedValue(simulacia.radaPredObsluhou.Count, student.CasPrichodu);
            }

            return student.CasPrichodu;
        }
    }
}
