using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class BehindScene
    {
        public static string wordpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"resources\words.txt");
        public static void GetMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Add Word");
            Console.WriteLine("3. Highscores");
            Console.WriteLine("4. Quit");
            bool loop = true;
            while (loop == true)
            {
                //Wait for userinput to continue
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        //Play the game
                        Game.StartGame();
                        break;
                    case ConsoleKey.D2:
                        //Add new word to list
                        Console.Clear();
                        NewWordC.AddNewWord();
                        loop = false;
                        break;
                    case ConsoleKey.D3:
                        //Show highscores
                        GetHighScores();
                        break;
                    case ConsoleKey.D4:
                        //Quit
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        private static void GetHighScores()
        {
            //Get highscores from the file scores.txt
            int xx = 1;
            string filename = @"resources\scores.txt";
            Console.Clear();
            List<string> scoreList = File.ReadAllLines(filename).ToList();
            foreach (string oneScore in scoreList)
            {
                Console.WriteLine(xx.ToString() + ". " + oneScore);
                xx++;
            }
            Console.WriteLine("\nPress any key to go back to menu...");
            Console.ReadKey(true);
            GetMenu();
        }
    }
}
