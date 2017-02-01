using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALinkToTheList
{
    class LinkedList<T>
    {
        //Variables
        private Node<T> head;
        private int count;

        //Properties
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.count) throw new ArgumentOutOfRangeException();
                Node<T> slot = head;
                for(int i = 0; i < index; i++)
                {
                    slot = slot.Next;
                }
                return slot.Data;
            }
        }
        public int Count
        {
            get { return count; }
        }

        //Constructor
        public LinkedList() { }
        public LinkedList(T starter)
        {
            head = new Node<T>(starter);
            count++;
        }

        //Methods
        public void Add(T item)
        {
            if (head != null)
            {
                Node<T> slot = head;
                while (slot.Next != null) slot = slot.Next; //Goes to last index
                slot.Next = new Node<T>(item);
            } else
            {
                head = new Node<T>(item);
            }
            count++;
        }

        public T Remove(int index)
        {
            T toss;
            if (index < 0 || index > this.count) throw new ArgumentOutOfRangeException();
            Node<T> slot = head;
            for (int i = 0; i < index - 1; i++) //Moves to index before desired spot
            {
                slot = slot.Next;
            }
            if (count == 1)
            {
                toss = head.Data;
            }
            else toss = slot.Next.Data;
            if (index == 0) head = slot.Next; //Moves head if removed element is first
            if (index == count - 1) slot.Next = null; //Doesn't link to slot after removed if it doesn't exist
            else slot.Next = slot.Next.Next;
            count--;
            return toss;
        }

        public override string ToString()
        {
            if (count == 0) return "";
            String result = "";
            for (int i = 0; i < count - 1; i++) result += this[i].ToString() + ", ";
            result += this[this.count - 1].ToString();
            return result;
        }
    }
}
