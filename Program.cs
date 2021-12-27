using System;

namespace TicTacToe
{
    class Program
    {

        //Create the playfield
        static char[,] playField =
        {
            {'1', '2', '3'}, // Row 0
            {'4', '5', '6'}, // Row 1
            {'7', '8', '9'}  // Row 2
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; //Player 1 starts
            int input = 0;
            bool inputCorrect = true;
          

            //Run code as long as the program runs
            do
            {

                if (player == 2)
                {
                    player = 1;
                    EnterXor0(player, input);
                }
                    
                else if (player == 1)
                {
                    player = 2;
                    EnterXor0(player, input);
                }

                SetField();

                #region
                // Check winning condition
                char[] playerChars = { 'X', '0' };
                foreach(char playerChar in playerChars)
                {
                    if(((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                        || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                        || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                        || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                        )
                    {
                        if(playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 has won!");
                        }
                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;  
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("\nWe have a draw!");
                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }
                #endregion

                do
                {

                    Console.Write("\nPlayer {0}: Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playField[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playField[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playField[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playField[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playField[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playField[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playField[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playField[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\nIncorrect input! Please use another field!");
                        inputCorrect = false;
                    }


                } while (!inputCorrect);
                
            } while (true);

        }

        public static void ResetField()
        {
            char[,] playFieldInitial =
            {
            {'1', '2', '3'}, // Row 0
            {'4', '5', '6'}, // Row 1
            {'7', '8', '9'}  // Row 2
            };

            playField = playFieldInitial;
            SetField();
            turns = 0;
        }
        
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[0,0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void EnterXor0(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
                playerSign = 'X';
            else if (player == 2)
                playerSign = '0';
            
            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }
        }
    }
}
