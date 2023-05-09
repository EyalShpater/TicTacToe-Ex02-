using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    internal class Program
    {
        public static void Main()
        {
            ConsoleIO.GetDataForGameSetup(out int boardSize, out bool isTwoPlayerGame);

            // Create a new TicTacToe game and start it
            Game game = new Game(boardSize, isTwoPlayerGame);
            game.Start();
        }

    }
}
