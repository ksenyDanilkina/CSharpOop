using System;
using System.Text;

namespace CSharpOop.ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Count { get; private set; }

        public T GetFirstElementData()
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

        public T RemoveFirstElement()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Список пуст");
            }

            T removedElement = head.Data;
            head = head.Next;
            Count--;

            return removedElement;
        }

        public T GetElementData(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть > 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }

            ListItem<T> currentElement = GetElementByIndex(index);

            return currentElement.Data;
        }

        private ListItem<T> GetElementByIndex(int index)
        {
            ListItem<T> item = head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }
        public T SetElementData(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть > 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }


            ListItem<T> currentElement = GetElementByIndex(index);

            T changedElementData = currentElement.Data;
            currentElement.Data = data;

            return changedElementData;
        }

        public T RemoveElementByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть > 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }

            if (index == 0)
            {
                return RemoveFirstElement();
            }

            ListItem<T> currentElement = GetElementByIndex(index - 1);

            T removedElementData = currentElement.Next.Data;
            currentElement.Next = currentElement.Next.Next;
            Count--;

            return removedElementData;
        }

        public void AddByIndex(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index  должен быть > 0");
            }

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index = " + index + ". Index должен быть < " + Count);
            }

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                ListItem<T> currentElement = GetElementByIndex(index - 1);

                ListItem<T> elementForAdd = new ListItem<T>(data, currentElement.Next);
                currentElement.Next = elementForAdd;
                Count++;
            }
        }

        public bool RemoveElementByData(T data)
        {
            for (ListItem<T> p = head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (Equals(p.Data, data))
                {
                    if (prev == null)
                    {
                        RemoveFirstElement();
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
            ListItem<T> previousElement = null;

            for (ListItem<T> p = head; p != null;)
            {
                ListItem<T> nextElement = p.Next;
                p.Next = previousElement;
                previousElement = p;
                p = nextElement;
            }

            head = previousElement;
        }

        public SinglyLinkedList<T> GetCopy()
        {
            SinglyLinkedList<T> copiedList = new SinglyLinkedList<T>();
            ListItem<T> lastItem = null;

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

                copiedList.Count++;
            }

            return copiedList;
        }

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                if (i < Count - 1)
                {
                    resultString.Append(GetElementData(i)).Append(", ");
                }
                else
                {
                    resultString.Append(GetElementData(i));
                }
            }

            return resultString.ToString();
        }

    }
}
