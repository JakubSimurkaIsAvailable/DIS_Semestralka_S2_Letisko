using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Test_Simulation.Eventy
{
    public class PlatbaZaKavu : Event
    {
        public PlatbaZaKavu(Event_Core core, Student actor) : base(core, actor)
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

            Console.WriteLine("Platba za kavu: " + Core.CurrentTime);

            double trvanieObsluhy = simulacia.generatorDlzkyObsluhy.Generate();
            double casKoniecObsluhy = simulacia.CurrentTime + trvanieObsluhy;

            simulacia.ScheduleEvent(new KoniecVareniaKavy(simulacia, student), casKoniecObsluhy);
            student.SkonciObsluhu(casKoniecObsluhy);

            double casCakaniaZakaznika = student.CasZaciatkuObsluhy - student.CasPrichodu;
            simulacia.casCakaniaZakaznikov.AddValue(casCakaniaZakaznika);

            return student.CasZaciatkuObsluhy;
        }
    }
}
