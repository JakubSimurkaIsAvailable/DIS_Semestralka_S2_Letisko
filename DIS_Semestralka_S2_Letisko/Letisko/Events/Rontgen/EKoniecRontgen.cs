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
    public class EKoniecRontgen : EventPrepravka
    {
        private Objects.Rontgen Rontgen;
        private int Terminal;
        public EKoniecRontgen(LetiskoSimulation core, Prepravka actor, Objects.Rontgen rontgen, int terminal) : base(core, actor)
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


            prepravka.CasUkonceniaRontgenu = simulacia.CurrentTime;
            Rontgen.PrepravkyZaRontgenom.Enqueue(prepravka);
            if (Terminal == 0)
                simulacia.PocetVPasZaRontgenom1.AddWeightedValue(Rontgen.PocetPrepraviekZa, simulacia.CurrentTime);
            else
                simulacia.PocetVPasZaRontgenom2.AddWeightedValue(Rontgen.PocetPrepraviekZa, simulacia.CurrentTime);
            simulacia.PocetVPasZaRontgenomSpolu.AddWeightedValue(
                simulacia.Rontgen1.PocetPrepraviekZa + simulacia.Rontgen2.PocetPrepraviekZa, simulacia.CurrentTime);

            if (Rontgen.PocetPrepraviekPred > 0 && Rontgen.PocetPrepraviekZa < Rontgen.MaxAfter)
            {
                Prepravka dalsiaPrepravka = Rontgen.PrepravkyPredRontgenom.Peek();
                simulacia.ScheduleEvent(new EZaciatokRontgen(simulacia, dalsiaPrepravka, Rontgen, Terminal), simulacia.CurrentTime);
            }
            else
            {
                Rontgen.JeVolnyPrepravka = true;
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
