using DIS_Semestralka_S2_Letisko.Letisko.Actors;
using DIS_Semestralka_S2_Letisko.Letisko.Events.Rontgen;
using DIS_Semestralka_S2_Letisko.Simulation.Actors;
using DIS_Semestralka_S2_Letisko.Simulation.Event_Based;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko.Letisko.Events.Arrival
{
    public class EPrichodCestujuceho : EventCestujuci
    {
        public EPrichodCestujuceho(LetiskoSimulation core, Cestujuci actor) : base(core, actor)
        {
        }

        public override double Execute()
        {
            LetiskoSimulation simulacia = (LetiskoSimulation)Core;
            Cestujuci cestujuci = (Cestujuci)Actor;
            simulacia.PocetCestujucich++;
            int pocetPrepraviek = (int)simulacia.GeneratorPercentTable.Generate();
            cestujuci.MaxPocetPrepraviek = pocetPrepraviek;
            cestujuci.AktualnyPocetPrepraviek = pocetPrepraviek;
            double nasledujuciPrichod = simulacia.GeneratorPrichodov.Generate() + simulacia.CurrentTime;
            simulacia.ScheduleEvent(new EPrichodCestujuceho(simulacia, new Cestujuci(nasledujuciPrichod, simulacia.PocetCestujucich)), nasledujuciPrichod);
            int[] dlzkyRadov = new int[]
            {
                simulacia.RadPredRontgenom1.Count,
                simulacia.RadPredRontgenom2.Count
            };
            cestujuci.VyberRad(dlzkyRadov, simulacia.GeneratorGeneratorov);
            switch (cestujuci.Rad)
            {
                case 0:
                    simulacia.RadPredRontgenom1.Enqueue(cestujuci);

                    simulacia.PocetVRadePredRontgenom1.AddWeightedValue(simulacia.RadPredRontgenom1.Count, simulacia.CurrentTime);
                    simulacia.PocetVRadePredRontgenomSpolu.AddWeightedValue(simulacia.RadPredRontgenom1.Count + simulacia.RadPredRontgenom2.Count, simulacia.CurrentTime);
                    if (simulacia.Rontgen1.JeVolnyCestujuci)
                    {
                        simulacia.Rontgen1.JeVolnyCestujuci = false;
                        cestujuci.PrichodPriRontgen(simulacia.CurrentTime);
                        simulacia.ScheduleEvent(new EPrichodCestujucehoRontgen(simulacia, cestujuci), simulacia.CurrentTime);
                    }
                    break;
                case 1:
                    simulacia.RadPredRontgenom2.Enqueue(cestujuci);

                    simulacia.PocetVRadePredRontgenom2.AddWeightedValue(simulacia.RadPredRontgenom2.Count, simulacia.CurrentTime);
                    simulacia.PocetVRadePredRontgenomSpolu.AddWeightedValue(simulacia.RadPredRontgenom1.Count + simulacia.RadPredRontgenom2.Count, simulacia.CurrentTime);
                    if (simulacia.Rontgen2.JeVolnyCestujuci)
                    {
                        simulacia.Rontgen2.JeVolnyCestujuci = false;
                        cestujuci.PrichodPriRontgen(simulacia.CurrentTime);
                        simulacia.ScheduleEvent(new EPrichodCestujucehoRontgen(simulacia, cestujuci), simulacia.CurrentTime);
                    }
                    break;
                default:
                    throw new Exception("Neplatný rad");
            }
            return simulacia.CurrentTime;
        }
    }
}
