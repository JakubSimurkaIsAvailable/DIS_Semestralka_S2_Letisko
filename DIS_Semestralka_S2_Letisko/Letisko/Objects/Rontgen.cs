using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Objects
{
    public class Rontgen
    {
        public int MaxBefore { get; private set; }
        public int MaxAfter { get; private set; }
        public Queue<Prepravka> PrepravkyPredRontgenom { get; private set; }
        public Queue<Prepravka> PrepravkyZaRontgenom { get; private set; }
        public int PocetPrepraviekPred { get { return PrepravkyPredRontgenom.Count; } }
        public int PocetPrepraviekZa { get { return PrepravkyZaRontgenom.Count; } }
        public bool JeVolnyCestujuci { get; set; }
        public bool JeVolnyPrepravka { get; set; }

        public Rontgen(int maxBefore, int maxAfter)
        {
            MaxAfter = maxAfter;
            MaxBefore = maxBefore;
            PrepravkyPredRontgenom = new Queue<Prepravka>();
            PrepravkyZaRontgenom = new Queue<Prepravka>();
            JeVolnyCestujuci = true;
            JeVolnyPrepravka = true;
        }
        public bool PridajPrepravku(Prepravka prepravka)
        {
            if (PocetPrepraviekPred < MaxBefore)
            {
                PrepravkyPredRontgenom.Enqueue(prepravka);
                return true;
            }
            return false;
        }

        public bool SkenujPrepravku()
        {
            if (PocetPrepraviekPred > 0 && PocetPrepraviekZa < MaxAfter)
            {
                Prepravka prepravka = PrepravkyPredRontgenom.Dequeue();
                PrepravkyZaRontgenom.Enqueue(prepravka);
                return true;
            }
            return false;
        }
        public bool OdoberPrepravku()
        {
            if (PocetPrepraviekZa > 0)
            {
                Prepravka prepravka = PrepravkyZaRontgenom.Dequeue();
                return true;
            }
            return false;
        }
        public Prepravka PeekPrepravkuPred()
        {
            if (PocetPrepraviekPred > 0)
            {
                return PrepravkyPredRontgenom.Peek();
            }
            return null;
        }
        public Prepravka PeekPrepravkuZa()
        {
            if (PocetPrepraviekZa > 0)
            {
                return PrepravkyZaRontgenom.Peek();
            }
            return null;
        }
    }
}
