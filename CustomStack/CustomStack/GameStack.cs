using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    class GameStack : IStack
    {
        #region Properties
        private string[] stack;
        public int Count
        {
            get
            {
                return stack.Length;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }
        #endregion

        #region constructor
        public GameStack()
        {
            stack = new string[1];
        }
        #endregion

        #region methods
        public string Peek()
        {
            return stack[Count - 1];
        }

        public string Pop()
        {
            if (!IsEmpty)
            {
                string popped = stack[Count - 1];
                string[] temp = new string[Count - 1];
                Array.Copy(stack, temp, Count - 1);
                stack = temp;
                return popped;
            }
            else return null;
        }

        public void Push(string str)
        {
            string[] temp = new string[Count+1];
            Array.Copy(stack, temp, Count);
            stack = temp;
            stack[Count - 1] = str;
        }
        #endregion
    }
}
