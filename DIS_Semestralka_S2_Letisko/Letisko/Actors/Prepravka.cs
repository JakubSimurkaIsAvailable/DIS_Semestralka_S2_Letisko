using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Actors
{
    public class Prepravka : Actor
    {
        public int ID { get; private set; }
        public int ID_Cestujuci { get; private set; }
        public double CasUlozeniaNaPasPredRontgenom { get; set; }
        public double CasZaciatkuRontgenu { get; set; }
        public double CasUkonceniaRontgenu { get; set; }
        public double CasOdberuZPasuPoRontgene { get; set; }

        public Prepravka(int ID_cestujuci, int prepravkaCislo)
        {
            ID_Cestujuci = ID_cestujuci;
            ID = prepravkaCislo;
        }
    }
}
