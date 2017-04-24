using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkObject
{
    public class NPC
    {
        public string Name { get; private set; }
        public String[] textboxes { get; private set; }

        public NPC(string name)
        {
            Name = name;
            textboxes = new string[3];
        }

        public void SetText(int boxNum, string message)
        {
            if (boxNum >= 0 && boxNum < textboxes.Length)
                textboxes[boxNum] = message;
            else throw new IndexOutOfRangeException();
        }
    }
}
