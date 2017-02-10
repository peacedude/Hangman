﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class NewWordC
    {
        public static void AddNewWord()
        {
            bool loop = true;
            while (loop == true)
            {
                Console.Clear();
                Console.Write("Enter a word to add it: ");
                string word = Console.ReadLine();

                if (String.IsNullOrEmpty(word) || word.Any(char.IsDigit) || String.IsNullOrWhiteSpace(word))
                {
                    Console.Write("Enter a valid word. Press any key to enter a new word...");
                    Console.ReadKey(true);
                }
                else
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(BehindScene.wordpath, true))
                    {
                        file.WriteLine("\n" + word);
                    }
                    loop = false;
                    BehindScene.GetMenu();
                }
            }

        }
    }
}
