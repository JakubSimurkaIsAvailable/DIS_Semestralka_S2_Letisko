using DIS_Semestralka_S2_Letisko.Generators.Components;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Test_Simulation
{
    public class Student : Actor
    {
        public double CasPrichodu { get; private set; }
        public double CasZaciatkuObsluhy { get; private set; }
        public double OdchodZakaznika { get; private set; }
        public Student(double casPrichodu) 
        {
            CasPrichodu = casPrichodu;
            CasZaciatkuObsluhy = -1;
            OdchodZakaznika = -1;
        }
        public void ZacniObsluhu(double casZaciatkuObsluhy)
        {
            if(CasZaciatkuObsluhy != -1)
            {
                throw new InvalidOperationException("Obsluha uz zacala.");
            }
            CasZaciatkuObsluhy = casZaciatkuObsluhy;
        }
        public void SkonciObsluhu(double casSkonceniaObsluhy)
        {
            if (CasZaciatkuObsluhy == -1)
            {
                throw new InvalidOperationException("Obsluha este nezacala.");
            }
            if (OdchodZakaznika != -1)
            {
                throw new InvalidOperationException("Obsluha uz skoncila.");
            }
            OdchodZakaznika = casSkonceniaObsluhy;
        }
    }
}
