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
            Queue<Cestujuci> radPredDetektorom;
            Queue<Cestujuci> radPredZberomPrepraviek;
            DetektorKovu detektor;
            bool zberPrepraviekVolny;
            switch (cestujuci.Rad)
            {
                case 0:
                    radPredDetektorom = simulacia.RadPredDetektorom1;
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek1;
                    detektor = simulacia.Detektor1;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek1Volny;
                    break;
                case 1:
                    radPredDetektorom = simulacia.RadPredDetektorom2;
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek2;
                    detektor = simulacia.Detektor2;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek2Volny;
                    break;
                default:
                    throw new Exception("Neplatny rad cestujuceho.");
            }
            
            if (cestujuci.Rad == 0)
                simulacia.PocetVRadePredDetektorom1.AddWeightedValue(radPredDetektorom.Count, simulacia.CurrentTime);
            else
                simulacia.PocetVRadePredDetektorom2.AddWeightedValue(radPredDetektorom.Count, simulacia.CurrentTime);
            simulacia.PocetVRadePredDetektoromSpolu.AddWeightedValue(simulacia.RadPredDetektorom1.Count + simulacia.RadPredDetektorom2.Count, simulacia.CurrentTime);
            Cestujuci kontrola = radPredDetektorom.Dequeue();
            if (kontrola.ID != cestujuci.ID)
            {
                throw new Exception("Cestujuci sa nezhoduje.");
            }
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
            
            if (cestujuci.Rad == 0)
                simulacia.PocetVRadePredZberom1.AddWeightedValue(radPredZberomPrepraviek.Count, simulacia.CurrentTime);
            else
                simulacia.PocetVRadePredZberom2.AddWeightedValue(radPredZberomPrepraviek.Count, simulacia.CurrentTime);
            simulacia.PocetVRadePredZberomSpolu.AddWeightedValue(simulacia.RadPredZberomPrepraviek1.Count + simulacia.RadPredZberomPrepraviek2.Count, simulacia.CurrentTime);
            radPredZberomPrepraviek.Enqueue(cestujuci);
            if (zberPrepraviekVolny)
            {
                simulacia.ScheduleEvent(new EPrichodZberPrepraviek(simulacia, cestujuci), simulacia.CurrentTime);
            }
            return simulacia.CurrentTime;
        }
    }
}
