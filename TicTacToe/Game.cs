using System;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board m_Board;
        private readonly Player m_Player1;
        private readonly Player m_Player2;
        private Player m_CurrentPlayerTurn;
        private Player m_GameWinner;

        public Game(int boardSize, bool isTwoPlayerGame)
        {
            Player.ePlayerId player2Id = isTwoPlayerGame ? Player.ePlayerId.Player2 : Player.ePlayerId.Computer;

            m_Board = new Board(boardSize);
            m_Player1 = new Player(Player.ePlayerId.Player1);
            m_Player2 = new Player(player2Id);
            m_CurrentPlayerTurn = m_Player1;
            m_GameWinner = null;
        }

        public Player Winner
        {
            get
            {
                return m_GameWinner;
            }
            
        }

        public int BoardSize
        {
            get
            {
                return m_Board.Size;
            }
        }

        public Board.eSquareValue GetSignByCoordinates(int i_X, int i_Y)
        {
            return m_Board.GetSquareValue(i_X, i_Y);
        }


        public bool IsComputerTurn()
        {
            return m_CurrentPlayerTurn.Id == Player.ePlayerId.Computer;
        }
        public void Start()
        {
            while (!IsGameOver())
            {
                PlayTurn();
            }

        }

        public bool MarkSquare(int i_X,int i_Y)
        {
            Board.eSquareValue sign = convertEplayerToESquareValue(m_CurrentPlayerTurn);
            return m_Board.MarkSquare(i_X, i_Y,sign);
        }

        private Board.eSquareValue convertEplayerToESquareValue (Player i_Player)
        {
            Board.eSquareValue res;
            if (i_Player.Id==Player.ePlayerId.Player1)
            {
                res = Board.eSquareValue.Player1;
            }
            else
            {
                res = Board.eSquareValue.Player2;
            }
            return res;
        }


        public void PlayAsComputer()
        {
            int x, y;
            Board.eSquareValue sign = Board.eSquareValue.Player2;
            Random rand = new Random();
            x = rand.Next(m_Board.Size);
            y = rand.Next(m_Board.Size);

            while (!m_Board.IsEmpty(x, y))
            {
                x = rand.Next(m_Board.Size);
                y = rand.Next(m_Board.Size);
            }

            m_Board.MarkSquare(x, y, sign);

            ConsoleIO.ClearScreen();
            ConsoleIO.PrintBoard(m_Board);
        }
        public bool IsGameOver()
        {
            return m_Board.IsFull() || m_Board.HasWinner();
        }

        public bool IsDraw()
        {
            return m_Board.IsFull() && !m_Board.HasWinner();
        }
    }
}
