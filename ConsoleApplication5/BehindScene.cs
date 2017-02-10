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
            Console.WriteLine("1. Start Gane (TBD)");
            Console.WriteLine("2. Add Word");
            Console.WriteLine("3. Highscores (TBD)");
            Console.WriteLine("4. Quit");
            bool loop = true;
            while (loop == true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        NewWordC.AddNewWord();
                        loop = false;
                        break;
                    case ConsoleKey.D3:

                        break;
                    case ConsoleKey.D4:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }
        /*public void AddNewWord()
        {
            bool loop = true;
            while (loop == true)
            {
                Console.Clear();
                Console.Write("Enter a word to add it: ");
            string word = Console.ReadLine();

                if (String.IsNullOrEmpty(word) || word.Any(char.IsDigit))
                {
                    Console.Write("Enter a valid word. Press any key to enter a new word...");
                    Console.ReadKey(true);
                }
                else
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(path, true))
                    {
                        file.WriteLine("\n" + word);
                    }
                    loop = false;
                    GetMenu();
                }
            }

        }*/
    }
}
