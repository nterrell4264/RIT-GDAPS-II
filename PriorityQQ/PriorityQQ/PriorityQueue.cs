using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQQ
{
    class PriorityQueue
    {
        int[] heap;
        
        public int Count { get; private set; }
        private int MaxIndex
        {
            get { return Count - 1; }
        }

        public PriorityQueue()
        {
            heap = new int[16];
            Count = 0;
        }

        public void Enqueue(int data)
        {
            heap[Count] = data;
            Count++;
            if(Count > 1) UpSort((MaxIndex - 1) / 2, MaxIndex);
        }

        public int Dequeue()
        {
            int value = heap[0];
            heap[0] = heap[MaxIndex];
            Count--;
            DownSort(0, 1);
            DownSort(0, 2);
            return value;
        }

        public int Peek()
        {
            return heap[0];
        }

        public bool isEmpty()
        {
            return Count == 0;
        }

        //Private methods for sorting
        private void UpSort(int parent, int child)
        {
            if(heap[parent] > heap[child])
            {
                int temp = heap[child];
                heap[child] = heap[parent];
                heap[parent] = temp;
                UpSort((parent - 1) / 2, parent);
            }
        }
        private void DownSort(int parent, int child)
        {
            if (child <= MaxIndex && heap[child] < heap[parent])
            {
                int temp = heap[child];
                heap[child] = heap[parent];
                heap[parent] = temp;
                DownSort(child, child * 2 + 1);
                DownSort(child, child * 2 + 2);
            }
        }
    }
}
