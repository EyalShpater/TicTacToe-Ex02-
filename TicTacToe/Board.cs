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
            r_Board = new eSquareValue[i_Size, i_Size];
        }

        public int Size
        {
            get
            {
                return m_Board.Length;
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
            return r_Board[i_X, i_Y] == eSquareValue.Empty;
        }

        public bool IsFull()
        {
            bool result = true;

            for (int x = 0; x < r_Board.Length; x++)
            {
                for (int y = 0; y < r_Board.Length; y++)
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
            for (int i = 0; i < r_Board.Length; i++)
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
            eSquareValue sign = r_Board[row, 0];
            for (int i = 1; i < r_Board.Length; i++)
            {
                if (r_Board[row, i] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

        private bool CheckSequanceInColumn(int i_Col)
        {
            eSquareValue sign = r_Board[0, i_Col];
            for (int i = 1; i < r_Board.Length; i++)
            {
                if (r_Board[i, i_Col] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

        private bool CheckSequanceInDiagonal()
        {
            eSquareValue sign = r_Board[0, 0];
            for (int i = 1; i < r_Board.Length; i++)
            {
                if (r_Board[i, i] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

        private bool CheckAntiDiagonal()
        {
            eSquareValue sign = r_Board[0, r_Board.Length - 1];
            for (int i = 1; i < r_Board.Length; i++)
            {
                if (r_Board[i, r_Board.Length - i - 1] != sign)
                {
                    return false;
                }
            }
            return sign != eSquareValue.Empty;
        }

    }

}