using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Game
    {

        static public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Hangman");
            Random rnd = new Random((int)DateTime.Now.Ticks);
            string filename = @"resources\words.txt";
            //Convert words.txt into a list then into an array
            List<string> wordList = File.ReadAllLines(filename).ToList();
            string[] wordBank = wordList.ToArray();

            string wordToGuess = wordBank[rnd.Next(0, wordBank.Length)];
            string wordToGuessUpperCase = wordToGuess.ToUpper();

            //Show user how many letters the word contains with '_'
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                displayToPlayer.Append('_');
            }


            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.WriteLine("Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];
                if (char.IsDigit(guess) || char.IsWhiteSpace(guess) || string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Enter a valid guess.");
                }

                else
                {
                    //Gives user feedback when they enter a letter that has already been entered.
                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct.\n", guess);
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong.\n", guess);
                        continue;
                    }
                    //Reveals a letter to the user if the guess is correct.

                    if (wordToGuessUpperCase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUpperCase[i] == guess)
                            {
                                Console.Clear();
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                            }
                            if (lettersRevealed == wordToGuess.Length)
                                won = true;
                        }
                    }
                    else
                    //If the guess is not correct the user recieves feedback.
                    {
                        incorrectGuesses.Add(guess);
                        Console.Clear();
                        Console.WriteLine("There is no '{0}' in the word!\n", guess);
                        lives--;
                    }

                    Console.WriteLine(displayToPlayer.ToString());

                }
                
            }
            //If the user wins they get to add a name to scores.txt and if they lose it takes them to the menu. 
            if (won)
            {
                Console.Write("\nYou won!\nEnter your name to add it to the highscore list: ");
                string hsName = Console.ReadLine();
                New_Score(lives, hsName);
            }
            else
            {
                Console.WriteLine("\nYou lost! The word was '{0}'", wordToGuess);
            }
            Console.WriteLine("Press any key to go back to menu..");
            Console.ReadKey(true);
            BehindScene.GetMenu();

        }
        private static void New_Score(int score, string name)
        {
            //Adds the inputed name to scores.txt with the amount of lives remaining and sorts it from most lives to the least remaining.
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
