using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameManager
    {
        static int r, c; //Rows, Cols

        public static void introduction(){
            Console.WriteLine("Hello Player!");
            //System.Threading.Thread.Sleep(1500);
            Console.WriteLine("Welcome To My Tic-Tac-Toe Game!");
            Console.WriteLine();
            //System.Threading.Thread.Sleep(1500);
            Console.WriteLine("-When the game starts, you will see A 3 by 3 board in front of you.");
            //System.Threading.Thread.Sleep(3000);
            Console.WriteLine("-The lines are numbered from 0 to 2, NOT from 1 to 3.");
            Console.WriteLine("-So, Lets say you want to play in the center of the board. this will be row 1, colloum 1.");
            Console.WriteLine();
            //System.Threading.Thread.Sleep(5000);
            Console.WriteLine("-If you'd like to play against a bot, you can do that too!");
            Console.WriteLine("-Enter one of the player names as 'Bot', and then choose a difficulty level.");
            Console.WriteLine("-In the end, the game will announce the winner.");
            Console.WriteLine();
            //System.Threading.Thread.Sleep(7000);
            Console.WriteLine("GOOD LUCK! (press enter to proceed)");
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void init(char[,] board) //initializes the board
        {
            for (r = 0; r < board.GetLength(0); r++)
                for (c = 0; c < board.GetLength(0); c++)
                    board[r, c] = ' ';
        }

        public static void display(char[,] board) //displays the board
        {
            Console.WriteLine(" ------------- "); //
            for (c = 0; c < board.GetLength(1); c++)
            {
                Console.Write(" | ");
                for (r = 0; r < board.GetLength(0); r++)
                {
                    Console.Write(board[c,r]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.WriteLine(" ------------- "); //
            }
        }
        
        public static void place(char[,] board, int row, int col) //places X or O for player
        {
            if (Program.turn)
                board[row, col] = 'X';
            else
                board[row, col] = 'O';
        }
        public static void placeAndCheck(char[,] board, int row, int col) //places X or O for player
        {
            if (Program.turn)
                board[row, col] = 'X';
            else
                board[row, col] = 'O';
            checkWin(row, col);
        }

        public static void play() //runs the turns of the game
        {
            Console.WriteLine("Where would you like to play?");
            Console.WriteLine("Row:"); //Row to play in
            r = int.Parse(Console.ReadLine());
            Console.WriteLine("Colloum:"); //Colloum to play in
            c = int.Parse(Console.ReadLine());
            if (r > 2 || r < 0 || c < 0 || c > 2) //checks if request is in bounderies.
            {
                Console.WriteLine("Rows and Collums are from 0 to 2 in this game. please enter your move again.");
                play();
            }
            else
            {
                if (Program.board[r, c] == ' ')
                { //check if spot is available
                    place(Program.board, r, c);
                    checkWin(r, c);
                }
                else
                {
                    Console.WriteLine("ERROR: Spot is taken!");
                    play();
                }
                
            }
            //checkWin(r, c);
        }
        
        public static bool checkWinRow(int row, int col)
        {
            //checks for win in a row
            bool rowIsWin = true;
            for (c = 0; c < Program.board.GetLength(1) && rowIsWin; c++)
                if (Program.board[row, col] != Program.board[row, c])
                    rowIsWin = false; //localIsWin = false;
            return rowIsWin;
        }

        public static bool checkWinCol(int row, int col)
        {
            //checks for win in a col
            bool colIsWin = true;
            for (r = 0; r < Program.board.GetLength(0) && colIsWin; r++)
                if (Program.board[row, col] != Program.board[r, col])
                    colIsWin = false; //localIsWin = false;
            return colIsWin;
        }

        public static bool checkWinDiag1(int row, int col)
        {
            //checks for win in diag1
            bool diag1IsWin = true;
            if (row == col)
            { //diag1                            
                for (c = 0; c < Program.board.GetLength(0) && diag1IsWin; c++)
                {
                    if (Program.board[row, col] != Program.board[c, c])
                        diag1IsWin = false; //localIsWin = false;
                }
                return diag1IsWin;
            }
            else
                return false; //the spot played in is not in on this diag.
        }

        public static bool checkWinDiag2(int row, int col)
        {
            //checks for win in diag2
            bool diag2IsWin = true;
            if (row + col == 2)
            {
                for (r = 0; r < Program.board.GetLength(0) && diag2IsWin; r++)
                {
                    c = 2 - r;
                    if (Program.board[row, col] != Program.board[r, c])
                        diag2IsWin = false; //localIsWin = false;
                }
                return diag2IsWin;
            }
            else
                return false;
        }

        public static void checkWin(int row, int col)
        {
            //checks for a win all across the Program.board
            if(checkWinRow(row, col) || checkWinCol(row, col) || checkWinDiag1(row, col) || checkWinDiag2(row, col))
                Program.isWin = true;
        }
    }
}
//TODO:
    //fix bug: if out of bounderies and play again game crashes.
        //^Fixed
    //
