using System;

namespace CSharpOop.ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;
        private int count;

        public int GetSize()
        {
            return count;
        }

        public T GetFirstElementData()
        {
            return head.Data;
        }

        public void AddFirst(T data)
        {
            ListItem<T> listItem = new ListItem<T>(data, head);
            head = listItem;

            count++;
        }

        public T GetRemovedFirstElement()
        {
            T removedElement = head.Data;
            head = head.Next;
            count--;

            return removedElement;
        }

        public T GetElementData(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("index не может быть отрицательным", nameof(index));
            }

            if (index > count - 1)
            {
                throw new ArgumentException("index выходит за границы списка", nameof(index));
            }

            if (index == 0)
            {
                return head.Data;
            }

            ListItem<T> currentElement = head;

            for (int i = 0; i < index; i++)
            {
                currentElement = currentElement.Next;
            }

            return currentElement.Data;
        }

        public T GetChangedElementData(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentException("index не может быть отрицательным", nameof(index));
            }

            if (index > count - 1)
            {
                throw new ArgumentException("index выходит за границы списка", nameof(index));
            }

            ListItem<T> currentElement = head;

            for (int i = 0; i < index; i++)
            {
                currentElement = currentElement.Next;
            }

            T changedElementData = currentElement.Data;
            currentElement.Data = data;

            return changedElementData;
        }

        public T GetRemovedElementData(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("index не может быть отрицательным", nameof(index));
            }

            if (index > count - 1)
            {
                throw new ArgumentException("index выходит за границы списка", nameof(index));
            }

            if (index == 0)
            {
                return GetRemovedFirstElement();
            }

            ListItem<T> currentElement = head;

            for (int i = 0; i < index - 1; i++)
            {
                currentElement = currentElement.Next;
            }

            T removedElementData = currentElement.Next.Data;
            currentElement.Next = currentElement.Next.Next;
            count--;

            return removedElementData;
        }

        public void AddByIndex(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentException("index не может быть отрицательным", nameof(index));
            }

            if (index > count - 1)
            {
                throw new ArgumentException("index выходит за границы списка", nameof(index));
            }

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                ListItem<T> currentElement = head;

                for (int i = 0; i < index - 1; i++)
                {
                    currentElement = currentElement.Next;
                }

                ListItem<T> elementForAdd = new ListItem<T>(data, currentElement.Next);
                currentElement.Next = elementForAdd;
                count++;
            }
        }

        public bool IsRemoved(T data)
        {
            for (ListItem<T> p = head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (p.Data.Equals(data))
                {
                    if (prev == null)
                    {
                        GetRemovedFirstElement();
                    }
                    else
                    {
                        prev.Next = p.Next;
                        count--;
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

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                copiedList.AddFirst(p.Data);
            }

            copiedList.Revert();

            return copiedList;
        }
    }
}
