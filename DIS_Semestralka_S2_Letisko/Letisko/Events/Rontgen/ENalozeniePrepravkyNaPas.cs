using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Rontgen
{
    public class ENalozeniePrepravkyNaPas : Event
    {
        public ENalozeniePrepravkyNaPas(Event_Core core, Actor actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            throw new NotImplementedException();
        }
    }
}
