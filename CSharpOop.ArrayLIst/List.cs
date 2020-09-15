using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpOop.ArrayLIst
{
    class List<T> : IList<T>, IEnumerable
    {
        private T[] items;
        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public T this[int index]
        {
            get
            {
                return items[index];
            }

            set
            {
                items[index] = value;
            }
        }

        public int Capacity
        {
            get
            {
                return items.Length;
            }

            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Вместимость меньше Count", nameof(value));
                }

                items = new T[value];
            }
        }

        public List()
        {
            Capacity = 4;
        }

        public List(int capacity)
        {
            Capacity = capacity;
        }

        public void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Список досупен только для чтения");
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = item;

            Count++;
            modCount++;
        }

        private void IncreaseCapacity()
        {
            T[] oldItems = items;

            if (oldItems.Length == 0)
            {
                Capacity = oldItems.Length + 4;
            }
            else
            {
                Capacity = oldItems.Length * 2;
            }

            Array.Copy(oldItems, 0, items, 0, oldItems.Length);
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Список досупен только для чтения");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть > 0");
            }

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть <= " + Count);
            }

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            Count--;
            modCount++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int startModCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (startModCount != modCount)
                {
                    throw new InvalidOperationException("Список был изменен");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Список досупен только для чтения");
            }

            if (Count > 0)
            {
                Array.Clear(items, 0, Count);
                Count = 0;
                modCount++;
            }
        }

        public bool Contains(T item)
        {
            foreach (T e in this)
            {
                if (item != null && item.Equals(e))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Список досупен только для чтения");
            }

            for (int i = 0; i < Count; i++)
            {
                if (item != null && item.Equals(items[i]))
                {
                    if (i < Count - 1)
                    {
                        Array.Copy(items, i + 1, items, i, Count - i - 1);
                    }

                    Count--;
                    modCount++;

                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index = " + arrayIndex + ". Index  должен быть > 0");
            }

            if (arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index = " + arrayIndex + ". Index должен быть < " + array.Length);
            }

            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array имеет значение null");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Число элементов в списке больше доступного места, от положения " + arrayIndex + " до конца массива.");
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item != null && item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть > 0");
            }

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть <= " + Count);
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("Список досупен только для чтения");
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);
            items[index] = item;

            Count++;
            modCount++;
        }

        public void TrimExcess()
        {
            if (Count < 0.9 * items.Length)
            {
                Capacity = Count;
            }
        }
    }
}
