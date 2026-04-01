using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events
{
    public abstract class EventCestujuci : Event
    {
        public EventCestujuci(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }


    }
}
