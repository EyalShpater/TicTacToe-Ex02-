using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{

    public class Board
    {
        public enum eSquareValue { Empty, Player1, Player2 };
        
        private eSquareValue[,] m_Board; 

        public Board(int i_Size)
        {
            m_Board = new eSquareValue[i_Size, i_Size];
        }

        public int Size
        {
            get
            {
                return m_Board.GetLength(0);
            }
        }

        public eSquareValue GetSquareValue(int i_X, int i_Y)
        {
            return m_Board[i_X, i_Y];
        }

        public bool MarkSquare(int i_X, int i_Y, eSquareValue i_Sign)
        {
            bool res = false;
            if(IsEmpty(i_X,i_Y))
            {
                m_Board[i_X, i_Y] = i_Sign;
                res = true;
            }
            return res;
        }

        public bool IsEmpty(int i_X, int i_Y)
        {
            return m_Board[i_X, i_Y] == eSquareValue.Empty;
        }

        public bool IsFull()
        {
            bool result = true;

            for (int x = 0; x < m_Board.GetLength(0); x++)
            {
                for (int y = 0; y < m_Board.GetLength(0); y++)
                {
                    if (IsEmpty(x, y))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        public bool HasWinner() // move to game
        {
            for (int i = 0; i < m_Board.GetLength(0); i++)
            {
                if (CheckSequanceInRow(i) || CheckSequanceInColumn(i))
                {
                    return true;
                }
            }

            return CheckSequanceInDiagonal() || CheckAntiDiagonal();
        }

        private bool CheckSequanceInRow(int row)
        {
            eSquareValue sign = m_Board[row, 0];
            for (int i = 1; i < m_Board.GetLength(0); i++)
            {
                if (m_Board[row, i] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

        private bool CheckSequanceInColumn(int i_Col)
        {
            eSquareValue sign = m_Board[0, i_Col];
            for (int i = 1; i < m_Board.GetLength(0); i++)
            {
                if (m_Board[i, i_Col] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

        private bool CheckSequanceInDiagonal()
        {
            eSquareValue sign = m_Board[0, 0];
            for (int i = 1; i < m_Board.GetLength(0); i++)
            {
                if (m_Board[i, i] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

        private bool CheckAntiDiagonal()
        {
            eSquareValue sign = m_Board[0, m_Board.GetLength(0) - 1];
            for (int i = 1; i < m_Board.GetLength(0); i++)
            {
                if (m_Board[i, m_Board.GetLength(0) - i - 1] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

    }

}