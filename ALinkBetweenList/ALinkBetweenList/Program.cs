using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALinkBetweenList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to List Listings! Let's set up a list for you.");
            DoubleList<String> ListyList = new DoubleList<String>();
            bool finished = false;
            String input;
            int index;
            Console.WriteLine("Alright, now tell us what you want on your list. You can also use the following commands:");
            Console.WriteLine("\"get\", \"count\", \"insert\", \"remove\", \"clear\", \"print\", and \"quit\".");
            do
            {
                input = Console.ReadLine();
                if (input.Equals("quit")) finished = true;
                else if (input.Equals("get"))
                {
                    Console.WriteLine("Get where?");
                    if (int.TryParse(Console.ReadLine(), out index))
                    {
                        try
                        {
                            Console.WriteLine("That value is \"" + ListyList[index] + "\"");
                        }
                        catch
                        {
                            Console.WriteLine("That index isn't in the list!");
                        }
                    }
                }
                else if (input.Equals("count"))
                {
                    Console.WriteLine("There are " + ListyList.Count + " items listed.");
                }
                else if (input.Equals("insert"))
                {
                    Console.WriteLine("Insert what?");
                    input = Console.ReadLine();
                    Console.WriteLine("Insert where?");
                    if (int.TryParse(Console.ReadLine(), out index))
                    {
                        try
                        {
                            ListyList.Insert(input, index);
                            Console.WriteLine("It is in-listed! Get it?");
                        }
                        catch
                        {
                            Console.WriteLine("That index isn't in the list!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That's not an index!");
                    }
                }
                else if (input.Equals("remove"))
                {
                    Console.WriteLine("Remove where?");
                    if(int.TryParse(Console.ReadLine(), out index)) {
                        try
                        {
                            ListyList.Remove(index);
                            Console.WriteLine("It is delisted!");
                        } catch
                        {
                            Console.WriteLine("That index isn't in the list!");
                        }
                    } else {
                        Console.WriteLine("That's not an index!");
                    }
                }
                else if (input.Equals("clear"))
                {
                    Console.WriteLine("Starting over, huh? We can do that.");
                    ListyList.Clear();
                }
                else if (input.Equals("print"))
                {
                    Console.Write("Okay, here's your list: ");
                    ListyList.Print();
                }
                else
                {
                    Console.WriteLine("Let's list that.");
                    ListyList.Add(input);
                }
            } while (!finished);
        }
    }
}
