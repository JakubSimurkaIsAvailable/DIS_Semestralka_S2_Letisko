using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events
{
    internal class EWarmupEnd : Event
    {
        public EWarmupEnd(LetiskoSimulation core) : base(core, null) { }

        public override double Execute()
        {
            var sim = (LetiskoSimulation)Core;
            sim.ResetPerReplicationStats();
            sim.PocetCestujucich = 0;
            return sim.CurrentTime;
        }

    }
}
