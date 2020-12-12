using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpOop.ArrayLIst
{
    class List<T> : IList<T>
    {
        private T[] items;
        private int modCount;
        private const int DefaultCapacity = 4;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
                }

                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
                }

                return items[index];
            }

            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Index = " + index + ". Index должен быть < " + Count);
                }

                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
                }

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
                    throw new ArgumentOutOfRangeException(nameof(value), "Вместимость = " + value + " меньше Count = " + Count);
                }

                Array.Resize(ref items, value);
            }
        }

        public List()
        {
            Capacity = DefaultCapacity;
        }

        public List(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Вместимость = " + capacity + ". Вместимость должна быть > 0");
            }

            Capacity = capacity;
        }

        public void Add(T item)
        {
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
            if (items.Length == 0)
            {
                Capacity = DefaultCapacity;
            }
            else
            {
                Capacity = items.Length * 2;
            }

            modCount++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            Count--;
            modCount++;
            items[Count] = default;
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
            if (Count > 0)
            {
                Array.Clear(items, 0, Count);
                Count = 0;
                modCount++;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            RemoveAt(itemIndex);

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index = " + arrayIndex + ". Index  должен быть >= 0");
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
                if (Equals(item, items[i]))
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
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
            }

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть <= " + Count);
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

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("[");

            foreach (T e in this)
            {
                stringBuilder.Append(e).Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append("]").ToString();
        }
    }
}
