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
            bool canMark = isValidSquareToMark(i_X, i_Y);

            if(canMark)
            {
                m_Board[i_X, i_Y] = i_Sign;
            }

            return canMark;
        }

        private bool isEmptySquare(int i_X, int i_Y) 
        {
            return m_Board[i_X, i_Y] == eSquareValue.Empty;
        }

        private bool isValidSquareToMark(int i_X, int i_Y) 
        {
            return isValidCoordinateValue(i_X) && isValidCoordinateValue(i_Y) && isEmptySquare(i_X, i_Y);
        }

        private bool isValidCoordinateValue(int i_Value) 
        {
            return i_Value >= 0 && i_Value < this.Size;
        }

        public bool AreAllSquaresMarked() 
        {
            bool allMarked = true;

            for (int x = 0; x < this.Size && allMarked; x++)
            {
                for (int y = 0; y < this.Size; y++)
                {
                    if (isEmptySquare(x, y))
                    {
                        allMarked = false;
                        break;
                    }
                }
            }

            return allMarked;
        }

        public bool IsSequance(int i_X, int i_Y) // move to game
        {
            return CheckSequanceInDiagonal() || CheckAntiDiagonal() || CheckSequanceInRow(i_X - 1) || CheckSequanceInColumn(i_Y - 1);
        }

        private bool CheckSequanceInRow(int i_Row) // public so the game can use it? 
        {
            eSquareValue sign = m_Board[i_Row, 0];
            bool isAllRowTheSameSign = (sign != eSquareValue.Empty); 

            for (int i = 1; i < this.Size; i++)
            {
                if (m_Board[i_Row, i] != sign)
                {
                    isAllRowTheSameSign = false;
                }
            }

            return isAllRowTheSameSign;
        }

        private bool CheckSequanceInColumn(int i_Col)
        {
            eSquareValue sign = m_Board[0, i_Col];
            bool isAllColumnTheSameSign = (sign != eSquareValue.Empty);

            for (int i = 1; i < this.Size; i++)
            {
                if (m_Board[i, i_Col] != sign)
                {
                    isAllColumnTheSameSign = false;
                }
            }

            return isAllColumnTheSameSign;
        }

        private bool CheckSequanceInDiagonal()
        {
            eSquareValue sign = m_Board[0, 0];
            bool isAllDiagTheSameSign = (sign != eSquareValue.Empty);

            for (int i = 1; i < this.Size; i++)
            {
                if (m_Board[i, i] != sign)
                {
                    isAllDiagTheSameSign = false;
                }
            }

            return isAllDiagTheSameSign;
        }

        private bool CheckAntiDiagonal()
        {
            eSquareValue sign = m_Board[0, m_Board.Length - 1];
            bool isAllDiagTheSameSign = (sign != eSquareValue.Empty);

            for (int i = 1; i < this.Size; i++)
            {
                if (m_Board[i, this.Size - i - 1] != sign)
                {
                    isAllDiagTheSameSign = false;
                }
            }

            return isAllDiagTheSameSign;
        }
    }
}