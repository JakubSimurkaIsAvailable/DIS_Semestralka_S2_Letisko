using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events
{
    public class ECollectData : Event
    {
        public ECollectData(LetiskoSimulation sim) : base(sim, null) { }

        //2.5.2
        public override double Execute()
        {
            var sim = (LetiskoSimulation)Core;
            sim.WriteObservationRow();
            sim.ScheduleEvent(new ECollectData(sim), sim.CurrentTime + sim.CollectInterval);
            return sim.CurrentTime;
        }
    }
}
