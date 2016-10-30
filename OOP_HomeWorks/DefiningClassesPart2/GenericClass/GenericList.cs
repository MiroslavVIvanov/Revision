using System;

namespace GenericClass
{
    public class GenericList<T>
    {
        private T[] elementsArray;
        private int currentIndex;

        public GenericList(int initialSize = 16)
        {
            this.ElementsArray = new T[initialSize];
            this.CurrentIndex = -1;
        }

        public int Capacity
        {
            get
            {
                return this.ElementsArray.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.CurrentIndex;
            }
        }

        private T[] ElementsArray
        {
            get
            {
                return this.elementsArray;
            }

            set
            {
                this.elementsArray = value;
            }
        }

        public int CurrentIndex
        {
            get
            {
                return this.currentIndex;
            }

            set
            {
                if (value < 0)
                {
                    this.currentIndex = 0;
                }
                else
                {
                    this.currentIndex = value;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (this.Count == 0 || index > this.currentIndex || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.ElementsArray[index];
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.AutoGrow();
            }

            this.ElementsArray[this.CurrentIndex] = element;
            this.CurrentIndex++;
        }

        private void AutoGrow()
        {
            T[] newArray = new T[this.Capacity * 2];

            for (int i = 0; i < this.Capacity; i++)
            {
                newArray[i] = this.ElementsArray[i];
            }

            this.ElementsArray = newArray;
        }
    }
}