// See https://aka.ms/new-console-template for more information
using System;

namespace TicTacToe
{
    class Program
    {
        static string playAgain = "y";
        static string input = "";
        static string exit = "q";
        static int turnsTaken = 0;
        static int[] board = new int[9];
        static void Main(string[] args)
        {

            //reset the board/array
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }


            int userTurn = -1;
            int computerTurn = -1;
            Random rand = new Random();
            int playerTurn = 3;
            string validInfo;
            bool isInRange = false;
            int playerSymbol = 0;
            int computerSymbol = 0;

            //Working on playAgain part of program 2/8/2023
            do
            {

                while (playerTurn == 3)
                {
                    Console.WriteLine("Would you like to play first or second please enter 1 or 2.");
                    validInfo = Console.ReadLine();
                    isInRange = int.TryParse(validInfo, out playerTurn);
                    if (!isInRange || playerTurn < 1 || playerTurn > 2)
                    {
                        playerTurn = 3;
                        Console.WriteLine("Invalid entry! ");
                    }
                }
                while (playerSymbol == 0)
                {
                    Console.WriteLine("What symbol would you like to use press 8 for 'X' or 9 for 'O'.");
                    validInfo = Console.ReadLine();
                    isInRange = int.TryParse(validInfo, out playerSymbol);
                    if (!isInRange || playerSymbol < 8 || playerSymbol > 9)
                    {
                        playerSymbol = 0;
                        Console.WriteLine("Invalid entry! ");
                    }
                    if (playerSymbol == 8)
                    {
                        computerSymbol = 9;
                    }
                    else
                    {
                        computerSymbol = 8;
                    }

                }


                while (checkForWinner() == 0)
                {
                    if (playerTurn == 1)
                    {
                        while (userTurn == -1 || board[userTurn] != 0 && exit != input)
                        {
                            bool isNumber = false;
                            while (!isNumber)
                            {
                                if (checkForWinner() != 0)
                                {
                                    printBoard();
                                    //Console.WriteLine("Player " + checkForWinner() + " wins!");
                                    Console.WriteLine("Computer wins!1");
                                    anotherGame();
                                    //return;
                                }

                                if (checkForDraw() == 3)
                                {
                                    Console.WriteLine("Game Ends in Draw.");
                                    printBoard();
                                    anotherGame();
                                    if (playAgain == "n")
                                    {
                                        return;
                                    }
                                }
                                if (checkForWinner() == 0)
                                {
                                    isNumber = true;
                                    Console.WriteLine("Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                    input = Console.ReadLine();
                                }
                                if (exit == input.ToLower())
                                {
                                    return;
                                }
                                if (checkForWinner() == 0)
                                {
                                    isNumber = int.TryParse(input, out userTurn);
                                }
                                if (!isNumber || userTurn < 0 || userTurn > 8)
                                {
                                    userTurn = -1;
                                    Console.WriteLine("Invalid entry! ");
                                }
                            }
                        }
                        if (checkForWinner() == 0)
                        {
                            Console.WriteLine("You typed " + userTurn);
                            board[userTurn] = playerSymbol;
                            printBoard();
                            turnsTaken++;
                            playerTurn++;
                        }
                    }

                    if (playerTurn == 2)
                    {
                        //don't allow computer to pick invalid number
                        while (computerTurn == -1 || board[computerTurn] != 0 && exit != input)
                        {
                            if (checkForWinner() != 0)
                            {
                                printBoard();
                                //Console.WriteLine("Player " + checkForWinner() + " wins!");
                                Console.WriteLine("Player wins!");
                                anotherGame();
                                if (playAgain == "n")
                                {
                                    return;
                                }
                            }
                            if (checkForDraw() == 3)
                            {
                                Console.WriteLine("Game Ends in Draw.");
                                printBoard();
                                anotherGame();
                                if (playAgain == "n")
                                {
                                    return;
                                }
                            }
                            if (checkForWinner() == 0)
                            {
                                computerTurn = rand.Next(9);
                                Console.WriteLine("Computer chooses " + computerTurn);
                            }
                        }
                        if (checkForWinner() == 0)
                        {
                            board[computerTurn] = computerSymbol;
                            turnsTaken++;
                        }
                        if (checkForWinner() != 0)
                        {
                            printBoard();
                            Console.WriteLine("Computer wins!");
                            anotherGame();
                            if (playAgain == "n")
                            {
                                return;
                            }
                        }
                        if (checkForWinner() == 0)
                        {
                            printBoard();
                            playerTurn--;
                        }
                    }
                }
                /**Console.WriteLine("Would you like to play again? y/n ");
                input = Console.ReadLine();
                playAgain = input.ToLower();**/
            } while (playAgain == "y");
        }
        private static void endGame()
        {
            if (exit == input.ToLower())
            {
                return;
            }
        }

        private static void resetGameBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }
        }

        /**private static string runGame()
        {
            //while (playAgain == "y")
            //{
                int userTurn = -1;
                int computerTurn = -1;
                Random rand = new Random();
                int playerTurn = 3;
                string validInfo;
                bool isInRange = false;
                int playerSymbol = 0;
                int computerSymbol = 0;
                while (playerTurn == 3)
                {
                    Console.WriteLine("Would you like to play first or second please enter 1 or 2.");
                    validInfo = Console.ReadLine();
                    isInRange = int.TryParse(validInfo, out playerTurn);
                    if (!isInRange || playerTurn < 1 || playerTurn > 2)
                    {
                        playerTurn = 3;
                        Console.WriteLine("Invalid entry! ");
                    }
                }
                while (playerSymbol == 0)
                {
                    Console.WriteLine("What symbol would you like to use press 8 for 'X' or 9 for 'O'.");
                    validInfo = Console.ReadLine();
                    isInRange = int.TryParse(validInfo, out playerSymbol);
                    if (!isInRange || playerSymbol < 8 || playerSymbol > 9)
                    {
                        playerSymbol = 0;
                        Console.WriteLine("Invalid entry! ");
                    }
                    if (playerSymbol == 8)
                    {
                        computerSymbol = 9;
                    }
                    else
                    {
                        computerSymbol = 8;
                    }

                }


                while (checkForWinner() == 0)
                {
                    if (playerTurn == 1)
                    {
                        while (userTurn == -1 || board[userTurn] != 0 && exit != input)
                        {
                            bool isNumber = false;
                            while (!isNumber)
                            {
                                /**if (checkForWinner() != 0)
                                {
                                    printBoard();
                                    //Console.WriteLine("Player " + checkForWinner() + " wins!");
                                    Console.WriteLine("Computer wins!1");
                                    anotherGame();
                                    //return;
                                }**/
        /**
                                if (checkForDraw() == 3)
                                {
                                    Console.WriteLine("Game Ends in Draw.");
                                    printBoard();
                                    anotherGame();
                                    //if (playAgain == "n")
                                    //{
                                    //    return;
                                    //}
                                }
                                if (checkForWinner() == 0)
                                {
                                    isNumber = true;
                                    Console.WriteLine("Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                    input = Console.ReadLine();
                                }
                                endGame();
                                //if (exit == input.ToLower())
                                //{
                                //    return;
                                //}
                                if (checkForWinner() == 0)
                                {
                                    isNumber = int.TryParse(input, out userTurn);
                                }
                                if (!isNumber || userTurn < 0 || userTurn > 8)
                                {
                                    userTurn = -1;
                                    Console.WriteLine("Invalid entry! ");
                                }
                            }
                        }
                        if (checkForWinner() == 0)
                        {
                            Console.WriteLine("You typed " + userTurn);
                            board[userTurn] = playerSymbol;
                            printBoard();
                            turnsTaken++;
                            playerTurn++;
                        }
                    }

                    if (playerTurn == 2)
                    {
                        //don't allow computer to pick invalid number
                        while (computerTurn == -1 || board[computerTurn] != 0 && exit != input)
                        {
                            if (checkForWinner() != 0)
                            {
                                printBoard();
                                //Console.WriteLine("Player " + checkForWinner() + " wins!");
                                Console.WriteLine("Player wins!");
                                anotherGame();
                                //if (playAgain == "n")
                                //{
                                //    return;
                                //}
                            }
                            if (checkForDraw() == 3)
                            {
                                Console.WriteLine("Game Ends in Draw.");
                                printBoard();
                                anotherGame();
                                //if (playAgain == "n")
                                //{
                                //    return;
                                //}
                            }
                            if (checkForWinner() == 0)
                            {
                                computerTurn = rand.Next(9);
                                Console.WriteLine("Computer chooses " + computerTurn);
                            }
                        }
                        if (checkForWinner() == 0)
                        {
                            board[computerTurn] = computerSymbol;
                            turnsTaken++;
                        }
                        if (checkForWinner() != 0)
                        {
                            printBoard();
                            Console.WriteLine("Computer wins!");
                            anotherGame();
                            //if (playAgain == "n")
                            //{
                            //    return;
                            //}
                        }
                        if (checkForWinner() == 0)
                        {
                            printBoard();
                            playerTurn--;
                        }
                    }
                }
            //}
            return playAgain;
        }**/

        private static string anotherGame()
        {
            bool isStringForm;
            Console.WriteLine("Would you like to play again? y/n ");
            input = Console.ReadLine();
            playAgain = input.ToLower();
            if (playAgain == "y")
            {
                return playAgain;
            }
            else
            {
                return "n";
            }
        }

        private static int checkForDraw()
        {
            if (turnsTaken == 9)
            {
                Console.WriteLine("Game Over No More Moves Available!");
                return 3;
            }
            return 0;
        }

        private static int checkForWinner()
        {
            //top row
            if (board[0] == board[1] && board[1] == board[2])
            {
                return board[0];
            }

            //second row
            if (board[3] == board[4] && board[4] == board[5])
            {
                return board[3];
            }

            //third row
            if (board[6] == board[7] && board[7] == board[8])
            {
                return board[6];
            }

            //first column
            if (board[0] == board[3] && board[3] == board[6])
            {
                return board[0];
            }

            //second column
            if (board[1] == board[4] && board[4] == board[7])
            {
                return board[1];
            }

            //third column
            if (board[2] == board[5] && board[5] == board[8])
            {
                return board[2];
            }

            //first diagnal
            if (board[0] == board[4] && board[4] == board[8])
            {
                return board[0];
            }

            //second diagnal
            if (board[2] == board[4] && board[4] == board[6])
            {
                return board[2];
            }
            return 0;
        }

        private static void printBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                //Print an X or O for each square
                //0 = unoccupied, 1 = player one (X), 2 = player two (O)

                if (board[i] == 0)
                {
                    Console.Write(".");
                }
                if (board[i] == 8)
                {
                    Console.Write("X");
                }
                if (board[i] == 9)
                {
                    Console.Write("O");
                }

                //Print a new line every 3rd character
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}


