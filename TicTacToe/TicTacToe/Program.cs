// See https://aka.ms/new-console-template for more information
using System;

namespace TicTacToe
{
    class Program
    {
        static int gamesTied = 0, gamesComputerWon = 0, gamesPlayerWon = 0, computerInput = 0, playerInput = 0, playerTurn = 3, computerTurn = -1, userTurn = -1, turnsTaken = 0;
        static string playAgain = "y", input = "", exit = "q", playerSymbol = "X", computerSymbol = "O";
        static int[] board = new int[9];
        
        static void Main(string[] args)
        {

            //initial board generation
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }

            Random rand = new Random();

            string validInfo; //playerSymbol = "X", computerSymbol = "O";
            bool isInRange = false;

            do
            {
                //anotherGame();
                while (playerTurn == 3)
                {
                    welcomeSign();
                    playerInput = 0;
                    Console.WriteLine(" Would you like to play first or second please enter 1 or 2.");
                    validInfo = Console.ReadLine();
                        isInRange = int.TryParse(validInfo, out playerTurn);
                        while (!isInRange || playerTurn < 1 || playerTurn > 2)
                        {
                            Console.Clear();
                            welcomeSign();
                            playerTurn = 3;
                            Console.WriteLine(" Invalid entry! ");
                            Console.WriteLine(" Would you like to play first or second please enter 1 or 2.");
                            validInfo = Console.ReadLine();
                            isInRange = int.TryParse(validInfo, out playerTurn);
                        }
                    
                    while (playerInput == 0)
                    {
                        Console.WriteLine(" What symbol would you like to use press 8 for 'X' or 9 for 'O'.");
                        validInfo = Console.ReadLine();
                        isInRange = int.TryParse(validInfo, out playerInput);
                        while (!isInRange || playerInput <= 7 || playerInput >= 10)
                        {
                            Console.Clear();
                            welcomeSign();
                            playerInput = 0;
                            Console.WriteLine(" Invalid entry! ");
                            Console.WriteLine(" What symbol would you like to use press 8 for 'X' or 9 for 'O'.");
                            validInfo = Console.ReadLine();
                            isInRange = int.TryParse(validInfo, out playerInput);
                        }
                        if (playerInput == 8)
                        {
                            computerInput = 9;
                        }
                        else
                        {
                            computerInput = 8;
                        }

                        if (playerInput == 8)
                        {
                            playerSymbol = "X";
                            computerSymbol = "O";
                        }
                        else
                        {
                            playerSymbol = "O";
                            computerSymbol = "X";
                        }
                        Console.Clear();


                        while (checkForWinner() == 0 && playerInput == 8 || playerInput == 9)
                        {
                            reprintEntryGameBoard();
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
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" Computer wins!");
                                            gamesComputerWon++;
                                            Console.WriteLine(" ");
                                            anotherGame();
                                            if (playAgain == "n")
                                            {
                                                endGameResults();
                                                return;
                                            }
                                        }

                                        if (checkForDraw() == 3)
                                        {
                                            printBoard();
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" Game Ends in Draw.");
                                            gamesTied++;
                                            Console.WriteLine(" ");
                                            anotherGame();
                                            if (playAgain == "n")
                                            {
                                                endGameResults();
                                                return;
                                            }
                                        }
                                        if (checkForWinner() == 0)
                                        {
                                            isNumber = true;
                                            Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                            input = Console.ReadLine();
                                            if (exit == input.ToLower())
                                            {
                                                endGameResults();
                                                return;
                                            }
                                            isNumber = int.TryParse(input, out userTurn);
                                            while (!isNumber || userTurn < 0 || userTurn > 8)
                                            {
                                                reprintEntryGameBoard();
                                                userTurn = -1;
                                                Console.WriteLine(" Invalid entry! ");
                                                Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                                input = Console.ReadLine();
                                                isNumber = int.TryParse(input, out userTurn);
                                                if (exit == input.ToLower())
                                                {
                                                    endGameResults();
                                                    return;
                                                }
                                            }
                                            while (board[userTurn] != 0)
                                            {
                                                reprintEntryGameBoard();
                                                Console.WriteLine(" ");
                                                Console.WriteLine(" Space " + userTurn +" is already occupied, try again");
                                                Console.WriteLine(" ");
                                                Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                                input = Console.ReadLine();
                                                if (exit == input.ToLower())
                                                {
                                                    endGameResults();
                                                    return;
                                                }
                                                isNumber = int.TryParse(input, out userTurn);
                                                while (!isNumber || userTurn < 0 || userTurn > 8)
                                                {
                                                    reprintEntryGameBoard();
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine(" Invalid entry, try again");
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                                    input = Console.ReadLine();
                                                    if (exit == input.ToLower())
                                                    {
                                                        endGameResults();
                                                        return;
                                                    }
                                                    isNumber = int.TryParse(input, out userTurn);
                                                }
                                            }
                                        }
                                    }
                                }
                                if (checkForWinner() == 0)
                                {
                                    Console.WriteLine(" You typed " + userTurn);
                                    board[userTurn] = playerInput;
                                    printBoard();
                                    turnsTaken++;
                                    playerTurn++;
                                }
                                Console.Clear();
                            }
                            if (playerTurn == 2)
                            {
                                //don't allow computer to pick invalid number
                                while (computerTurn == -1 || board[computerTurn] != 0 && exit != input)
                                {
                                    if (checkForWinner() != 0)
                                    {
                                        printBoard();
                                        Console.WriteLine(" ");
                                        Console.WriteLine(" Player wins!");
                                        gamesPlayerWon++;
                                        Console.WriteLine(" ");
                                        anotherGame();
                                        if (playAgain == "n")
                                        {
                                            endGameResults();
                                            return;
                                        }
                                        
                                    }
                                    if (checkForDraw() == 3)
                                    {
                                        Console.Clear();
                                        printBoard();
                                        Console.WriteLine(" ");
                                        Console.WriteLine(" Game Ends in Draw.");
                                        gamesTied++;
                                        Console.WriteLine(" ");
                                        anotherGame();
                                        if (playAgain == "n")
                                        {
                                            endGameResults();
                                            return;
                                        }
                                    }
                                    if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9)
                                    {
                                        computerTurn = rand.Next(9);
                                        Console.WriteLine(" Computer chooses " + computerTurn);
                                    }
                                }
                                if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9)
                                {
                                    board[computerTurn] = computerInput;
                                    turnsTaken++;
                                }
                                if (checkForWinner() != 0)
                                {
                                    printBoard();
                                    Console.WriteLine(" ");
                                    Console.WriteLine(" Computer wins!");
                                    gamesComputerWon++;
                                    Console.WriteLine(" ");
                                    anotherGame();
                                    if (playAgain == "n")
                                    {
                                        endGameResults();
                                        return;
                                    }
                                }
                                if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9)
                                {
                                    printBoard();
                                    playerTurn--;
                                }
                            }
                        }
                    }
                }
            } while (playAgain == "y");
        }

        private static void reprintEntryGameBoard()
        {
            Console.Clear();
            printBoard();
            Console.WriteLine(" ");
            Console.WriteLine(" USER symbol: " + playerSymbol + "          SYSTEM symbol: " + computerSymbol);
            Console.WriteLine(" ");
            printKeyBoard();
        }
        private static void welcomeSign()
        {
            Console.WriteLine(" ");
            Console.WriteLine("   **********    Welcome to Tic Tac Toe!    ************");
            Console.WriteLine("   **                                                 **");
            Console.WriteLine("   **        XX   XX        OOO        XX   XX        **");
            Console.WriteLine("   **         XX XX       OO   OO       XX XX         **");
            Console.WriteLine("   **           X        OO     OO        X           **");
            Console.WriteLine("   **         XX XX       OO   OO       XX XX         **");
            Console.WriteLine("   **        XX   XX        OOO        XX   XX        **");
            Console.WriteLine("   **                                                 **");
            Console.WriteLine("   *****************************************************");
            Console.WriteLine(" ");
        }
        private static void endGameResults()
        {
            Console.WriteLine(" ");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("* Player Won " + gamesPlayerWon + " Game(s) || Computer Won " + gamesComputerWon + " Game(s) ||  Game(s) Tied " + gamesTied + " *");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine(" Total Games Played: " + (gamesPlayerWon + gamesComputerWon + gamesTied));
            Console.WriteLine(" ");
            Console.WriteLine(" Press any key to exit...");
            Console.ReadKey();
        }
        private static void resetGameBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }
            Console.Clear();
            turnsTaken = 0;
            userTurn = -1;
            computerTurn = 0;
            playerTurn = 3;
            playerInput = -1;
            computerInput = 0;
            Console.WriteLine(" ");
            Console.WriteLine("                         *NEW GAME*");
        }

        private static string anotherGame()
        {
            bool isStringForm;
            Console.WriteLine(" Would you like to play again? y/n ");
            input = Console.ReadLine();
            playAgain = input.ToLower();
            if (playAgain == "y")
            {
                resetGameBoard();
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
                Console.WriteLine(" Game Over No More Moves Available!");
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
            Console.WriteLine(" ");
            for (int i = 0; i < 9; i++)
            {
                //Print an X or O for each square
                //0 = unoccupied 

                if (board[i] == 0)
                {
                    Console.Write("   .   ");
                }
                if (board[i] == 8)
                {
                    Console.Write("   X   ");
                }
                if (board[i] == 9)
                {
                    Console.Write("   O   ");
                }

                //Print a new line every 3rd character
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }

        private static void printKeyBoard()
        {
            Console.WriteLine(" Use the following key for gameboard position input.");
            Console.WriteLine();
            Console.WriteLine("  0  |  1  |  2  ");
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  3  |  4  |  5  ");
            Console.WriteLine("-----+-----+-----");
            Console.WriteLine("  6  |  7  |  8  ");
            Console.WriteLine();
        }
    }
}


