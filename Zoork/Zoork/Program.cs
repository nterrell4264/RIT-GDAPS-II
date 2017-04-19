using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoork
{
    class Program
    {
        static AdjacencyList zoo;
        static void Main(string[] args)
        {
            zoo = new AdjacencyList();
            SetUpRooms();
            string location = "Hub";
            string input;
            Console.WriteLine("Welcome to the Conservatorium of Elusive Monsters!");
            while (!(location.Equals("Exit")))
            {
                Console.Write("You have entered the " + location + " area. ");
                switch (location)
                {
                    case ("Hub"):
                        {
                            Console.WriteLine("This is the entrance.");
                            break;
                        }
                    case ("Invisible"):
                        {
                            Console.WriteLine("Invisible monsters are housed here. We have infrared binocular stations to view them.");
                            break;
                        }
                    case ("Dragons' Sky"):
                        {
                            Console.WriteLine("Dragons live here. They show themselves whenever they see fit.");
                            break;
                        }
                    case ("Undead"):
                        {
                            Console.WriteLine("A special necrotic field prevents the monsters here from re-dying.");
                            break;
                        }
                    case ("Virtual"):
                        {
                            Console.WriteLine("Cyberspace monsters like Mettaurs and Porygon live here. We sweep for unwanted viruses every hour.");
                            break;
                        }
                    case ("???"):
                        {
                            Console.WriteLine("This area is well known for its wild Grues. Guess what happens next.");
                            return;
                        }
                    case ("Exit"):
                        {
                            Console.WriteLine("Bye!");
                            return;
                        }

                }
                Console.Write("Nearby rooms: ");
                foreach (string room in zoo.GetAdjacentList(location)) Console.Write(room + ", ");
                Console.WriteLine();
                Console.Write("Where would you like to go? ");
                input = Console.ReadLine();
                while (!zoo.rooms.ContainsKey(input) || !zoo.IsConnected(location, input))
                {
                    Console.WriteLine("That is not a nearby room.");
                    input = Console.ReadLine();
                }
                location = input;
            }
        }

        static void SetUpRooms()
        {
            zoo.rooms.Add("Hub", new List<string> { "Invisible", "Dragons' Sky", "Virtual", "Undead", "Exit" });
            zoo.rooms.Add("Invisible", new List<string> { "Hub", "Dragons' Sky"});
            zoo.rooms.Add("Dragons' Sky", new List<string> { "Hub", "Invisible"});
            zoo.rooms.Add("Virtual", new List<string> { "Hub", "Undead"});
            zoo.rooms.Add("Undead", new List<string> { "Hub", "Virtual", "???"});
            zoo.rooms.Add("???", new List<string>());
        }
    }
}
