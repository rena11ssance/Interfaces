using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Арифметическая прогрессия (шаг = 5):");
            ISeries arith = new ArithProgression(5);
            arith.SetStart(10);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(arith.GetNext());
            }

            Console.WriteLine("\nГеометрическая прогрессия (знаменатель = 4): ");
            ISeries geom = new GeomProgression(4);
            geom.SetStart(3);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(geom.GetNext());
            }

            geom.Reset();

            Console.WriteLine($"\nПосле сброса: {geom.GetNext()}");

            Console.ReadKey();
        }
    }
}
