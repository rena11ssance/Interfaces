# Интерфейсы

Задача. Разработать интерфейс ISeries генерации ряда чисел. Интерфейс содержит следующие элементы:

— метод void SetStart(int x) - устанавливает начальное значение;

— метод int GetNext() - возвращает следующее число ряда;

— метод void Reset() - выполняет сброс к начальному значению.

Разработать классы ArithProgression и GeomProgression, которые реализуют интерфейс ISeries. В классах реализовать методы интерфейса в соответствии с логикой арифметической и геометрической прогрессии соответственно.

Решение:
> Interface.cs
```
using System;

namespace Interfaces
{
    interface ISeries
    {
        void SetStart(int x);
        int GetNext();
        void Reset();
    }

    class ArithProgression : ISeries
    {
        private int startValue { get; set; }
        private int currentValue { get; set; }
        private int step { get; set; }

        public ArithProgression(int step = 1)
        {
            this.step = step;
        }

        public int GetNext()
        {
            currentValue += step;
            return currentValue;
        }

        public void Reset()
        {
            currentValue = startValue;
        }

        public void SetStart(int x)
        {
            startValue = x;
            currentValue = x;
        }
    }

    class GeomProgression : ISeries
    {
        private int startValue { get; set; }
        private int currentValue { get; set; }
        private int denominatorValue { get; set; }

        public GeomProgression(int denominatorValue = 2)
        {
            if (denominatorValue == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            this.denominatorValue = denominatorValue;
        }

        public int GetNext()
        {
            currentValue *= denominatorValue;
            return currentValue;
        }

        public void Reset()
        {
            currentValue = startValue;
        }

        public void SetStart(int x)
        {
            startValue = x;
            currentValue = x;
        }
    }
}
```
___
> Program.cs
```
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

```
___
