using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Simulation.Event_Based
{
    public abstract class Event
    {
        protected Event_Core Core { get; private set; }
        protected Actor Actor { get; private set; }
        protected Event(Event_Core core, Actor actor) 
        { 
            Core = core;
            Actor = actor;
        }
        public abstract double Execute();
    }
}
