using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DeadManTyping
{
    class MonsterData
    {
        //Variables
        List<string> monsters;
        List<string> phrases;
        Random rng;

        public MonsterData(String phraseFile)
        {
            rng = new Random();
            LoadPhrases(phraseFile);
            LoadMonsters();
        }

        //Methods
        /// <summary>
        /// Loads in a file of phrases to throw at the player.
        /// </summary>
        /// <param name="filename">The name of the file, located relative to the folder with this project's solution.</param>
        public void LoadPhrases(string filename)
        {
            phrases = new List<string>();
            try
            {
                StreamReader reader = new StreamReader("..\\..\\..\\" + filename);
                String line = reader.ReadLine();
                while(line != null)
                {
                    phrases.Add(line);
                    line = reader.ReadLine();
                }
                reader.Close();
            } catch(Exception e)
            {
                Console.WriteLine("Error! " + e.Message);
                return;
            }
        }

        /// <summary>
        /// Looks through the folder with the project solution and loads up single-string versions of each Monster.
        /// </summary>
        public void LoadMonsters()
        {
            monsters = new List<string>();
            StreamReader reader;
            string[] files = Directory.GetFiles("..\\..\\..");
            foreach(String filename in files)
            {
                if (filename.Length > 21 && filename.Substring(9,11).Equals("asciiZombie")) {
                    reader = new StreamReader(filename);
                    monsters.Add(reader.ReadToEnd());
                    reader.Close();
                }
            }
        }

        public string RandomPhrase()
        {
            return phrases.ElementAt(rng.Next(phrases.Count));
        }

        public string RandomMonster()
        {
            if (monsters.Count > 0) return monsters.ElementAt(rng.Next(monsters.Count));
            else return null;
        }
    }
}
