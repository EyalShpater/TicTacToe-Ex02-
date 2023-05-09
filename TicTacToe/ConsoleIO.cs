using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class ConsoleIO
    {
        private Game m_Game;

        public ConsoleIO ()
        {
            m_Game = null;
        }

        public enum ePlayerSign { Player1 = 'X',Player2 = 'O'};
        public void ClearScreen()
        {
            Console.Clear();
        }

        public void PrintBoard()
        {
            Console.Write(" ");
            for (int i = 0; i< m_Game.BoardSize;i++)
            {
                Console.Write(i + 1+" ");
            }
            Console.WriteLine();

            for (int i = 0; i < m_Game.BoardSize; i++)
            {
                Console.Write(i+1);
                for (int j = 0; j < m_Game.BoardSize; j++)
                {
                    Board.eSquareValue eSign = m_Game.GetSignByCoordinates(i, j);
                    char chSign = convertESquareValueToChar(eSign);
                    Console.Write(chSign);
                }
            }


        }

        private char convertESquareValueToChar(Board.eSquareValue eSign)
        {
            char res = ' ';

            switch (eSign)
            {
                case Board.eSquareValue.Player1:
                    res = 'X';
                    break;
                case Board.eSquareValue.Player2:
                    res = 'O';
                    break;
            }

            return res;
        }


        public void GetDataForGameSetup()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.Write("Enter board size: ");
            int boardSize = ReadInt();
            Console.Write("Enter 1 for one-player game or 2 for two-player game: ");
            bool isTwoPlayerGame = ReadInt() == 2;

            m_Game = new Game(boardSize, isTwoPlayerGame);
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

        public void StartGame()
        {
            GetDataForGameSetup();
            while (!m_Game.IsGameOver())
            {
                PrintBoard();
                if (m_Game.IsComputerTurn())
                { 
                   m_Game.PlayAsComputer();
                }
                else
                {
                    playAsPlayer();
                }
                ClearScreen();
            }

            GameOver();
        }

        private void playAsPlayer()
        {

            getCoordinate(out int x, out int y,m_Game.BoardSize);
            bool isTurnCompleted = m_Game.MarkSquare(x, y);
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
            x = ReadInt();            
            Console.Write("Enter y coordinate: ");
            y = ReadInt();
            while (!isValidCoordinate(x,y,i_BoardSize))
            {
                Console.WriteLine("Invalid x,y coordinates");
                Console.Write("Enter x coordinate: ");
                x = ReadInt();
                Console.Write("Enter y coordinate: ");
                y = ReadInt();
            }
        }

        private bool isValidCoordinate(int i_X,int i_Y,int i_BoardSize)
        {

            return !(i_X < 0 || i_X >= i_BoardSize || i_Y < 0 || i_Y >= i_BoardSize);
        }

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
