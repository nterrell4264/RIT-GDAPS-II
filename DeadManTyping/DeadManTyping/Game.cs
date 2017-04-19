using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DeadManTyping
{
    class Game
    {
        //Variables
        MonsterData game;

        private int health = 3;
        private int timer;
        private int score = 0;
        private int highScore;

        private string phrase;
        private int index = 0;

        //Constructor
        public Game()
        {
            //Reads in high score
            StreamReader reader = new StreamReader("..\\..\\..\\hiScore.dat");
            highScore = int.Parse(reader.ReadLine());
            reader.Close();
            //Starts game
            game = new MonsterData("phrases.txt");
            PlayGame();
        }

        public void PlayGame()
        {
            NewRound();
            while(health > 0) //Main game loop
            {
                Console.ForegroundColor = ConsoleColor.Green; //Assumes the player is typing correctly by default.
                while (Console.KeyAvailable) //Tracks key presses
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    string letter = key.KeyChar.ToString();

                    if (letter.Equals(phrase.Substring(index, 1))){ //Correct input
                        Console.Write(letter);
                        index++;
                        if(index == phrase.Length) //Correctly entered phrase
                        {
                            score += 100;
                            NewRound();
                        }
                    }
                    else //Incorrect input
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(letter);
                        //Clears the line
                        Console.CursorLeft = 0;
                        for (int i = 0; i <= index; i++) Console.Write(" ");
                        Console.CursorLeft = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        index = 0;
                    }
                }
                System.Threading.Thread.Sleep(50);
                timer += 50;
                if (timer >= 10000 - score) //Time's up, monster attacks
                {
                    timer = 0;
                    health--;
                    //Writes updated health
                    Console.CursorTop++;
                    Console.CursorLeft = 8;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(health);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.CursorTop--;
                    Console.CursorLeft = index;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game Over!");
            Console.WriteLine("Your Score: " + score);
            Console.WriteLine("High Score: " + highScore);
            if (score > highScore)
            {
                Console.WriteLine("New high score!");
                StreamWriter writer = new StreamWriter("..\\..\\..\\hiScore.dat");
                writer.Write(score);
                writer.Close();
            }
        }

        public void NewRound() //Sets up a new monster and phrase.
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("A monster appears!");
            Console.WriteLine(game.RandomMonster());
            phrase = game.RandomPhrase();
            Console.WriteLine(phrase);
            Console.CursorTop++;
            Console.Write("Health: " + health + "   " + "Score: " + score);
            Console.CursorTop--;
            Console.CursorLeft = 0;
            index = 0;
            timer = 0;
        }
    }
}
