// See https://aka.ms/new-console-template for more information
using System;

namespace TicTacToe
{
    class Program
    {
        //Declaration of program varriables with thier respective initialized values.
        static int gamesTied = 0, gamesComputerWon = 0, gamesPlayerWon = 0, computerInput = 0, playerInput = 0, playerTurn = 3, computerTurn = -1, userTurn = -1, turnsTaken = 0;
        static string playAgain = "y", input = "", exit = "q", playerSymbol = "X", computerSymbol = "O", validInfo = "", playerChosenSymbol = "", startGame = "", gameState = "";
        //Declaration of an int type array of 9 indices.
        static int[] board = new int[9];
        //Declaration of boolean variable also initialized with false value.
        static bool isInRange = false;

        static void Main(string[] args)
        {
            //Created new object named rand as type Random
            Random rand = new Random();

            //Start Do-while loop for main game
            //allows player to choose to either play or exit the game.
            do
            {
                //Display welcome sign and verify if player would like to play game.
                gameMenu();
                //If loop to check to see player wants to exit game.
                endGame(exit, input, playAgain);
                //Choose to either go first or second by user.
                turnChosen();
                //Symbol "X" or "O" chosen by user for player and computer to use in game.
                symbolChosen();
                //Sets the player and computer symbol based on choice.
                updateSymbol();
                
                //While loop for actual game play logic.
                //Check if the game is over: win, loss, or tie. 
                while (checkForWinner() == 0 && playerInput == 8 || playerInput == 9)
                {
                    //Prints board for user to see
                     reprintEntryGameBoard();
                    //Starts the game by having the user going 1st or 2nd as chosen by user.
                     gameTurn(playerTurn, rand);
                }
            } while (playAgain == "y"); //End do-while loop, End of game
        }


        //endGame method passes three variables by value to determine if player would like to quit game.
        private static void endGame(string _exit, string _input, string _playAgain) 
        {
            if (_exit == _input.ToLower())
            {
                endGameResults();
                System.Environment.Exit(0);
            }
            else if (_playAgain == "n")
            {
                endGameResults();
                System.Environment.Exit(0);
            }
        }

        //gameTurn method passes two variables by value to run different code depending on either first or second turn chosen.
        private static void gameTurn(int _playerTurn, Random _rand)
        { 
            playerTurn = _playerTurn;
            if (playerTurn == 1)
            {
                while (userTurn == -1 || board[userTurn] != 0)
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
                            endGame(exit, input, playAgain);
                        }
                        if (checkForWinner() == 0)
                        {
                            isNumber = true;
                            Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                            input = Console.ReadLine();
                            endGame(exit, input, playAgain);
                            isNumber = int.TryParse(input, out userTurn);
                            while (!isNumber || userTurn < 0 || userTurn > 8)
                            {
                                reprintEntryGameBoard();
                                userTurn = -1;
                                Console.WriteLine(" Invalid entry! ");
                                Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                input = Console.ReadLine();
                                isNumber = int.TryParse(input, out userTurn);
                                endGame(exit, input, playAgain);
                            }
                            while (board[userTurn] != 0)
                            {
                                reprintEntryGameBoard();
                                Console.WriteLine(" ");
                                Console.WriteLine(" Space " + userTurn + " is already occupied, try again");
                                Console.WriteLine(" ");
                                Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                input = Console.ReadLine();
                                endGame(exit, input, playAgain);
                                isNumber = int.TryParse(input, out userTurn);
                                while (!isNumber || userTurn < 0 || userTurn > 8)
                                {
                                    reprintEntryGameBoard();
                                    Console.WriteLine(" ");
                                    Console.WriteLine(" Invalid entry, try again");
                                    Console.WriteLine(" ");
                                    Console.WriteLine(" Please enter a number from 0 to 8 or press the q key and enter to exit.");
                                    input = Console.ReadLine();
                                    isNumber = int.TryParse(input, out userTurn);
                                    endGame(exit, input, playAgain);
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
                if (checkForDraw() == 3)
                {
                    printBoard();
                    Console.WriteLine(" ");
                    Console.WriteLine(" Game Ends in Draw.");
                    gamesTied++;
                    Console.WriteLine(" ");
                    anotherGame();
                    endGame(exit, input, playAgain);
                }
            }
            if (playerTurn == 2)
            {
                //don't allow computer to pick invalid number
                while (computerTurn == -1 || board[computerTurn] != 0)
                {
                    if (checkForWinner() != 0 && gameState == "y")
                    {
                        printBoard();
                        Console.WriteLine(" ");
                        Console.WriteLine(" Player wins!");
                        gamesPlayerWon++;
                        Console.WriteLine(" ");
                        anotherGame();
                        endGame(exit, input, playAgain);

                    }
                    if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9)
                    {
                        computerTurn = _rand.Next(9);
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
                    endGame(exit, input, playAgain);
                }
                if (checkForWinner() == 0 && computerInput == 8 || computerInput == 9)
                {
                    printBoard();
                    playerTurn--;
                }
                if (checkForDraw() == 3)
                {
                    printBoard();
                    Console.WriteLine(" ");
                    Console.WriteLine(" Game Ends in Draw.");
                    gamesTied++;
                    Console.WriteLine(" ");
                    anotherGame();
                    endGame(exit, input, playAgain);
                }
            }

        }

        //updateSymbol method sets the symbols for the player and computer.
        private static void updateSymbol() 
        {
            if (playerInput == 8)
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
        }

        //gameMenu method to Display welcome sign and verify if player would like to play game.
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

        //symbolChosen method gets the user input to choose either "X" or "O".
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

        //turnChosen method allows the user to go either 1st or 2nd.
        private static int turnChosen()
        {
            do
            {
                Console.Clear();
                welcomeSign();
                playerInput = 0;
                playerTurn = 3;
                Console.WriteLine(" Would you like to play first or second please enter 1 or 2.");
                validInfo = Console.ReadLine();
                isInRange = int.TryParse(validInfo, out playerTurn);
            } while (!isInRange || playerTurn < 1 || playerTurn > 2);
            return playerTurn;
        }

        //reprintEntryGameBoard method clears and reprints game symbols and gameboard to prevent screen scrolling.
        private static void reprintEntryGameBoard()
        {
            Console.Clear();
            printBoard();
            Console.WriteLine(" ");
            Console.WriteLine(" USER symbol: " + playerSymbol + "          SYSTEM symbol: " + computerSymbol);
            Console.WriteLine(" ");
            printKeyBoard();
        }

        //welcomeSign method creates a welcome sign visual.
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

        //endGameResults method creates a visual of the recorded games during the users session.
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

        //resetGameBoard method resets the gameboard for a new game.
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

        //anotherGame method gets user input to play another game.
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

        //checkForDraw method checks to see if game ends in draw.
        private static int checkForDraw()
        {
            if (turnsTaken == 9)
            {
                Console.WriteLine(" Game Over No More Moves Available!");
                return 3;
            }
            return 0;
        }

        //checkForWinner method checks to see if game ends in a winner.
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

        //printBoard method creates a board visual for the game.
        private static void printBoard()
        {
            //Console.Clear();
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

        //printKeyBoard method creates a key for the user to use when chosing thier placement.
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


