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