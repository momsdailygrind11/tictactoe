using System;
using System.Collections.Generic;

namespace tictactoe
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe");

            Console.WriteLine("How many players: ");
            int numberPlaying = Convert.ToInt32(Console.ReadLine());
            
            List<Player> players = new List<Player>();
            SetUpPlayers(numberPlaying, players);       

            //asking rows and cols to set up board
            Console.WriteLine("How many rows?");
            int userInput1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many columns?");
            int userInput2 = Convert.ToInt32(Console.ReadLine());

            char[,] board = new char[userInput1, userInput2];

            
            makingMoves( userInput1, userInput2, board, players);

            }
        static void Initialize(char[,] board, int userInput1, int userInput2)
        {
            //initialize game board
            for (int rows = 0; rows < userInput1; rows++)
            {
                for (int cols = 0; cols < userInput2; cols++)
                {
                    board[rows, cols] = ' ';
                }
            }
        }
        static void makingMoves(int rows, int cols, char[,] board, List<Player> players)
        {
            Initialize(board, rows, cols);

            bool gameGoing = true;
            int movesPlayed = 0;
            int totalMoves = rows * cols;


            while (gameGoing == true)
            {

                for (int m = 0; m < players.Count; m++)
                {
                    if (movesPlayed == totalMoves)
                    {
                        gameGoing = false;
                        Console.WriteLine("All out of moves!");
                        break;
                    }
                    var currentPlayer = players[m];
                  
                    //state which players turn it is
                    gameBoard(rows, cols, board);
                    Console.WriteLine(players[m].Name + " it is your turn!");


                    Console.Write("Please enter a row: ");
                    int row = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter a column: ");
                    int col = Convert.ToInt32(Console.ReadLine());

                    //assign players marker to row and col given
                    board[row, col] = currentPlayer.Marker;
                    movesPlayed++;

                    
                }
                    
                  

               

                gameBoard(cols, rows, board);
            }
        }
        static void gameBoard(int userInput2, int userInput1, char[,] board)
            {
            Console.Clear();
                //initializing board
                for (int row = 0; row < userInput1; row++)
                {
                    Console.Write("|");
                    for (int col = 0; col < userInput2; col++)
                    {
                    Console.Write(" ");
                    Console.Write(board[row, col]);
                    Console.Write(" |");
                    }
                    Console.WriteLine();
                }
            }
        static void SetUpPlayers(int numberPlaying, List<Player> players)
            {  
        //Create players
                for (int p = 0; p < numberPlaying; p++)
                {   Console.WriteLine("What is player's name");
                    var name = Console.ReadLine();
                char marker;
                  
                        Console.WriteLine("Which marker for this player? ");
                        marker = Console.ReadKey().KeyChar;
                    
                    Console.WriteLine();
                    players.Add(new Player { Name = name, Marker = marker });
                }
            }
    }



}


      
        
    

