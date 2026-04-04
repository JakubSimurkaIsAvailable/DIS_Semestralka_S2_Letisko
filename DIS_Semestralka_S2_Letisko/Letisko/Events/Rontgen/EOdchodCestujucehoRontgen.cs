using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Detektor;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Rontgen
{
    public class EOdchodCestujucehoRontgen : EventCestujuci
    {
        public EOdchodCestujucehoRontgen(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;

            Queue<Cestujuci> rad;
            Objects.Rontgen rontgen;
            Queue<Cestujuci> radDetektor;
            Objects.DetektorKovu detektor;
            switch (cestujuci.Rad)
            {
                case 0:
                    rad = simulacia.RadPredRontgenom1;
                    rontgen = simulacia.Rontgen1;
                    radDetektor = simulacia.RadPredDetektorom1;
                    detektor = simulacia.Detektor1;
                    break;
                case 1:
                    rad = simulacia.RadPredRontgenom2;
                    rontgen = simulacia.Rontgen2;
                    radDetektor = simulacia.RadPredDetektorom2;
                    detektor = simulacia.Detektor2;
                    break;
                default:
                    throw new Exception("Neplatny rad cestujuceho.");
            }
            Cestujuci kontrola = rad.Dequeue();
            if (kontrola.ID != cestujuci.ID)
            {
                throw new Exception("Cestujuci sa nezhoduje");
            }

            if (cestujuci.Rad == 0)
                simulacia.PocetVRadePredRontgenom1.AddWeightedValue(rad.Count, simulacia.CurrentTime);
            else
                simulacia.PocetVRadePredRontgenom2.AddWeightedValue(rad.Count, simulacia.CurrentTime);
            simulacia.PocetVRadePredRontgenomSpolu.AddWeightedValue(simulacia.RadPredRontgenom1.Count + simulacia.RadPredRontgenom2.Count, simulacia.CurrentTime);

            

            if (rad.Count > 0)
            {
                Cestujuci dalsiCestujuci = rad.Peek();
                dalsiCestujuci.PrichodPriRontgen(simulacia.CurrentTime);
                simulacia.ScheduleEvent(new EPrichodCestujucehoRontgen(simulacia, dalsiCestujuci), simulacia.CurrentTime);
            }
            else
            {
                rontgen.JeVolnyCestujuci = true;
            }

            if (detektor.JeVolny)
            {
                detektor.JeVolny = false;
                simulacia.ScheduleEvent(new EZaciatokPrehliadkyDetektor(simulacia, cestujuci), simulacia.CurrentTime);
            }
            radDetektor.Enqueue(cestujuci);
            if (cestujuci.Rad == 0)
                simulacia.PocetVRadePredDetektorom1.AddWeightedValue(radDetektor.Count, simulacia.CurrentTime);
            else
                simulacia.PocetVRadePredDetektorom2.AddWeightedValue(radDetektor.Count, simulacia.CurrentTime);
            simulacia.PocetVRadePredDetektoromSpolu.AddWeightedValue(simulacia.RadPredDetektorom1.Count + simulacia.RadPredDetektorom2.Count, simulacia.CurrentTime);
            return simulacia.CurrentTime;
        }
    }
}
