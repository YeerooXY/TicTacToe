using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        private string[,] table = new string[3, 3];
        public enum Won
        {
            None = 0, Cross = 1, Cicle = 2,
        }
        private int movecount = 1;
        private int crosswins = 0;
        private int circlewins = 0;
        public bool GameOver()
        {
            if (movecount < 10)
            {
                return false;
            }
            Console.WriteLine("The game is over!");
            return true;
        }
        private bool OccuppiedTile(int row, int col)
        {
            if (table[row, col] == null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("That tile is occuppied. Try a different one. Press any key to retry.");
                Console.ReadKey();
                return true;
            }
        }
        public void PlayerMove()
        {
            string playername = "";
            if (movecount % 2 == 0)
            {
                playername = "cross";
            }
            else
            {
                playername = "circle";
            }
            Console.WriteLine($"It's {playername}'s turn. Please input the row-column where you want your mark. (1-1 is top left, 3-3 is bottom right)");
            try
            {
                string[] input = Console.ReadLine().Split('-');
                int row = int.Parse(input[1]) - 1;
                int col = int.Parse(input[0]) - 1;
                if (!OccuppiedTile(row, col))
                {


                    if (playername == "circle")
                    {


                        table[row, col] = "O";

                    }
                    else
                    {
                        table[row, col] = "X";
                    }
                    movecount++;
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Invalid input! Press any key to retry.");
                Console.ReadKey();
            }

        }
        private void DisplayMoves(int offsetx, int offsety, string character)
        {
            Console.SetCursorPosition(offsetx, offsety);
            Console.WriteLine(character);
        }
        public void ScreenDisplay()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.Write("+-------+-------+-------+\n");
                Console.WriteLine("|\t|\t|\t|");
                Console.WriteLine("|\t|\t|\t|");
                Console.WriteLine("|\t|\t|\t|");
            }
            Console.Write("+-------+-------+-------+\n");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i, j] != null)
                    {
                        DisplayMoves(4 + (i * 8), 2 + j * 4, table[i, j]);
                    }
                }
            }
            Console.SetCursorPosition(15, 15);
            Console.WriteLine($"Turn: {movecount} circle wins: {circlewins} cross wins: {crosswins}");
        }
        public bool Rowvictory(string character)
        {
            int cv = 0;
            while (cv < 3)
            {
                if (table[0, cv] == character && table[1, cv] == character && table[1, cv] == character)
                {
                    return true;
                }
                cv++;
            }
            return false;
        }
        public bool Colvictory(string character)
        {
            int cv = 0;
            while (cv < 3)
            {
                if (table[cv, 0] == character && table[cv, 1] == character && table[cv, 2] == character)
                {
                    return true;
                }
                cv++;
            }
            return false;
        }
        private void TableClear()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i, j] = null;

                }
            }
        }
        public bool Diagonalvictory(string myChar)
        {
            return (table[0, 0] == myChar && table[1, 1] == myChar && table[2, 2] == myChar) || (table[2, 0] == myChar && table[1, 1] == myChar && table[0, 2] == myChar);
        }
        public bool CheckforVictory()
        {

            if (movecount > 5)
            {
                
                    if (Rowvictory("O") || Colvictory("O") || Diagonalvictory("O"))
                    {
                        Console.WriteLine("Circle won! Press y to play again.");
                        string inpt = Console.ReadLine();
                        if (inpt.ToLower() == "y")
                        {
                            TableClear();
                            movecount = 1;
                        }
                        circlewins++;
                        return true;
                    }
                    if (Rowvictory("X") || Colvictory("X") || Diagonalvictory("X"))
                    {
                        Console.WriteLine("Cross won! Press y to play again. ");
                        string inpt = Console.ReadLine();
                        if (inpt.ToLower() == "y")
                        {
                            TableClear();
                            movecount = 1;
                        }
                        crosswins++;
                        return true;
                    }
                
            }
            return false;
        }
    }
}
