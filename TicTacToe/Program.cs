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
            Console.WriteLine("Welcome to Tic Tac Toe!");

            ConsoleIO.PromptForGameSetup(out int boardSize, out bool isTwoPlayerGame);

            // Create a new TicTacToe game and start it
            Game game = new Game(boardSize, isTwoPlayerGame);
            game.Start();
        }

    }
}
