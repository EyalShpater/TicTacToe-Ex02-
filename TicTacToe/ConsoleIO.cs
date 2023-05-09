using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class ConsoleIO
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void PrintBoard(Board board)
        {
            Console.WriteLine("  " + string.Join(" ", Enumerable.Range(0, board.Size)));
            for (int x = 0; x < board.Size; x++)
            {
                Console.Write(x + " ");
                for (int y = 0; y < board.Size; y++)
                {
                    Console.Write((board.IsEmpty(x, y) ? "." : board.m_Sign[x, y]) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void GetDataForGameSetup(out int boardSize, out bool isTwoPlayerGame)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.Write("Enter board size: ");
            boardSize = ReadInt();
            Console.Write("Enter 1 for one-player game or 2 for two-player game: ");
            isTwoPlayerGame = ReadInt() == 2;
        }

        public static int ReadInt()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input! Try again.");
            }
            return result;
        }
    }
}
