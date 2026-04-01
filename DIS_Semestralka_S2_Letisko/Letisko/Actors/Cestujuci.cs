using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Actors
{
    public class Cestujuci : Actor
    {
        public double CasPrichodu { get; private set; }
        public double CasPrichoduPriRontgen { get; private set; }
        public double CasDovykladaniaPrepraviek { get; set; }
        public double CasNalozeniaPrepraviek { get; set; }
        public int Rad { get; private set; }
        public int MaxPocetPrepraviek { get; private set; }
        public int AktualnyPocetPrepraviek { get; set; }
        public int ID { get; private set; }

        public Cestujuci(double casPrichodu, int ID)
        {
            CasPrichodu = casPrichodu;
            CasPrichoduPriRontgen = -1;
            Rad = -1;


        }
        public int VyberRad(int[] dlzkyRadov, Random generatorGeneratorov)
        {
            if (Rad != -1)
            {
                throw new InvalidOperationException("Cestujuci uz si vybral rad.");
            }
            int minDlzka = int.MaxValue;
            int indexMinDlzky = -1;
            for (int i = 0; i < dlzkyRadov.Length; i++)
            {
                if (dlzkyRadov[i] < minDlzka)
                {
                    minDlzka = dlzkyRadov[i];
                    indexMinDlzky = i;
                }
            }
            bool rovnake = true;
            for (int i = 0; i < dlzkyRadov.Length; i++)
            {
                if (dlzkyRadov[i] != minDlzka)
                {
                    rovnake = false;
                    break;
                }
            }
            if (rovnake)
            {
                Random random = new Random(generatorGeneratorov.Next());
                indexMinDlzky = random.Next(0, dlzkyRadov.Length);
            }
            Rad = indexMinDlzky;
            
            return indexMinDlzky;
            
        }
        public void PrichodPriRontgen(double casPrichoduPriRontgen)
        {
            if (CasPrichoduPriRontgen != -1)
            {
                throw new InvalidOperationException("Cestujuci uz prisiel k rontgenu.");
            }
            CasPrichoduPriRontgen = casPrichoduPriRontgen;
        }
    }
}
