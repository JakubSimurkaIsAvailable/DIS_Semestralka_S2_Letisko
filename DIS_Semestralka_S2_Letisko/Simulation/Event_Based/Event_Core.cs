using DIS_Semestralka_S2_Letisko.Simulation.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Simulation.Event_Based
{
    public abstract class Event_Core : MonteCarlo_Core
    {
        public double CurrentTime { get; protected set; }
        protected PriorityQueue<Event, double> EventQueue { get; set; }
        public bool Pause { get; set; }
        public bool Slowdown { get; set; }
        protected double TimeLimit { get; set; }
        public int Length { get; set; }
        public double Rate { get; set; }
        public bool EarlyStop { get; set; }
        private List<ISimDelegate> Delegates { get; set; }

        protected Event_Core()
        {
            Delegates = new List<ISimDelegate>();
        }
        protected override void DoReplication()
        {
            while (EventQueue.Count > 0 && CurrentTime < TimeLimit && Run)
            {
                while (Pause)
                {
                    Thread.Sleep(100);
                }
                EventQueue.TryDequeue(out Event e, out double scheduledTime);
                CurrentTime = scheduledTime;
                e.Execute();
                if(Slowdown && e is SleepEvent)
                {
                    RefreshGUI();
                    ScheduleEvent(new SleepEvent(this, Length), CurrentTime + Length * Rate);
                }
            }
            if(!Run)
            {
                EarlyStop = true;
            }
        }

        

        public void ScheduleEvent(Event e, double time)
        {
            if(time >= CurrentTime)
                EventQueue.Enqueue(e, time);
        }
        public void RegisterDelegate(ISimDelegate simDelegate)
        {
            Delegates.Add(simDelegate);
        }
        protected void RefreshGUI()
        {
            foreach (var simDelegate in Delegates)
            {
                simDelegate.Refresh(this);
            }
        }
    }
}
