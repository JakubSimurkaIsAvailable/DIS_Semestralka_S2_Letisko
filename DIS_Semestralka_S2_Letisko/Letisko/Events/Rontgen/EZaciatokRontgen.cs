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
    public class EZaciatokRontgen : EventPrepravka
    {
        private Objects.Rontgen Rontgen; 
        private int Terminal;
        public EZaciatokRontgen(LetiskoSimulation core, Prepravka actor, Objects.Rontgen rontgen, int terminal) : base(core, actor)
        {
            this.Rontgen = rontgen;
            this.Terminal = terminal;
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Prepravka prepravka = (Prepravka)Actor;

            prepravka.CasZaciatkuRontgenu = simulacia.CurrentTime;
            simulacia.CasVPasPredRontgenomCollector.AddValue(
                simulacia.CurrentTime - prepravka.CasUlozeniaNaPasPredRontgenom);
            double casKoncaRontgenu = simulacia.CurrentTime + simulacia.GeneratorRontgenPrepravky.Generate();
            Prepravka kontrola = Rontgen.PrepravkyPredRontgenom.Dequeue();
            if (kontrola.ID != prepravka.ID)
            {
                throw new Exception("Nespravna prepravka");
            }
            if (Terminal == 0)
                simulacia.PocetVPasPredRontgenom1.AddWeightedValue(Rontgen.PocetPrepraviekPred, simulacia.CurrentTime);
            else
                simulacia.PocetVPasPredRontgenom2.AddWeightedValue(Rontgen.PocetPrepraviekPred, simulacia.CurrentTime);
            simulacia.PocetVPasPredRontgenomSpolu.AddWeightedValue(
                simulacia.Rontgen1.PocetPrepraviekPred + simulacia.Rontgen2.PocetPrepraviekPred, simulacia.CurrentTime);
            simulacia.ScheduleEvent(new EKoniecRontgen(simulacia, prepravka, Rontgen, Terminal), casKoncaRontgenu);

            Queue<Cestujuci> radPredRontgenom = Terminal == 0 ? simulacia.RadPredRontgenom1 : simulacia.RadPredRontgenom2;
            if (!Rontgen.JeVolnyCestujuci && radPredRontgenom.Count > 0 && radPredRontgenom.Peek().AktualnyPocetPrepraviek > 0)
            {
                simulacia.ScheduleEvent(new ENalozeniePrepravkyNaPas(simulacia, radPredRontgenom.Peek()), simulacia.CurrentTime);
            }
            return simulacia.CurrentTime;
        }
    }
}
