using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALinkBetweenList
{
    class DoubleList<T>
    {
        //Variables
        private Node<T> head;
        private Node<T> tail;
        private int count;
        private Node<T> slot = null; //Used for counting

        //Properties
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new ArgumentOutOfRangeException();
                slot = head;
                for (int i = 0; i < index; i++) slot = slot.Next;
                return slot.Data;
            }
        }
        public int Count
        {
            get { return count; }
        }
        //Constructors
        public DoubleList(){}
        public DoubleList(T start)
        {
            head = new Node<T>(start);
            tail = head;
            count++;
        }

        //Methods
        public void Add(T item)
        {
            if (head == null) //List is empty
            {
                head = new Node<T>(item);
                tail = head;
            }
            else
            {
                tail.Next = new Node<T>(item);
                tail.Next.Prev = tail;
                tail = tail.Next;
            }
            count++;
        }

        public void Insert(T item, int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException();
            if (head == null) //List is empty
            {
                head = new Node<T>(item);
                tail = head;
            }
            else if (index == 0) //Insert is at front
            {
                head.Prev = new Node<T>(item);
                head.Prev.Next = head;
                head = head.Prev;
            }
            else if (index == count) //Insert is at end
            {
                tail.Next = new Node<T>(item);
                tail.Next.Prev = tail;
                tail = tail.Next;
            }
            else
            {
                slot = head;
                for (int i = 0; i < index; i++) slot = slot.Next;
                slot.Prev.Next = new Node<T>(item); //Inserts the data from the back
                slot.Prev.Next.Prev = slot.Prev;
                slot.Prev = slot.Prev.Next; //Updates the front to match
                slot.Prev.Next = slot;
            }
            count++;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException();
            T result;
            if (count == 1) //Last item
            {
                result = head.Data;
                head = null;
            } else if(index == 0) //Remove is at beginning
            {
                result = head.Data;
                head.Next.Prev = null;
                head = head.Next;
            } else if(index == count - 1) //Remove is at end
            {
                result = tail.Data;
                tail.Prev.Next = null;
                tail = tail.Prev;
            } else
            {
                slot = head;
                for (int i = 0; i < index; i++) slot = slot.Next;
                result = slot.Data;
                slot.Prev.Next = slot.Next;
                slot.Next.Prev = slot.Prev;
            }
            count--;
            return result;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Print()
        {
            slot = head;
            while(slot != null)
            {
                Console.Write(slot.ToString());
                if (!tail.Equals(slot)) Console.Write(", ");
                slot = slot.Next;
            }
            Console.WriteLine();
        }
    }
}
