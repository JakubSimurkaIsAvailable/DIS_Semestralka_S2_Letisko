using DIS_Semestralka_S2_Letisko.Generators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S2_Letisko
{
    public static class GeneratorTester
    {
        public static void TestTrojuholnikovyGenerator()
        {
            Random random = new Random();
            double minimum = 1.0;
            double modus = 3.0;
            double maximum = 5.0;
            TrojuholnikovyGenerator generator = new TrojuholnikovyGenerator(random, minimum, modus, maximum);
            Console.WriteLine("Testing TrojuholnikovyGenerator:");

            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "trojuholnikovy_values.csv");
            using (StreamWriter writer = new StreamWriter(csvFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Value");

                for (int i = 0; i < 10000; i++)
                {
                    double value = generator.Generate();
                    Console.WriteLine($"Generated value: {value}");

                    bool isValid = value >= minimum && value <= maximum;
                    if (!isValid)
                    {
                        Console.WriteLine("Error: Generated value is out of bounds!");
                    }

                    writer.WriteLine($"{value:F10}");
                }
            }

            Console.WriteLine($"Results saved to: {csvFilePath}");
        }

        public static void TestExponencialnyGenerator()
        {
            Random random = new Random();
            double lambda = 0.5;
            ExponencialnyGenerator generator = new ExponencialnyGenerator(random, lambda);
            Console.WriteLine("Testing ExponencialnyGenerator:");

            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "exponencialny_values.csv");
            using (StreamWriter writer = new StreamWriter(csvFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Index,Value,IsValid");

                for (int i = 0; i < 10000; i++)
                {
                    double value = generator.Generate();
                    Console.WriteLine($"Generated value: {value}");

                    bool isValid = value >= 0;
                    if (!isValid)
                    {
                        Console.WriteLine("Error: Generated value is negative!");
                    }

                    writer.WriteLine($"{i},{value:F10},{isValid}");
                }
            }

            Console.WriteLine($"Results saved to: {csvFilePath}");
        }

        public static void TestPercentTable()
        {
            Random random = new Random();
            double[] chances = { 0.5, 0.3, 0.2 };
            double[] values = { 10.0, 20.0, 30.0 };
            PercentTable percentTable = new PercentTable(random, chances, values);
            Console.WriteLine("Testing PercentTable:");
            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "percent_table_values.csv");
            using (StreamWriter writer = new StreamWriter(csvFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Value");
                for (int i = 0; i < 10000; i++)
                {
                    double value = percentTable.Generate();
                    Console.WriteLine($"Generated value: {value}");
                    writer.WriteLine($"{value:F10}");
                }
            }
            Console.WriteLine($"Results saved to: {csvFilePath}");
        }
    }
}
