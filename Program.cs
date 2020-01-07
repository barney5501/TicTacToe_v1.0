using System;

namespace TicTacToe
{
    class Program
    {
        public static bool turn = true;
        public static bool isWin = false;
        public static char[,] board = new char[3, 3]; //the game board 
        static void Main(string[] args)
        {
            Random rnd = new Random(); //1 for X, 0 for O.
            string p1, p2; //names of players.
            int turns=0; //number of turns.
            char ans = ' ';
            
            //introduction
            System.Console.WriteLine("Would you like to see the intro to the game? (Y/N) ");
            ans = char.Parse(Console.ReadLine());
            if(ans == 'y' || ans == 'Y')
                GameManager.introduction();

            //Name Choosing
            Console.WriteLine("Player1- What is Your Name?");
            p1 = Console.ReadLine();
            Console.WriteLine("Player2- What is Your Name?");
            p2 = Console.ReadLine();

            //picking who starts first
            //p1 always starts and he is always X. p1 and p2 can switch before the game
            //(code below) for randomness of who plays first. 50-50 chance.
            if (rnd.Next(1, 3) != 1) //if 1 p1 starts, if 2 p2 starts.
            {
                string temp = p1;
                p1 = p2;
                p2 = temp;
            }
            

            Console.WriteLine("Game Begins. Good Luck!");
            GameManager.init(board);
            
            bool p1isBot = BotManager.isPlayerBot(p1);
            bool p2isBot = BotManager.isPlayerBot(p2);
            if (p1isBot || p2isBot)
            { //bot game
                ChooseLevel: Console.WriteLine("Choose Level Of Bot(0,1,2,3)");
                try{
                BotManager.lvl = int.Parse(Console.ReadLine());
                }
                catch{
                    System.Console.WriteLine("Please enter a number.");
                    goto ChooseLevel;
                }
                if(BotManager.lvl > 3 || BotManager.lvl < 0){
                    System.Console.WriteLine("Please enter a number between 0 and 3.");
                    goto ChooseLevel;
                    }
                while (!isWin && turns < 9)
                {
                    GameManager.display(board);
                    if (turn) { 
                        Console.WriteLine(p1 + "'s turn. You Are X.");
                        if (p1isBot)
                            BotManager.BotPlayLevel();
                        else
                            GameManager.play();
                    }
                    else {
                        Console.WriteLine(p2 + "'s turn. You Are O.");
                        if (p2isBot)
                            BotManager.BotPlayLevel();
                        else
                            GameManager.play();
                    }

                    turn = !turn;
                    turns++;
                }
            }
            else
            { //2p game
                while (!isWin && turns < 9)
                {
                    GameManager.display(board);
                    if (turn)
                        Console.WriteLine(p1 + "'s turn. You Are X.");
                    else
                        Console.WriteLine(p2 + "'s turn. You Are O.");
                    GameManager.play();
                    turn = !turn;
                    turns++;
                }
            }

            GameManager.display(board);

            if (isWin) {
                turn = !turn;
                if(turn)
                    Console.WriteLine(p1 + " WON THE GAME!");
                else
                    Console.WriteLine(p2 + " WON THE GAME!");
            }
            else
                Console.WriteLine("TIE");
        }
    }
}
//TODO
    //add string of currPlayer, currplayer=turn?p1:p2 LINE52