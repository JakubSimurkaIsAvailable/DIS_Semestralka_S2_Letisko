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
    public class EZaciatokOsobnejPrehliadky : EventCestujuci
    {
        public EZaciatokOsobnejPrehliadky(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            double casOsobnejPrehliadky = simulacia.GeneratorDodatocnejPrehliadky.Generate();
            simulacia.ScheduleEvent(new EKoniecOsobnejPrehliadky(simulacia, cestujuci), casOsobnejPrehliadky + simulacia.CurrentTime);
            return simulacia.CurrentTime;
        }
    }
}
