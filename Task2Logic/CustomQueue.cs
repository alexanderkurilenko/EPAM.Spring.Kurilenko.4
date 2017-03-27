using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    /// <summary>
    /// Custom implementation of Queue based on array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomQueue<T>
    {
        #region Fields
        private T[] array;
        private int head;
        private int tail;
        #endregion

        #region Properties
        public int Count { get; private set; }
        #endregion

        #region Ctors
        public CustomQueue()
        {
            array = new T[0];
        }
        
        public CustomQueue(int capacity) 
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            array = new T[capacity];
            this.head = 0;
            this.tail = 0;
            this.Count = 0;
        }

        public CustomQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            array = new T[50];
            Count = 0;
            foreach (T variable in collection)
                Enqueue(variable);
        }
        #endregion

        #region Methods
        
        /// <summary>
        /// Return the head element.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return array[head];
        }

        /// <summary>
        /// Extraction of the element.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            T onHead = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            Count--;
            return onHead;
        }

        /// <summary>
        /// Insertion of the element
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (Count == array.Length)
            {
                int capacity = array.Length * 2;
                if (capacity < (array.Length + 4))
                    capacity = array.Length + 4;
                SetCapacity(capacity);
            }
            array[tail] = item;
            tail = (tail + 1) % array.Length;
            Count++;
        }

        /// <summary>
        /// Search element in queue
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public bool Contains(T elem)
        {
            foreach (T item in array)
            {
                if (elem.Equals(item))
                {
                    return true;
                }
            }
           
            return false;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Changing the capacity of inner array
        /// </summary>
        /// <param name="capacity"></param>
        private void SetCapacity(int capacity)
        {
            var tmpArray = new T[capacity];
            
            if (Count > 0)
            {
                if (head < tail)
                    Array.Copy(array, head, tmpArray, 0, Count);
                else
                {
                    Array.Copy(array, head, tmpArray, 0, array.Length - head);
                    Array.Copy(array, 0, tmpArray, array.Length - head, tail);
                }
            }

            array = tmpArray;
            head = 0;
            tail = (Count == capacity) ? 0 : Count;
        }
        #endregion
    }
}
