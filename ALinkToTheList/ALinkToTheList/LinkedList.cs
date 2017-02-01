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

        public override string ToString()
        {
            String result = head.ToString() + ", ";
            for (int i = 1; i < count - 1; i++) result += this[i].ToString() + ", ";
            result += this[this.count - 1].ToString();
            return result;
        }
    }
}
