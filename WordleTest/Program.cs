using System;
using System.Threading.Tasks;

namespace WordleTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int columns = 5;
            int rows = 6;
            Matrix matrix = new Matrix(columns,rows);
            MyDictionary dictionary = new MyDictionary();
            await dictionary.InitializeAsync();
            int desiredLength = 5; // Beispiel: Wortlänge 5
            string randomWord = await dictionary.GetRandomWordAsync(desiredLength);
            randomWord = randomWord.ToUpper();
            Console.WriteLine("Welcome to Wordle!");
            Console.WriteLine("Guess the word by entering a 5 letter word.");
            Console.WriteLine("If you want to reveal the word, type 'reveal'");

            int attempts = 0;

            while (attempts < rows)
            {
                string usrInput = Console.ReadLine();
                if (usrInput == "reveal")
                {
                    Console.WriteLine(randomWord);
                    break;
                }

                if (!dictionary.IsValidWord(usrInput))
                {
                    Console.WriteLine("The entered word doesn't exist in the dictionary. Please try again");
                    continue;
                }

                if (matrix.outputArr(randomWord, usrInput, attempts))
                {
                    break;
                }

                matrix.PrintMatrix(randomWord, usrInput);
                attempts++;
            }
            Console.WriteLine("Game Over");
            Console.WriteLine(randomWord);
        }
    }
}
