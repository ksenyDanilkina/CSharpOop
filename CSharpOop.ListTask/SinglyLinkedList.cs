using System;
using System.Text;

namespace CSharpOop.ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Count { get; private set; }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Список пуст");
            }

            return head.Data;
        }

        public void AddFirst(T data)
        {
            head = new ListItem<T>(data, head);

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Список пуст");
            }

            T removedData = head.Data;
            head = head.Next;
            Count--;

            return removedData;
        }

        public T GetData(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }

            ListItem<T> currentItem = GetItemByIndex(index);

            return currentItem.Data;
        }

        public T SetData(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }

            ListItem<T> currentItem = GetItemByIndex(index);

            T changedData = currentItem.Data;
            currentItem.Data = data;

            return changedData;
        }

        private ListItem<T> GetItemByIndex(int index)
        {
            ListItem<T> item = head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

        public T RemoveByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> currentItem = GetItemByIndex(index - 1);

            T removedData = currentItem.Next.Data;
            currentItem.Next = currentItem.Next.Next;
            Count--;

            return removedData;
        }

        public void AddByIndex(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть >= 0");
            }

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть <= " + Count);
            }

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                ListItem<T> currentItem = GetItemByIndex(index - 1);

                ListItem<T> itemForAdd = new ListItem<T>(data, currentItem.Next);
                currentItem.Next = itemForAdd;
                Count++;
            }
        }

        public bool RemoveByData(T data)
        {
            for (ListItem<T> p = head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (Equals(p.Data, data))
                {
                    if (prev == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        prev.Next = p.Next;
                        Count--;
                    }

                    return true;
                }
            }

            return false;
        }

        public void Revert()
        {
            ListItem<T> previousItem = null;

            for (ListItem<T> p = head; p != null;)
            {
                ListItem<T> nextItem = p.Next;
                p.Next = previousItem;
                previousItem = p;
                p = nextItem;
            }

            head = previousItem;
        }

        public SinglyLinkedList<T> GetCopy()
        {
            SinglyLinkedList<T> copiedList = new SinglyLinkedList<T>();
            ListItem<T> lastItem = null;

            copiedList.Count = Count;

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                ListItem<T> itemForAddInCopyList = new ListItem<T>(p.Data);

                if (copiedList.head == null)
                {
                    copiedList.head = itemForAddInCopyList;
                }
                else
                {
                    lastItem.Next = itemForAddInCopyList;
                }

                lastItem = itemForAddInCopyList;
            }

            return copiedList;
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("[");

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                stringBuilder.Append(p.Data).Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append("]").ToString();
        }
    }
}
