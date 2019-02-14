using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static char[,] playField = new char[,]
        {
                {'1', '2', '3' },
                {'4', '5', '6' },
                {'7', '8', '9' }
        };
        static char playerChar;
        static bool inputCorrect = true;
        static int input;
        static ArrayList choices = new ArrayList();


        static void Main(string[] args)
        {
            int player = 2;

            CreateField();

            do
            {
                if (inputCorrect == true)
                {
                    // get player
                    if (player == 2)
                    {
                        player = 1;
                        playerChar = 'X';
                    }
                    else
                    {
                        player = 2;
                        playerChar = 'O';
                    }
                }

                Console.WriteLine("Player {0}'s Turn", player);
                Console.WriteLine("Enter a number from 0 to 9");
                
                // get input
                try
                {
                    // make sure input is an integer
                    input = int.Parse(Console.ReadLine());
                    inputCorrect = true;
                }
                catch
                {
                    // repeat the loop if user input is not an integer
                    Console.WriteLine("Please enter a number...");
                    inputCorrect = false;
                    continue;
                }
                
                // check if number input is greater than 9 or less than 1
                if (input > 9 || input < 1)
                {
                    Console.WriteLine("Number too big or too small...");
                    inputCorrect = false;
                    continue;
                }

                if (choices.Contains(input))
                {
                    Console.WriteLine("Place already contains a Value");
                    inputCorrect = false;
                    continue;
                }
                else choices.Add(input);

                SetChar(input);
                CreateField();
                
                if (Verify(playerChar))
                {
                    break;
                }
                
            }
            while (true);

            Console.WriteLine("\n{0} Wins!!!", player);
        }

        // create the playing field
        public static void CreateField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0 , 0], playField[0 , 1], playField[0 , 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1 , 0], playField[1 , 1], playField[1 , 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2 , 0], playField[2 , 1], playField[2 , 2]);
            Console.WriteLine("     |     |     ");
        }

        public static void SetChar(int input)
        {
            switch (input)
            {
                case 1: playField[0, 0] = playerChar; break;
                case 2: playField[0, 1] = playerChar; break;
                case 3: playField[0, 2] = playerChar; break;
                case 4: playField[1, 0] = playerChar; break;
                case 5: playField[1, 1] = playerChar; break;
                case 6: playField[1, 2] = playerChar; break;
                case 7: playField[2, 0] = playerChar; break;
                case 8: playField[2, 1] = playerChar; break;
                case 9: playField[2, 2] = playerChar; break;
            }
        }

        public static bool Verify(char playerChar)
        {
            // Horizontal check
            if (playField[0, 0] == playerChar && (playField[0, 1] == playField[0, 0]) && (playField[0,2] == playField[0,0]))
            {
                return true;
            }
            if (playField[1, 0] == playerChar && (playField[1, 1] == playField[1, 0]) && (playField[1, 2] == playField[1, 0]))
            {
                return true;
            }
            if (playField[2, 0] == playerChar && (playField[2, 1] == playField[2, 0]) && (playField[2, 2] == playField[2, 0]))
            {
                return true;
            }

            // Vertical check
            if (playField[0, 0] == playerChar && (playField[1, 0] == playField[0, 0]) && (playField[2,0] == playField[0, 0]))
            {
                return true;
            }
            if (playField[0, 1] == playerChar && (playField[1, 1] == playField[0, 1]) && (playField[2, 1] == playField[0, 1]))
            {
                return true;
            }
            if (playField[0, 2] == playerChar && (playField[1, 2] == playField[0, 2]) && (playField[2, 2] == playField[0, 2]))
            {
                return true;
            }

            // Diagonal Check
            
            // Top-left to Bottom-Right
            if (playField[0, 0] == playerChar && (playField[1, 1] == playField[0, 0]) && (playField[2, 2] == playField[0, 0]))
            {
                return true;
            }

            // Top-right to Bottom-Left
            if (playField[0, 2] == playerChar && (playField[1, 1] == playField[0, 2]) && (playField[2, 0] == playField[0, 2]))
            {
                return true;
            }

            else return false;
        }
            
       }
            
    }

