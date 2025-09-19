using System;
using System.Net.Http;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Задайте шаг для арифметической прогрессии: ");
            int step = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Арифметическая прогрессия (шаг = {step}):");
            ISeries arith = new ArithProgression(step);
            arith.SetStart(10);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(arith.GetNext());
            }

            try
            {
                Console.Write($"Задайте знаменатель для геометрической прогрессии: ");
                int denominatorValue = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\nГеометрическая прогрессия (знаменатель = {denominatorValue}): ");
                ISeries geom = new GeomProgression(denominatorValue);
                geom.SetStart(3);

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(geom.GetNext());
                }

                geom.Reset();

                Console.WriteLine($"\nПосле сброса: {geom.GetNext()}");
            }

            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
