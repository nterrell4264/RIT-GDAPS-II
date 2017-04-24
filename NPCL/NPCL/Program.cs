using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkObject;

namespace NPCL
{
    class Program
    {
        static void Main(string[] args)
        {
            NPC merchant = new NPC("merchant");
            merchant.SetText(0, "Welcome to my shop...");
            merchant.SetText(1, "I know you! I warned you about stealing from me!");
            merchant.SetText(2, "Prepare to pay the ultimate price!");
            foreach (string textbox in merchant.textboxes) Console.WriteLine("\"" + textbox + "\"");
        }
    }
}
