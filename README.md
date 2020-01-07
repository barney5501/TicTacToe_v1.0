# TicTacToe_v1.0 -- C#
A simple Tic-Tac-Toe game I made in C#. Originally for school (basic) but continued for fun.

Program.cs:
-
runs the game, mostly writes stuff. also the picking of the names.
contains all of the global variables for the program.
  - turn: true for first player, false for second player. this boolean variable makes the running of the game very easy.
  - isWon: checks if someone won the game.
  - board: a 3 * 3 char matrix that is the board.
    
GameManager.cs
-
contains all the function necessary for the game.
  - Init: fills the board with ' '.
  - Display: displays the board.
  - Place: places X or O in the spot chosen by the player. the sign is determined using the "turn" variable (true=X, false=O).
  - Play: asks the player where he wants to play. row and colloum between 0 and 2.
  - CheckWin/Row/Col/Diag1/Diag2: a function for each, and a fuction that uses all the others to check if there is a win in the board or not, using the last played spot. for example, in Rows the function checks if all the slots in the last-played-at row are the same. for the diags the function first checks if the move was on them, and then checks for win if true.

#Add BotManager.cs

How the game works
-
in Program.cs, there is a while loops that run as long as "isWon" is false (no one won the game yet) or the int variable "turns" is lower than 9 (the board isn't full). it displays the board, and announces the players whose turn to play is now (X/O, again determined using "turn").
- calls GameManager.Play().
- turn = !turn
- turns++.

