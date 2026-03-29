using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Simulation.Collectors
{
    public class StatisticsCollector
    {
        public int ValueCounter { get; private set; }
        public double Average { get; private set; }
        public StatisticsCollector() 
        { 
            ValueCounter = 0;
            Average = 0;
        }

        public void AddValue(double value)
        {
            Average = (Average * ValueCounter + value) / (ValueCounter + 1);
            ValueCounter++;
            
        }
    }
}
