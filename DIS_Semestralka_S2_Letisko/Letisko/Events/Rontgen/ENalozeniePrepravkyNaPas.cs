using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Rontgen
{
    public class ENalozeniePrepravkyNaPas : EventCestujuci
    {
        public ENalozeniePrepravkyNaPas(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            switch (cestujuci.Rad)
            {
                case 0:
                    VylozPrepravky(cestujuci, simulacia, simulacia.Rontgen1);
                    break;
                case 1:
                    VylozPrepravky(cestujuci, simulacia, simulacia.Rontgen2);
                    break;
            }

            return simulacia.CurrentTime;
        }

        private void VylozPrepravky(Cestujuci cestujuci, LetiskoSimulation simulacia, Objects.Rontgen rontgen)
        {
            bool terminal1 = rontgen == simulacia.Rontgen1;
            int pocet = cestujuci.AktualnyPocetPrepraviek;
            for (int i = 0; i < pocet; i++)
            {
                int alreadyPlaced = cestujuci.MaxPocetPrepraviek - cestujuci.AktualnyPocetPrepraviek;
                int idPrepravky = alreadyPlaced + 1;
                Prepravka prepravka = new Prepravka(cestujuci.ID, idPrepravky);
                prepravka.CasUlozeniaNaPasPredRontgenom = simulacia.CurrentTime;
                if (rontgen.PridajPrepravku(prepravka))
                {
                    cestujuci.AktualnyPocetPrepraviek--;
                    if (terminal1)
                        simulacia.PocetVPasPredRontgenom1.AddWeightedValue(rontgen.PocetPrepraviekPred, simulacia.CurrentTime);
                    else
                        simulacia.PocetVPasPredRontgenom2.AddWeightedValue(rontgen.PocetPrepraviekPred, simulacia.CurrentTime);
                    simulacia.PocetVPasPredRontgenomSpolu.AddWeightedValue(
                        simulacia.Rontgen1.PocetPrepraviekPred + simulacia.Rontgen2.PocetPrepraviekPred, simulacia.CurrentTime);
                }
                else
                {
                    break; 
                }
            }

            if (rontgen.JeVolnyPrepravka && rontgen.PocetPrepraviekPred > 0 && rontgen.PocetPrepraviekZa < rontgen.MaxAfter)
            {
                rontgen.JeVolnyPrepravka = false;
                Prepravka prvaPrepravka = rontgen.PrepravkyPredRontgenom.Peek();
                simulacia.ScheduleEvent(new EZaciatokRontgen(simulacia, prvaPrepravka, rontgen, cestujuci.Rad), simulacia.CurrentTime);
            }

            if (cestujuci.AktualnyPocetPrepraviek == 0)
            {
                cestujuci.CasDovykladaniaPrepraviek = simulacia.CurrentTime;
                simulacia.ScheduleEvent(new EOdchodCestujucehoRontgen(simulacia, cestujuci), simulacia.CurrentTime);
            }

        }
    }
}
