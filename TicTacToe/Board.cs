using System;

namespace TicTacToe
{
    public class Board
    {
        public enum eSquareValue
        { 
            Empty, 
            Player1, 
            Player2 
        }
        
        private eSquareValue[,] m_Board; 

        internal Board(int i_Size)
        {
            m_Board = new eSquareValue[i_Size, i_Size];
            ClearBoard();
        }

        internal int Size
        {
            get
            {
                return m_Board.GetLength(0);
            }
        }

        internal eSquareValue GetSquareValue(int i_X, int i_Y)
        {
            return m_Board[i_X, i_Y];
        }

        internal bool MarkSquare(int i_X, int i_Y, eSquareValue i_Sign)
        {
            bool canMark = isValidSquareToMark(i_X, i_Y);

            if(canMark)
            {
                m_Board[i_X, i_Y] = i_Sign;
            }

            return canMark;
        }

        internal void ClearBoard()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for(int j = 0; j < this.Size; j++)
                {
                    m_Board[i, j] = eSquareValue.Empty;
                }
            }
        }

        internal bool AreAllSquaresMarked()
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
    }
}