using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALinkToTheList
{
    class Node<T>
    {
        //Variables
        private T data;
        private Node<T> next;
        
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

        //Constructor
        public Node(T storage = default(T))
        {
            data = storage;
        }

        //Methods
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
