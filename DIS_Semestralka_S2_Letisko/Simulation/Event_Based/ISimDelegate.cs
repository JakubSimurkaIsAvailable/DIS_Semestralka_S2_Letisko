using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Simulation.Event_Based
{
    public interface ISimDelegate
    {
        void Refresh(Event_Core simulation);
    }
}
