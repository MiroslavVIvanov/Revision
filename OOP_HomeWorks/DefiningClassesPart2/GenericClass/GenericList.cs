////Problem 5. Generic class
////Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
////Keep the elements of the list in an array with fixed capacity which
////    is given as parameter in the class constructor.
////Implement methods for adding element, accessing element by index, 
////    removing element by index, inserting element at given position,
////    clearing the list, finding element by its value and ToString().
////Check all input parameters to avoid accessing elements at invalid positions.

////    Problem 6. Auto-grow
////Implement auto-grow functionality: when the internal array is full, 
////    create a new array of double size and move all elements to it.

namespace GenericClass
{
    using System;

    public class GenericList<T>
    {
        private T[] elementsArray;
        private int currentIndex;

        public GenericList(int initialSize = 16)
        {
            this.ElementsArray = new T[initialSize];
            this.CurrentMaxIndex = -1;
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
                return this.CurrentMaxIndex;
            }
        }

        public int CurrentMaxIndex
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

            this.ElementsArray[this.CurrentMaxIndex] = element;
            this.CurrentMaxIndex++;
        }

        public void RemoveAt(int index)
        {
            if (this.Count == 0 || index > this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index outside bounds of the generic list.");
            }

            T[] newArray = new T[this.Capacity];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = this.ElementsArray[i];
            }

            for (int i = index + 1; i < this.Capacity; i++)
            {
                newArray[i - 1] = this.ElementsArray[i];
            }

            this.ElementsArray = newArray;
            this.CurrentMaxIndex--;
        }

        public void InsertAt(T element, int index)
        {
            if (index > this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index outside bounds of the generic list.");
            }

            if (this.Count + 1 >= this.Capacity)
            {
                this.AutoGrow();
            }

            T[] newArray = new T[this.Capacity];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = this.ElementsArray[i];
            }

            newArray[index] = element;

            for (int i = index + 1; i < this.Capacity; i++)
            {
                newArray[i + 1] = this.ElementsArray[i];
            }

            this.CurrentMaxIndex++;
            this.ElementsArray = newArray;
        }

        public void Clear(int capacity = 16)
        {
            this.CurrentMaxIndex = 0;
            this.ElementsArray = new T[capacity];
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