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

            return cestujuci.CasNalozeniaPrepraviek;
        }

        private void VylozPrepravky(Cestujuci cestujuci, LetiskoSimulation simulacia, Objects.Rontgen rontgen)
        {
            int pocet = cestujuci.AktualnyPocetPrepraviek;
            for (int i = 0; i < pocet; i++)
            {
                int idPrepravky = cestujuci.MaxPocetPrepraviek - cestujuci.AktualnyPocetPrepraviek + i + 1;
                Prepravka prepravka = new Prepravka(cestujuci.ID, idPrepravky);
                prepravka.CasUlozeniaNaPasPredRontgenom = cestujuci.CasNalozeniaPrepraviek;
                rontgen.PridajPrepravku(prepravka);
            }
            cestujuci.AktualnyPocetPrepraviek = 0;

            if (rontgen.JeVolnyPrepravka && rontgen.PocetPrepraviekPred > 0)
            {
                rontgen.JeVolnyPrepravka = false;
                Prepravka prvaPrepravka = rontgen.PrepravkyPredRontgenom.Dequeue();
                simulacia.ScheduleEvent(new EZacniRontgen(simulacia, prvaPrepravka, rontgen), cestujuci.CasNalozeniaPrepraviek);
            }

            cestujuci.CasDovykladaniaPrepraviek = cestujuci.CasNalozeniaPrepraviek;
            simulacia.ScheduleEvent(new EOdchodCestujucehoRontgen(simulacia, cestujuci), cestujuci.CasDovykladaniaPrepraviek);
        }
    }
}
