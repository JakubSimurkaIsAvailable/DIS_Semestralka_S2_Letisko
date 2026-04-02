using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Odchod;
using DIS_Semestralka_S2_Letisko.Letisko.Objects;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Detektor
{
    public class EKoniecOsobnejPrehliadky : EventCestujuci
    {
        public EKoniecOsobnejPrehliadky(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            Queue<Cestujuci> radPredZberomPrepraviek;
            bool zberPrepraviekVolny;
            Queue<Cestujuci> radPredDetektorom;
            DetektorKovu detektor;
            switch (cestujuci.Rad)
            {
                case 0:
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek1;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek1Volny;
                    radPredDetektorom = simulacia.RadPredDetektorom1;
                    detektor = simulacia.Detektor1;
                    break;
                case 1:
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek2;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek2Volny;
                    radPredDetektorom = simulacia.RadPredDetektorom2;
                    detektor = simulacia.Detektor2;
                    break;
                default:
                    throw new Exception("Neplatny rad cestujuceho.");
            }

            // Uvolni detektor po osobnej prehliadke
            if (radPredDetektorom.Count > 0)
            {
                Cestujuci dalsiCestujuci = radPredDetektorom.Peek();
                detektor.JeVolny = false;
                simulacia.ScheduleEvent(new EZaciatokPrehliadkyDetektor(simulacia, dalsiCestujuci), simulacia.CurrentTime);
            }
            else
            {
                detektor.JeVolny = true;
            }

            if (cestujuci.MaxPocetPrepraviek > 0)
            {
                radPredZberomPrepraviek.Enqueue(cestujuci);
                if (cestujuci.Rad == 0)
                    simulacia.PocetVRadePredZberom1.AddWeightedValue(radPredZberomPrepraviek.Count, simulacia.CurrentTime);
                else
                    simulacia.PocetVRadePredZberom2.AddWeightedValue(radPredZberomPrepraviek.Count, simulacia.CurrentTime);
                simulacia.PocetVRadePredZberomSpolu.AddWeightedValue(simulacia.RadPredZberomPrepraviek1.Count + simulacia.RadPredZberomPrepraviek2.Count, simulacia.CurrentTime);
                if (zberPrepraviekVolny)
                {
                    simulacia.ScheduleEvent(new EPrichodZberPrepraviek(simulacia, cestujuci), simulacia.CurrentTime);
                }
            }
            else
            {
                simulacia.CasVSystemeCollector.AddValue(simulacia.CurrentTime - cestujuci.CasPrichodu);
            }
            return simulacia.CurrentTime;
        }
    }
}
