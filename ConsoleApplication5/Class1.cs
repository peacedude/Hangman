using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Class1
    {
        public void GetMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Start Gane");
            Console.WriteLine("2. Add Word");
            Console.WriteLine("3. Quit");
            bool loop = true;
            while (loop == true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        AddNewWord();
                        loop = false;
                        break;
                    case ConsoleKey.D3:
                        loop = false;
                        break;
                    case ConsoleKey.D4:
                        break;
                }
            }
        }
        public void AddNewWord()
        {
            Console.Write("Enter a word to add it: ");
            string word = Console.ReadLine();
            if (String.IsNullOrEmpty(word))
            {
                Console.WriteLine("Enter a valid word.");
            }
            else
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Lexicon\Documents\Visual Studio 2015\Projects\ConsoleApplication5\Words\words.txt", true))
                {
                    file.WriteLine("\n" + word);
                }
                GetMenu();
            }
        }
    }
}
