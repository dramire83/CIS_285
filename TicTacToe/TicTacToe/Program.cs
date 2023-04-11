// See https://aka.ms/new-console-template for more information
using System;

namespace TicTacToe
{
    class Program
    {
        static int gamesTied = 0, gamesComputerWon = 0, gamesPlayerWon = 0, computerInput = 0, playerInput = 0, playerTurn = 3, computerTurn = -1, userTurn = -1, turnsTaken = 0;
        static string playAgain = "y", input = "", exit = "q", playerSymbol = "X", computerSymbol = "O", validInfo = "", playerChosenSymbol = "", startGame = "", gameState = "";
        static int[] board = new int[9];
        static bool isInRange = false;
        static void Main(string[] args)
        {

            //initial board generation
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }

            Random rand = new Random();

            do
            {
                gameMenu();
                if (exit == input)
                {
                    return;
                }
                while (playerTurn == 3 && gameState == "y")
                {
                    Console.Clear();
                    welcomeSign();
                    turnChosen();
                    playerInput = 0;

                    while (playerInput == 0 && gameState == "y")
                    {
                        symbolChosen();

                        if (playerInput == 8 && gameState == "y")
                        {
                            computerInput = 9;
                            playerSymbol = "X";
                            computerSymbol = "O";
                        }
                        else
                        {
                            computerInput = 8;
                            playerSymbol = "O";
                            computerSymbol = "X";
                        }
                        Console.Clear();


                        while (checkForWinner() == 0 && playerInput == 8 || playerInput == 9 && gameState == "y")
                        {
                            reprintEntryGameBoard();
                            if (playerTurn == 1 && gameState != "")
                            {
                                while (userTurn == -1 || board[userTurn] != 0 && exit != input && gameState == "y")
                                {

                                    bool isNumber = false;
                                    while (!isNumber && gameState == "y")
                                    {
                                        if (checkForWinner() != 0 && gameState == "y")
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
                                                gameState = "";
                                                return;
                                            }
                                        }

                                        if (checkForDraw() == 3 && gameState == "y")
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
                                                gameState = "";
                                                return;
                                            }
                                        }
                                        if (checkForWinner() == 0 && gameState == "y")
                                        {
                                            isNumber = true;
                                            Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                            input = Console.ReadLine();
                                            if (exit == input.ToLower())
                                            {
                                                gameState = "";
                                                endGameResults();
                                                return;
                                            }
                                            isNumber = int.TryParse(input, out userTurn);
                                            while (!isNumber || userTurn < 0 || userTurn > 8 && gameState == "y")
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
                                                    gameState = "";
                                                    return;
                                                }
                                            }
                                            while (board[userTurn] != 0 && gameState == "y")
                                            {
                                                 reprintEntryGameBoard();
                                                 Console.WriteLine(" ");
                                                 Console.WriteLine(" Space " + userTurn + " is already occupied, try again");
                                                 Console.WriteLine(" ");
                                                 Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                                 input = Console.ReadLine();
                                                 if (exit == input.ToLower())
                                                 {
                                                     endGameResults();
                                                     gameState = "";
                                                     return;
                                                 }
                                                 isNumber = int.TryParse(input, out userTurn);
                                                 while (!isNumber || userTurn < 0 || userTurn > 8 && gameState == "y")
                                                 {
                                                     reprintEntryGameBoard();
                                                     Console.WriteLine(" ");
                                                     Console.WriteLine(" Invalid entry, try again");
                                                     Console.WriteLine(" ");
                                                     Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                                     input = Console.ReadLine();
                                                     isNumber = int.TryParse(input, out userTurn);
                                                     if (exit == input.ToLower())
                                                     {
                                                         endGameResults();
                                                         gameState = "";
                                                         return;
                                                    }
                                                 }
                                            }
                                            
                                        }
                                    }
                                }
                                if (checkForWinner() == 0 && gameState == "y")
                                {
                                    Console.WriteLine(" You typed " + userTurn);
                                    board[userTurn] = playerInput;
                                    printBoard();
                                    turnsTaken++;
                                    playerTurn++;
                                }
                                Console.Clear();
                            }
                            if (playerTurn == 2 && gameState == "y")
                            {
                                //don't allow computer to pick invalid number
                                while (computerTurn == -1 || board[computerTurn] != 0 && exit != input && gameState == "y")
                                {
                                    if (checkForWinner() != 0 && gameState == "y")
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
                                            gameState = "";
                                            return;
                                        }
                                        
                                    }
                                    if (checkForDraw() == 3 && gameState == "y")
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
                                            gameState = "";
                                            return;
                                        }
                                    }
                                    if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9 && gameState == "y")
                                    {
                                        computerTurn = rand.Next(9);
                                        Console.WriteLine(" Computer chooses " + computerTurn);
                                    }
                                }
                                if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9 && gameState == "y")
                                {
                                    board[computerTurn] = computerInput;
                                    turnsTaken++;
                                }
                                if (checkForWinner() != 0 && gameState == "y")
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
                                        gameState = "";
                                        return;
                                    }
                                }
                                if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9 && gameState == "y")
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
        private static string gameMenu()
        {
            do
            {
                Console.Clear();
                welcomeSign();
                Console.WriteLine("               ******  MAIN MENU  ******");
                Console.WriteLine(" ");
                Console.WriteLine("     Welcome, would you like to play tic tac toe y/n?");
                startGame = Console.ReadLine();
                gameState = startGame.ToLower();
                if (gameState == "y")
                {
                    return input;
                }
                else if (gameState == "n")
                {
                    Console.WriteLine("Have a great day!");
                    input = "q";
                    return input;
                }
                else
                {
                    startGame = "";
                    Console.WriteLine("Invalid Entry, Try Again.");
                }

            } while (startGame == "");
            return gameState;
        }

        private static int symbolChosen()
        {
            Console.WriteLine(" What symbol would you like to use 'X' or 'O'.");
            validInfo = Console.ReadLine();
            playerChosenSymbol = validInfo.ToLower();
            while (playerInput == 0)
            {
                if (playerChosenSymbol == "x")
                {
                    playerInput = 8;
                    return playerInput;
                }
                else if (playerChosenSymbol == "o")
                {
                    playerInput = 9;
                    return playerInput;
                }
                else
                {
                    Console.Clear();
                    welcomeSign();
                    playerInput = 0;
                    Console.WriteLine(" Invalid entry! ");
                    Console.WriteLine(" What symbol would you like to use 'X' or 'O'.");
                    validInfo = Console.ReadLine();
                    playerChosenSymbol = validInfo.ToLower();
                }
            }
            return playerInput;
        }
        private static int turnChosen()
        {
            do
            {
                Console.Clear();
                welcomeSign();
                playerTurn = 3;
                Console.WriteLine(" Would you like to play first or second please enter 1 or 2.");
                validInfo = Console.ReadLine();
                isInRange = int.TryParse(validInfo, out playerTurn);
            } while (!isInRange || playerTurn < 1 || playerTurn > 2);
            return playerTurn;
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
            //top row, first column, first diagnal
            if ((board[0] == board[1] && board[1] == board[2]) || (board[0] == board[3] && board[3] == board[6]) || (board[0] == board[4] && board[4] == board[8]))
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

            //second column
            if (board[1] == board[4] && board[4] == board[7])
            {
                return board[1];
            }

            //third column, second diagnol
            if ((board[2] == board[5] && board[5] == board[8]) || (board[2] == board[4] && board[4] == board[6]))
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


