using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALinkBetweenList
{
    class Node<T>
    {
        //Variables
        T data;
        Node<T> next;
        Node<T> prev;

        //Properties
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        //Constructor
        public Node(T item){
            data = item;
        }

        //Methods
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
