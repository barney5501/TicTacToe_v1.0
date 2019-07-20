import java.util.Scanner;

public class Main {
	public static Scanner in = new Scanner(System.in);
	
	public static boolean turn = true; //true is 1st p turn, false is 2nd p turn.
	public static boolean isWon = false; //checks if someone won the game.
	public static char[][] board = new char[3][3];
	public static void main(String[] args) {
		String p1, p2; //names of players.
		int turns = 0; //counts the number of turns played.
		
		//Name Choosing
		System.out.println("Player1 - enter your name");
		p1 = in.next();
		System.out.println("Player2 - enter your name");
		p2 = in.next();
		
		/*Picking randomly who starts first
		* p1 always starts and he is always X. this may switch who is
		* p1 and who is p1, so the first player to play is chosen randomly.
		*/
		if( (int)(Math.random()*2) != 1) {
			String temp = p1;
			p1 = p2;
			p2 = temp;
		}
		
		System.out.println("Game Begins- Good Luck!");
		GameManager.Init(board);
		
		while(!isWon && turns < 9) {
			GameManager.Display(board);
			if(turn)
				System.out.println(p1 + "'s turn. You are X.");
			else
				System.out.println(p2 + "'s turn. You are O.");
			GameManager.Play();
			turn = !turn;
			turns++;
		}
		
		GameManager.Display(board);
		
		if(isWon) {
			turn =!turn;
			if(turn)
				System.out.println(p1 + " WON THE GAME!");
			else
				System.out.println(p2 + " WON THE GAME!");
		}
		else
			System.out.println("TIE");
		
	}

}
