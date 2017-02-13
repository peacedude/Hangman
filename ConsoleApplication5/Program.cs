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
            BehindScene.GetMenu();

        }
        private static void New_Score(int score, string name)
        {
            string filename = @"resources\scores.txt";
            List<string> scoreList;
            if (File.Exists(filename))
                scoreList = File.ReadAllLines(filename).ToList();
            else
                scoreList = new List<string>();
            scoreList.Add(name + " " + score.ToString());
            var sortedScoreList = scoreList.OrderByDescending(ss => int.Parse(ss.Substring(ss.LastIndexOf(" ") + 1)));
            File.WriteAllLines(filename, sortedScoreList.ToArray());
        }
    }
}
