using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class ConsoleIO
    {
        private const char player1Sign = 'X';
        private const char player2Sign = 'O';
        private const char emptySquare = ' ';

        private Game m_Game;

        public ConsoleIO ()
        {
            m_Game = null;
        }

        private void clearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }

        private void printBoard()
        {
            printLineOfNumbers();

            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                printRowOfBoard(i);
                printLineBuffer();
                Console.WriteLine(); // add a newline character after each row
            }
        }

        private void printLineOfNumbers()
        {
            Console.Write(" ");
            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                Console.Write("  " + (i + 1) + " ");
            }

            Console.WriteLine();
        }

        private void printLineBuffer()
        {
            Console.Write(" ");
            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                Console.Write("====");
            }

            Console.WriteLine("=");
        }

        private void printRowOfBoard(int i_RowIndex)
        {
            Console.Write(i_RowIndex + 1 + "|");
            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                Board.eSquareValue eSign = m_Game.GetSignByCoordinates(i_RowIndex, i);
                char chSign = convertESquareValueToChar(eSign);

                Console.Write(" " + chSign + " |");
            }

            Console.WriteLine();
        }

        private char convertESquareValueToChar(Board.eSquareValue eSign)
        {
            char res = emptySquare;

            switch (eSign)
            {
                case Board.eSquareValue.Player1:
                    res = player1Sign;
                    break;
                case Board.eSquareValue.Player2:
                    res = player2Sign;
                    break;
            }

            return res;
        }

        private void getDataForGameSetupAndInitGame()
        {
            int boardSize;
            bool isTwoPlayerGame;

            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.Write("Enter board size: ");
            boardSize = readInt();
            Console.Write("Enter 1 for one-player game or 2 for two-player game: ");
            isTwoPlayerGame = readInt() == 2;

            m_Game = new Game(boardSize, isTwoPlayerGame);
        }

        private static int readInt()
        {
            int result;

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input! Try again.");
            }

            return result;
        }

        public void StartGame()
        {
            getDataForGameSetupAndInitGame();
            while (!m_Game.IsGameOver())
            {
                clearScreen();
                printBoard();
                if (m_Game.IsComputerTurn())
                { 
                   m_Game.PlayAsComputer();
                }
                else
                {
                    playAsPlayer();
                }

                //need to check win
            }

            GameOver();
        }

        private void playAsPlayer()
        {
            int x, y;
            bool isTurnCompleted;

            getCoordinate(out x, out y, m_Game.BoardSize);
            isTurnCompleted = m_Game.MarkSquare(x, y);
            while(!isTurnCompleted)
            {
                Console.WriteLine("Couldn't mark the selected square"); 
                getCoordinate(out x,out y, m_Game.BoardSize);
                isTurnCompleted = m_Game.MarkSquare(x, y);
            }
        }

        private void getCoordinate(out int x, out int y,int i_BoardSize)
        {
            Console.WriteLine("s turn:");
            Console.Write("Enter x coordinate: ");
            x = readInt();            
            Console.Write("Enter y coordinate: ");
            y = readInt();
            //while (!isValidCoordinate(x,y,i_BoardSize))
            //{
            //    Console.WriteLine("Invalid x,y coordinates");
            //    Console.Write("Enter x coordinate: ");
            //    x = readInt();
            //    Console.Write("Enter y coordinate: ");
            //    y = readInt();
            //}
        }

        //private bool isValidCoordinate(int i_X,int i_Y,int i_BoardSize) // can be deleted, game checks that
        //{

        //    return !(i_X < 0 || i_X >= i_BoardSize || i_Y < 0 || i_Y >= i_BoardSize);
        //}

        public void GameOver()
        {
            Console.WriteLine("Game Over!");

            if (m_Game.IsDraw())
            {
                Console.WriteLine("It's a draw!");
            }
            else
            {
                Console.WriteLine($"{m_Game.Winner.Id} won the game!");
            }
        }
    }
    

}
