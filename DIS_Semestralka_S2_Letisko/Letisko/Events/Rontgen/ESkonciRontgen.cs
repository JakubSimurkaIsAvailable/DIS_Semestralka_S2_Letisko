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
    public class ESkonciRontgen : EventPrepravka
    {
        private Objects.Rontgen Rontgen;
        public ESkonciRontgen(LetiskoSimulation core, Prepravka actor, Objects.Rontgen rontgen) : base(core, actor)
        {
                this.Rontgen = rontgen;
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Prepravka prepravka = (Prepravka)Actor;

            prepravka.CasUkonceniaRontgenu = simulacia.CurrentTime;
            Rontgen.PrepravkyZaRontgenom.Enqueue(prepravka);

            if (Rontgen.PocetPrepraviekPred > 0)
            {
                Prepravka dalsiaPrepravka = Rontgen.PrepravkyPredRontgenom.Dequeue();
                simulacia.ScheduleEvent(new EZacniRontgen(simulacia, dalsiaPrepravka, Rontgen), simulacia.CurrentTime);
            }
            else
            {
                Rontgen.JeVolnyPrepravka = true;
            }

            return simulacia.CurrentTime;
        }
    }
}
