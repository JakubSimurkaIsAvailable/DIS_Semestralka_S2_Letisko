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
    public class EKoniecPrehliadkyDetektor : EventCestujuci
    {
        public EKoniecPrehliadkyDetektor(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            Queue<Cestujuci> radPredDetektorom;
            DetektorKovu detektor;
            Queue<Cestujuci> radPredZberomPrepraviek;
            bool zberPrepraviekVolny;
            switch (cestujuci.Rad)
            {
                case 0:
                    radPredDetektorom = simulacia.RadPredDetektorom1;
                    detektor = simulacia.Detektor1;
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek1;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek1Volny;
                    break;
                case 1:
                    radPredDetektorom = simulacia.RadPredDetektorom2;
                    detektor = simulacia.Detektor2;
                    radPredZberomPrepraviek = simulacia.RadPredZberomPrepraviek2;
                    zberPrepraviekVolny = simulacia.ZberPrepraviek2Volny;
                    break;
                default:
                    throw new InvalidOperationException("Neplatny rad cestujuceho.");
            }
            var cestujuciKontrola = radPredDetektorom.Peek();
            if (cestujuci.Rad == 0)
                simulacia.PocetVRadePredDetektorom1.AddWeightedValue(radPredDetektorom.Count, simulacia.CurrentTime);
            else
                simulacia.PocetVRadePredDetektorom2.AddWeightedValue(radPredDetektorom.Count, simulacia.CurrentTime);
            simulacia.PocetVRadePredDetektoromSpolu.AddWeightedValue(simulacia.RadPredDetektorom1.Count + simulacia.RadPredDetektorom2.Count, simulacia.CurrentTime);
            if (cestujuciKontrola.ID != cestujuci.ID)
            {
                throw new InvalidOperationException("Cestujuci na konci kontroly neni cestujuci na konci radu.");
            }
            if(cestujuci.OsobnaPrehliadka < 0.19)
            {
                simulacia.ScheduleEvent(new EZaciatokOsobnejPrehliadky(simulacia, cestujuci), simulacia.CurrentTime);
            } else
            {
                radPredDetektorom.Dequeue();
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
            }
            
            return simulacia.CurrentTime;
        }
    }
}
