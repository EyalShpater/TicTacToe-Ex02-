using System;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board m_Board;
        private readonly Player m_Player1;
        private readonly Player m_Player2;
        private Player m_CurrentPlayer;

        public Game(int boardSize, bool isTwoPlayerGame)
        {
            m_Board = new Board(boardSize);
            m_Player1 = new Player("X", true);
            m_Player2 = new Player("O", isTwoPlayerGame);

            m_CurrentPlayer = m_Player1;
        }

        public void Start()
        {
            while (!IsGameOver())
            {
                GamePlay();
            }

            Console.WriteLine("Game over!");

            if (IsDraw())
            {
                Console.WriteLine("It's a draw!");
            }
            else
            {
                Console.WriteLine($"{m_CurrentPlayer.Sign} won the game!");
            }
        }

        private void GamePlay()
        {
            int x, y;

            do
            {
                Console.WriteLine($"{m_CurrentPlayer.Sign}'s turn:");
                Console.Write("Enter x coordinate: ");
                x = ConsoleIO.ReadInt();
                Console.Write("Enter y coordinate: ");
                y = ConsoleIO.ReadInt();

                if (!m_Board.IsEmpty(x, y))
                {
                    Console.WriteLine("That cell is already occupied! Try again.");
                }
            } while (!m_Board.IsEmpty(x, y));

            m_Board.Mark(x, y, m_CurrentPlayer.Sign);

            ConsoleIO.ClearScreen();
            ConsoleIO.PrintBoard(m_Board);

            if (IsGameOver())
            {
                return;
            }

            if (!m_CurrentPlayer.IsHuman)
            {
                Random rand = new Random();
                x = rand.Next(m_Board.Size);
                y = rand.Next(m_Board.Size);

                while (!m_Board.IsEmpty(x, y))
                {
                    x = rand.Next(m_Board.Size);
                    y = rand.Next(m_Board.Size);
                }

                Console.WriteLine($"{m_CurrentPlayer.Sign}'s turn:");
                Console.WriteLine($"Computer plays ({x}, {y})");

                m_Board.Mark(x, y, m_CurrentPlayer.Sign);

                ConsoleIO.ClearScreen();
                ConsoleIO.PrintBoard(m_Board);
            }

            m_CurrentPlayer = m_CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
        }

        private bool IsGameOver()
        {
            return m_Board.IsFull() || m_Board.HasWinner();
        }

        private bool IsDraw()
        {
            return m_Board.IsFull() && !m_Board.HasWinner();
        }
    }
}
