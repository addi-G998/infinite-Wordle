using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleTest
{
    class Matrix
    {
        private char[,] words;
        private int rows;
        private int columns;
        private List<char> correctLetters = new List<char>();
        private List<char> wrongLetters = new List<char>();
        public Matrix(int columns, int rows)
        {
            this.rows = rows;
            this.columns = columns;
            words = new char[rows, columns];
            inputArr();
        }



        public void inputArr()
        {
           
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    words[i, j] = 'o';
                }
            }
        }

        public bool outputArr(String word, String input, int r) {
            input = input.ToUpper();
            if (word == input)
            {
                
                return true;
            }
            

            char[] letters = input.ToCharArray();
            char[] solution = word.ToCharArray();
            for (int j = 0; j < columns; j++)
            {
                words[r, j] = letters[j];
            }

            for (int x = 0; x < letters.Length; x++)
            {
                if (solution.Contains(letters[x]))
                {
                    
                    correctLetters.Add(letters[x]);
                }
                else
                {
                    
                    wrongLetters.Add(letters[x]);
                }
            }
            
            return false;
        }

        public char checkLetter(char [] letters, char [] solution, int k)
        {

            if (letters[k] == solution[k])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Correct Position for letter/s " + letters[k] + " at Position: " + (k + 1));
                //words[r,k] = letters[k];
                

            }
            return letters[k];
            
        }

        public int letter_count(String solution, char letter) 
        {
            int count = 0;
            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] == letter)
                {
                    count++;
                }
            }
            return count;
        }
        public void PrintMatrix(String solution, String input)
        {
            char[] solutionChar = solution.ToCharArray();
            char[] inputChar = input.ToCharArray();
            Console.WriteLine('\n');

            Dictionary<char, int> occurrencesInSolution = new Dictionary<char, int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {


                    if (words[i, j] == solution[j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                       
                    }
                    else if (solution.Contains(words[i, j]))
                    {
                        
                        int solutionCount = letter_count(solution, words[i, j]);
                        int inputCount = letter_count(input, words[i, j]);

                        if (inputCount <= solutionCount)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }




                    }
                    else if (!solution.Contains(words[i, j]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (words[i, j] == 'o')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(words[i, j] + " ");
                    Console.ResetColor();

                }

                Console.WriteLine('\n');
            }
        }
    }
}
