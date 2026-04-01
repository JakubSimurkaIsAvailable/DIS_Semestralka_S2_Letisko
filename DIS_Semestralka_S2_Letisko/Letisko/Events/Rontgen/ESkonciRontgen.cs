using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Zber;
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
        private int Terminal;
        public ESkonciRontgen(LetiskoSimulation core, Prepravka actor, Objects.Rontgen rontgen, int terminal) : base(core, actor)
        {
                this.Rontgen = rontgen;
                this.Terminal = terminal;
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Prepravka prepravka = (Prepravka)Actor;
            Queue<Cestujuci> radPredZberom;
            bool zberVolny;
            Prepravka kontrola = Rontgen.PrepravkyPredRontgenom.Dequeue();

            switch(Terminal)
            {
                case 0:
                    radPredZberom = simulacia.RadPredZberomPrepraviek1;
                    zberVolny = simulacia.ZberPrepraviek1Volny;
                    break;
                case 1:
                    radPredZberom = simulacia.RadPredZberomPrepraviek2;
                    zberVolny = simulacia.ZberPrepraviek2Volny;
                    break;
                default:
                    throw new Exception("Nespravny terminal");
            }

            if (kontrola.ID != prepravka.ID)
            {
                throw new Exception("Nespravna prepravka");
            }
            prepravka.CasUkonceniaRontgenu = simulacia.CurrentTime;
            Rontgen.PrepravkyZaRontgenom.Enqueue(prepravka);

            if (Rontgen.PocetPrepraviekPred > 0)
            {
                Prepravka dalsiaPrepravka = Rontgen.PrepravkyPredRontgenom.Peek();
                simulacia.ScheduleEvent(new EZacniRontgen(simulacia, dalsiaPrepravka, Rontgen, Terminal), simulacia.CurrentTime);
            }
            else
            {
                Rontgen.JeVolnyPrepravka = true;
            }

            // belt before scanner freed one slot — unblock a waiting passenger if any
            Queue<Cestujuci> radPredRontgenom = Terminal == 0 ? simulacia.RadPredRontgenom1 : simulacia.RadPredRontgenom2;
            if (!Rontgen.JeVolnyCestujuci && radPredRontgenom.Count > 0 && radPredRontgenom.Peek().AktualnyPocetPrepraviek > 0)
            {
                simulacia.ScheduleEvent(new ENalozeniePrepravkyNaPas(simulacia, radPredRontgenom.Peek()), simulacia.CurrentTime);
            }

            if(!zberVolny)
            {
                Cestujuci c;
                radPredZberom.TryPeek(out c);
                if (c != null)
                    simulacia.ScheduleEvent(new EZberPrepravky(simulacia, c), simulacia.CurrentTime);
            }

            return simulacia.CurrentTime;
        }
    }
}
