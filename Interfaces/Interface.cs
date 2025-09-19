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
            if (denominatorValue <= 1)
            {
                throw new ArgumentException("Знаменатель должен быть больше 1.");
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