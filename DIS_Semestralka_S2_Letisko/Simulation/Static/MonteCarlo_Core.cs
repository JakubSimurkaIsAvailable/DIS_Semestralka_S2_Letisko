using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Simulation.Static
{
    public abstract class MonteCarlo_Core
    {
        private int currentReplication;
        public bool Run { get; set; }
        public int CurrentReplication { get => currentReplication; }
        public int ReplicationCount { get; private set; }

        public void RunSimulation(int replicationCount)
        {
            ReplicationCount = replicationCount;
            Run = true;
            currentReplication = 1;
            BeforeSimulation();
            while (currentReplication <= replicationCount && Run == true)
            {
                BeforeReplication();
                DoReplication();
                AfterReplication();
                currentReplication++;
            }
            AfterSimulation();
        }

        protected abstract void BeforeSimulation();
        protected abstract void BeforeReplication();
        protected abstract void DoReplication();
        protected abstract void AfterReplication();
        protected abstract void AfterSimulation();
    }
}
