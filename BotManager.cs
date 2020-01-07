using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class BotManager
    {
        static int r, c;
        public static int lvl;
        static Random rnd = new Random();
        /*static char sign, eSign;
        static bool go;*/

        public static bool isPlayerBot(string p){
            return p.ToLower().StartsWith("bot");
        }
        public static void Botplay() //runs the turns of the game
        {
            // -Console.WriteLine("Bot Play- Random");
            r = rnd.Next(0, 3); //Row to play in
            c = rnd.Next(0, 3); //Colloum to play in
            //Console.WriteLine("r= " + r + " " + " c=" + c);
            // -Console.WriteLine("Random");
            if (Program.board[r, c] == ' ')//check if spot is available
                GameManager.placeAndCheck(Program.board, r, c);
            else
                Botplay();
        }

        public static void BotPlayLevel()
        {
            bool go = false; //think
            char sign, eSign;
            if (Program.turn)
            {
                sign = 'X';
                eSign = 'O';
            }
            else
            {
                sign = 'O';
                eSign = 'X';
            }

            if (lvl <= 0)
                go = false; //!go
            else if (lvl == 1)
                go = (rnd.Next(0, 3) == 2); //0/1/2, if 2 go
            else if (lvl == 2)
                go = (rnd.Next(0, 2) == 1); //0/1, if 1 go
            else if (lvl >= 3)
                go = true; //go

            if (go)
            {
                if (!ifCanWin(sign))
                {
                    if (!ifOppWin(eSign))
                        Botplay();
                }
            }
            else
                Botplay();
        }

        public static bool ifCanWin(char sign)
        {
            bool played = true;
            if (CanWinR(sign)[0] != -1)
                GameManager.placeAndCheck(Program.board, CanWinR(sign)[0], CanWinR(sign)[1]);
            else if (CanWinC(sign)[0] != -1)
                GameManager.placeAndCheck(Program.board, CanWinC(sign)[0], CanWinC(sign)[1]);
            else if (CanWinD1(sign)[0] != -1)
                GameManager.placeAndCheck(Program.board, CanWinD1(sign)[0], CanWinD1(sign)[1]);
            else if (CanWinD2(sign)[0] != -1)
                GameManager.placeAndCheck(Program.board, CanWinD2(sign)[0], CanWinD2(sign)[1]);
            else
                played = false;
            // -Console.WriteLine("Played to attack: " + played);
            return played;
        }

        public static bool ifOppWin(char eSign)
        {
            bool played = true;
            if (NeedBlockR(eSign)[0] != -1)
                GameManager.placeAndCheck(Program.board, NeedBlockR(eSign)[0], NeedBlockR(eSign)[1]);
            else if (NeedBlockC(eSign)[0] != -1)
                GameManager.placeAndCheck(Program.board, NeedBlockC(eSign)[0], NeedBlockC(eSign)[1]);
            else if (NeedBlockD1(eSign)[0] != -1)
                GameManager.placeAndCheck(Program.board, NeedBlockD1(eSign)[0], NeedBlockD1(eSign)[1]);
            else if (NeedBlockD2(eSign)[0] != -1)
                GameManager.placeAndCheck(Program.board, NeedBlockD2(eSign)[0], NeedBlockD2(eSign)[1]);
            else
                played = false;
            // -Console.WriteLine("Played to not lose: " + played);
            return played;
        }

        public static int[] NeedBlockR(char eSign)
        {
            /*Block: looking if enemy can win*/
      
            int counter = 0; //opponent can win?
            bool defence = false; //need to defence?
            int[] toDefence = new int[2]; //{-1,-1}; //where to defence

            for (r = 0; r < Program.board.GetLength(0) && !defence; r++)
            {
                //if row has my sign, skip //only for XO
                toDefence[0] = -1;
                toDefence[1] = -1;
                counter = 0;
                for (c = 0; c < Program.board.GetLength(0); c++)
                {
                    //if colloum has my sign, skip //only for XO
                    if (Program.board[r, c] == eSign)
                        counter++;
                    else if (Program.board[r, c] == ' ')
                    {
                        toDefence[0] = r;
                        toDefence[1] = c;
                    }
                }
                if (counter == Program.board.GetLength(0) - 1)
                {
                    defence = true;
                }
            }
            if (!defence)
                toDefence[0] = -1;
            return toDefence;
        }

        public static int[] CanWinR(char sign)
        {
            int counter = 0; //opponent can win?
            bool attack = false; //need to defence?
            int[] toAttack = new int[2]; //{-1,-1}; //where to defence

            for (r = 0; r < Program.board.GetLength(0) && !attack; r++)
            {
                //if row has my sign, skip //only for XO
                toAttack[0] = -1;
                toAttack[1] = -1;
                counter = 0;
                for (c = 0; c < Program.board.GetLength(0); c++)
                {
                    //if colloum has my sign, skip //only for XO
                    if (Program.board[r, c] == sign)
                        counter++;
                    else if (Program.board[r, c] == ' ')
                    {
                        toAttack[0] = r;
                        toAttack[1] = c;
                    }
                }
                if (counter == Program.board.GetLength(0) - 1)
                {
                    attack = true;
                }
            }
            if (!attack)
                toAttack[0] = -1;
            return toAttack;
        }

        public static int[] NeedBlockC(char eSign)
        {
            int counter = 0;
            bool defence = false;
            int[] toDefence = new int[2];

            for (c = 0; c < Program.board.GetLength(0) && !defence; c++)
            {
                toDefence[0] = -1;
                toDefence[1] = -1;
                counter = 0;
                for (r = 0; r < Program.board.GetLength(0); r++)
                {
                    if (Program.board[r, c] == eSign)
                        counter++;
                    else if (Program.board[r, c] == ' ')
                    {
                        toDefence[0] = r;
                        toDefence[1] = c;
                    }
                }
                if (counter == Program.board.GetLength(0) - 1)
                {
                    defence = true;
                }
            }
            if (!defence)
                toDefence[0] = -1;
            return toDefence;
        }

        public static int[] CanWinC(char sign)
        {
            int counter = 0; //opponent can win?
            bool attack = false; //need to defence?
            int[] toAttack = new int[2]; //{-1,-1}; //where to defence

            for (c = 0; c < Program.board.GetLength(0) && !attack; c++)
            {
                toAttack[0] = -1;
                toAttack[1] = -1;
                counter = 0;
                for (r = 0; r < Program.board.GetLength(0); r++)
                {
                    if (Program.board[r, c] == sign)
                        counter++;
                    else if (Program.board[r, c] == ' ')
                    {
                        toAttack[0] = r;
                        toAttack[1] = c;
                    }
                }
                if (counter == Program.board.GetLength(0) - 1)
                {
                    attack = true;
                }
            }
            if (!attack)
                toAttack[0] = -1;
            return toAttack;
        }

        public static int[] NeedBlockD1(char eSign)
        {
            int counter = 0; //opponent can win?
            int[] toDefence = new int[2] {-1,-1}; //where to defence      
            for (r = 0; r < Program.board.GetLength(0); r++)
            {
                if (Program.board[r, r] == eSign)
                    counter++;
                else if(Program.board[r,r] == ' ')
                {
                    toDefence[0] = r;
                    toDefence[1] = r;
                }
            }
            if (counter == Program.board.GetLength(0) - 1)
                return toDefence;
            else
                return new int[] { -1, -1 };
        }

        public static int[] CanWinD1(char sign)
        {
            int counter = 0; //opponent can win?
            int[] toAttack = new int[2] { -1, -1 }; //where to defence      
            for (r = 0; r < Program.board.GetLength(0); r++)
            {
                if (Program.board[r, r] == sign)
                    counter++;
                else if (Program.board[r, r] == ' ')
                {
                    toAttack[0] = r;
                    toAttack[1] = r;
                }
            }
            if (counter == Program.board.GetLength(0) - 1)
                return toAttack;
            else
            {
                return new int[] { -1, -1 };
            }
        }

        public static int[] NeedBlockD2(char eSign)
        {
            int counter = 0; //opponent can win?
            int[] toDefence = new int[2] { -1, -1 }; //where to defence
            int l = Program.board.GetLength(0) - 1; //"length" of side of square board counting from 0.
            for (c = l ; c >= 0; c--)
            {
                r = l - c;
                if (Program.board[r, c] == eSign)
                    counter++;
                else if (Program.board[r, c] == ' ')
                {
                    toDefence[0] = r;
                    toDefence[1] = c;
                }
            }
            if (counter == l)
                return toDefence;
            else
            {
                return new int[] { -1, -1 };
            }
        }

        public static int[] CanWinD2(char sign)
        {
            int counter = 0; //opponent can win?
            int[] toAttack = new int[2] { -1, -1 }; //where to defence
            int l = Program.board.GetLength(0) - 1; //"length" of side of square board counting from 0.
            for (c = l; c >= 0; c--)
            {
                r = l - c;
                if (Program.board[r, c] == sign)
                    counter++;
                else if (Program.board[r, c] == ' ')
                {
                    toAttack[0] = r;
                    toAttack[1] = c;
                }
            }
            if (counter == l)
                return toAttack;
            else
                return new int[] { -1, -1 };
        }
    }
}
//TODO:
    //bot that plays with a precentage
    //bot that does everything to win
    //add diags
    //make bot lvl1 30ish% change of going there, 70ish% of random.
    //make bot lvl2 50-50
    //make bot lvl3 100%
