using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpOop.HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private readonly List<T>[] listsArray;
        private int modCount;
        private const int ListsArrayDefaultSize = 20;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            listsArray = new List<T>[ListsArrayDefaultSize];
        }

        public HashTable(int listsArraySize)
        {
            listsArray = new List<T>[listsArraySize];
        }

        private int GetIndex(T item)
        {
            return item == null ? 0 : Math.Abs(item.GetHashCode() % listsArray.Length);
        }

        public void Add(T item)
        {
            int indexForAdd = GetIndex(item);

            if (listsArray[indexForAdd] == null)
            {
                listsArray[indexForAdd] = new List<T> { item };
            }
            else
            {
                listsArray[indexForAdd].Add(item);
            }

            modCount++;
            Count++;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(listsArray, 0, listsArray.Length);
                Count = 0;
                modCount++;
            }           
        }

        public bool Contains(T item)
        {
            int itemIndex = GetIndex(item);

            if (listsArray[itemIndex] == null)
            {
                return false;
            }

            return listsArray[itemIndex].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index = " + arrayIndex + ". Index должен быть >= 0");
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

            int indexForCopy = arrayIndex;

            foreach (T e in this)
            {
                array[indexForCopy] = e;
                indexForCopy++;
            }
        }

        public bool Remove(T item)
        {
            int itemIndex = GetIndex(item);

            if (listsArray[itemIndex] == null)
            {
                return false;
            }

            bool isRemoved = listsArray[itemIndex].Remove(item);

            if (isRemoved)
            {
                modCount++;
            }

            return isRemoved;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int startModCount = modCount;

            for (int i = 0; i < listsArray.Length; i++)
            {
                if (startModCount != modCount)
                {
                    throw new InvalidOperationException("Список был изменен");
                }

                if (listsArray[i] == null)
                {
                    continue;
                }

                foreach (T e in listsArray[i])
                {
                    yield return e;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
