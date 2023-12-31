﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            do
            {
                game.ScreenDisplay();
                game.PlayerMove();
                game.ScreenDisplay();
                game.CheckforVictory();
            } while (!game.GameOver());
            Console.ReadLine();
        }
    }
}
