
public class GameManager {
	static int r,c; //Rows, Colls.
	
	//"Init" and "Display" get a matrix so they can be used in other projects.
	
	public static void Init(char[][] board) { //initializes the board.
		for(r=0;r<board.length;r++) {
			for(c=0;c<board[r].length;c++) {
				board[r][c] = ' ';
			}
		}
	}
	
	public static void Display(char[][] board) { //Displays the board
		System.out.println(" ------------- ");
		for (r = 0; r < board.length; r++) {
            System.out.print(" | ");
            for (c = 0; c < board[r].length; c++) {
                System.out.print(board[r][c]);
                System.out.print(" | ");
            }
            System.out.println();
            System.out.println(" ------------- ");
        }
	}
	
	public static void Place(int row, int col) { //places sign and checks if the player won.
		if(Main.turn)
			Main.board[row][col] = 'X';
		else
			Main.board[row][col] = 'O';
		CheckWin(row,col);
	}
	
	public static void Play() {
		System.out.println("Where would you like to play?");
		System.out.println("Row:"); //Row to play in
		r = Main.in.nextInt();
		System.out.println("Colloum:"); //Col to play in
		c = Main.in.nextInt();
		
		if(r > 2 || r < 0 || c < 0 || c > 2) { //Checks if request is in boundaries.
			System.out.println("Rows and Collums are from 0 to 2 in this game. please enter your move again.");
			Play();
		}
		else if(Main.board[r][c] == ' ') //Checks if spot is available.
			Place(r,c);
		else {
			System.out.println("ERROR: Spot is taken!");
			Play();
		}
		
	}
	
	public static boolean CheckWinRow(int row, int col) { //checks for win in rows
		boolean win = true;
		for(c = 0; c < Main.board[0].length && win; c++)
			if(Main.board[row][col] != Main.board[row][c])
				win = false;
		return win;
	}
	
	public static boolean CheckWinCol(int row, int col) {
		boolean win = true;
		for(r = 0; r < Main.board.length && win; r++)
			if(Main.board[row][col] != Main.board[r][col])
				win = false;
		return win;
	}
	
	public static boolean CheckWinDiag1(int row, int col) { //checks for win in diag1 (0:0-2:2)
		boolean win = true;
		if(row == col) {
			for(c = 0; c < Main.board.length && win; c++) {
				if(Main.board[row][col] != Main.board[c][c])
					win = false;
			}
			return win;
		}
		else
			return false; //The spot is not on the diag.
	}
	
	public static boolean CheckWinDiag2(int row, int col) { //checks for win in diag2 (0:2-2:0)
		boolean win = true;
		if(row + col == 2) {
			for(r=0;r<Main.board.length && win; r++) {
				c = 2-r;
				if(Main.board[row][col] != Main.board[r][c])
					win = false;
			}
			return win;
		}
		else
			return false; //The spot is not on this diag.
	}
	
	public static void CheckWin(int row, int col) {
		System.out.println("Row: " + CheckWinRow(row, col));
		System.out.println("Col: " + CheckWinCol(row, col));
		System.out.println("Diag1: " + CheckWinDiag1(row, col));
		System.out.println("Diag2: " + CheckWinDiag2(row, col));
		
		if(CheckWinRow(row, col) || CheckWinCol(row, col) || CheckWinDiag1(row, col) || CheckWinDiag2(row, col))
			Main.isWon = true;
		
	}
	
}
