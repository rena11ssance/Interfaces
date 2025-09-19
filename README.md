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
        private int startValue;
        private int currentValue;
        private int step;

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
        private int startValue;
        private int currentValue;
        private int denominatorValue;

        public GeomProgression(int denominatorValue = 2)
        {
            if (denominatorValue == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0.");
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
            try
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

            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено не число.");
            }

            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: введено слишком большое число.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
```
___
