using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TwitchPlaysMario
{
    class Program
    {
        static private String input;
        static private int intput;
        static private bool finished = false;

        static private TcpClient connection;
        static private StreamWriter writer;

        static private int xOffset;

        static void Main(string[] args)
        {
            //Connects to server
            connection = new TcpClient("129.21.29.140", 14623);
            writer = new StreamWriter(connection.GetStream());

            //Game time
            while (!finished)
            {
                Console.WriteLine("Ready.");
                input = Console.ReadLine();
                if (input.Equals("done")) finished = true;
                else writer.WriteLine(input);
                writer.Flush();
            }
        }
    }
}
