using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Zber;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Odchod
{
    public class EPrichodZberPrepraviek : EventCestujuci
    {
        public EPrichodZberPrepraviek(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            switch (cestujuci.Rad)
            {
                case 0:
                    simulacia.ZberPrepraviek1Volny = false;
                    break;
                case 1:
                    simulacia.ZberPrepraviek2Volny = false;
                    break;
                default:
                    throw new Exception("Neplatny rad cestujuceho");
            }

            simulacia.ScheduleEvent(new EZberPrepravky(simulacia, cestujuci), simulacia.CurrentTime);
            return simulacia.CurrentTime;
        }
    }
}
