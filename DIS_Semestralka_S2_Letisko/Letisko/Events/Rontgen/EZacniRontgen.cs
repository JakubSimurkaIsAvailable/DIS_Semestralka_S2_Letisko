using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Rontgen
{
    public class EZacniRontgen : EventPrepravka
    {
        private Objects.Rontgen Rontgen; 
        public EZacniRontgen(LetiskoSimulation core, Prepravka actor, Objects.Rontgen rontgen) : base(core, actor)
        {
            this.Rontgen = rontgen;
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Prepravka prepravka = (Prepravka)Actor;

            prepravka.CasZaciatkuRontgenu = simulacia.CurrentTime;
            double casKoncaRontgenu = simulacia.CurrentTime + simulacia.GeneratorRontgenPrepravky.Generate();
            simulacia.ScheduleEvent(new ESkonciRontgen(simulacia, prepravka, Rontgen), casKoncaRontgenu);
            return simulacia.CurrentTime;
        }
    }
}
