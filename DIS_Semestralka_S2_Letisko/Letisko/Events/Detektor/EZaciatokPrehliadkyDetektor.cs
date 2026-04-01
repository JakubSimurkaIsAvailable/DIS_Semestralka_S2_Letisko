using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Detektor
{
    public class EZaciatokPrehliadkyDetektor : EventCestujuci
    {
        public EZaciatokPrehliadkyDetektor(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            double casPrehliadky = simulacia.GeneratorDetektor.Generate();
            simulacia.ScheduleEvent(new EKoniecPrehliadkyDetektor(simulacia, cestujuci), casPrehliadky + simulacia.CurrentTime);
            return simulacia.CurrentTime;
        }
    }
}
