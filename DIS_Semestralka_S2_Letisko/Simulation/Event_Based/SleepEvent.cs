using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Simulation.Event_Based
{
    public class SleepEvent : Event
    {
        int _length = 0;
        public SleepEvent(Event_Core core, int length) : base(core, null)
        {
            _length = length;
        }

        public override double Execute()
        {
            Thread.Sleep(_length);
            return Core.CurrentTime;
        }
    }
}
