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
            if(radPredDetektorom.Count > 0)
            {
                Cestujuci dalsiCestujuci = radPredDetektorom.Peek();
                detektor.JeVolny = false;
                EKoniecOsobnejPrehliadky eventKoniecOsobnejPrehliadky = new EKoniecOsobnejPrehliadky(simulacia, dalsiCestujuci);
                simulacia.ScheduleEvent(eventKoniecOsobnejPrehliadky, simulacia.GeneratorDetektor.Generate());
            }
            else
            {
                detektor.JeVolny = true;
            }
            radPredZberomPrepraviek.Enqueue(cestujuci);
            if(zberPrepraviekVolny)
            {
                simulacia.ScheduleEvent(new EPrichodZberPrepraviek(simulacia, cestujuci), simulacia.CurrentTime);
            }
            return simulacia.CurrentTime;
        }
    }
}
