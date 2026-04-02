using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Odchod;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Rontgen;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Zber
{
    public class EZberPrepravky : EventCestujuci
    {
        public EZberPrepravky(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            Queue<Cestujuci> radPredZberomPrepraviek;
            bool zberPrepraviekVolny;
            Cestujuci kontrola;
            Objects.Rontgen rontgen;
            switch (cestujuci.Rad)
            {
                case 0:
                    kontrola = simulacia.RadPredZberomPrepraviek1.Peek();
                    rontgen = simulacia.Rontgen1;
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek1;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek1Volny;
                    break;
                case 1:
                    kontrola = simulacia.RadPredZberomPrepraviek2.Peek();
                    rontgen = simulacia.Rontgen2;
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek2;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek2Volny;
                    break;
                default:
                    throw new Exception("Neplatný rad cestujícího.");
            }
            if(kontrola.ID != cestujuci.ID)
            {
                throw new Exception("Neplatny cestujuci na zbere prepraviek");
            }
            for(int i = 0; i < cestujuci.MaxPocetPrepraviek; i++)
            {
                Prepravka p;
                rontgen.PrepravkyZaRontgenom.TryPeek(out p);
                if(p is not null && p.ID_Cestujuci == cestujuci.ID)
                {
                    rontgen.PrepravkyZaRontgenom.Dequeue();
                    cestujuci.AktualnyPocetPrepraviek++;
                    if(rontgen.PrepravkyZaRontgenom.Count < rontgen.MaxAfter && rontgen.PrepravkyPredRontgenom.Count > 0 && rontgen.JeVolnyPrepravka)
                    {
                        Prepravka novaPrepravva = rontgen.PrepravkyPredRontgenom.Peek();
                        simulacia.ScheduleEvent(new EZacniRontgen(simulacia, novaPrepravva, rontgen, cestujuci.Rad), simulacia.CurrentTime);
                    }
                }
            }
            if(cestujuci.AktualnyPocetPrepraviek == cestujuci.MaxPocetPrepraviek )
            {
                radPredZberomPrepraviek.Dequeue();
                if (cestujuci.Rad == 0)
                    simulacia.PocetVRadePredZberom1.AddWeightedValue(radPredZberomPrepraviek.Count, simulacia.CurrentTime);
                else
                    simulacia.PocetVRadePredZberom2.AddWeightedValue(radPredZberomPrepraviek.Count, simulacia.CurrentTime);
                simulacia.PocetVRadePredZberomSpolu.AddWeightedValue(simulacia.RadPredZberomPrepraviek1.Count + simulacia.RadPredZberomPrepraviek2.Count, simulacia.CurrentTime);
                simulacia.CasVSystemeCollector.AddValue(simulacia.CurrentTime - cestujuci.CasPrichodu);
                if (radPredZberomPrepraviek.Count > 0)
                {
                    Cestujuci dalsiCestujuci = radPredZberomPrepraviek.Peek();
                    simulacia.ScheduleEvent(new EPrichodZberPrepraviek(simulacia, dalsiCestujuci), simulacia.CurrentTime);
                } else
                {
                    switch(cestujuci.Rad)
                    {
                        case 0:
                            simulacia.ZberPrepraviek1Volny = true;
                            break;
                        case 1:
                            simulacia.ZberPrepraviek2Volny = true;
                            break;
                    }
                }

            }
            return simulacia.CurrentTime;
        }
    }
}
