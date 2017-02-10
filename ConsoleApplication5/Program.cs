using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 w = new Class1();
            string[] words = File.ReadAllLines(@"C:\Users\Lexicon\Documents\Visual Studio 2015\Projects\ConsoleApplication5\Words\words.txt");
            w.GetMenu();
            Console.ReadKey(true);

        }
    }
}
