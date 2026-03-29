using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Test_Simulation.Eventy
{
    public class KoniecVareniaKavy : Event
    {
        public KoniecVareniaKavy(Event_Core core, Student actor) : base(core, actor)
        {

        }
        /// <summary>
        /// Metoda vytvorena pomocou AI, zdokumentovana v kapitole 1.2.2
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            JednoduchaSimulacia simulacia = (JednoduchaSimulacia)Core;
            Student student = (Student)Actor;

            Console.WriteLine("Koniec varenia kavy: " + Core.CurrentTime);

            if (simulacia.radaPredObsluhou.Count > 0)
            {
                Student dalsiZakaznik = simulacia.radaPredObsluhou.Dequeue(); 
                
                simulacia.ScheduleEvent(new PlatbaZaKavu(simulacia, dalsiZakaznik), student.OdchodZakaznika);
                dalsiZakaznik.ZacniObsluhu(student.OdchodZakaznika);
                simulacia.pocetZakaznikovRada.AddWeightedValue(simulacia.radaPredObsluhou.Count, student.OdchodZakaznika);
            }
            else
            {
                
                simulacia.obsluhaVolna = true;
                simulacia.pocetZakaznikovRada.AddWeightedValue(0, student.OdchodZakaznika);
            }

            return student.OdchodZakaznika;
        }
    }
}
