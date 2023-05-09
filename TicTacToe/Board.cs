using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public readonly string[,] m_Sign; //enum
        public readonly int Size; //delete

        public Board(int size)
        {
            Size = size;
            m_Sign = new string[size, size];
        }

        public void Mark(int x, int y, string sign) //
        {
            m_Sign[x, y] = sign;
        }

        public bool IsEmpty(int x, int y)
        {
            return m_Sign[x, y] == null;
        }

        public bool IsFull()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (IsEmpty(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool HasWinner()
        {
            for (int i = 0; i < Size; i++)
            {
                if (CheckRow(i) || CheckColumn(i))
                {
                    return true;
                }
            }

            return CheckDiagonal() || CheckAntiDiagonal();
        }

        private bool CheckRow(int row)
        {
            string sign = m_Sign[row, 0];
            for (int i = 1; i < Size; i++)
            {
                if (m_Sign[row, i] != sign)
                {
                    return false;
                }
            }
            return sign != null;
        }

        private bool CheckColumn(int i_Col)
        {
            string sign = m_Sign[0, i_Col];
            for (int i = 1; i < Size; i++)
            {
                if (m_Sign[i, i_Col] != sign)
                {
                    return false;
                }
            }
            return sign != null;
        }

        private bool CheckDiagonal()
        {
            string sign = m_Sign[0, 0];
            for (int i = 1; i < Size; i++)
            {
                if (m_Sign[i, i] != sign)
                {
                    return false;
                }
            }
            return sign != null;
        }

        private bool CheckAntiDiagonal()
        {
            string sign = m_Sign[0, Size - 1];
            for (int i = 1; i < Size; i++)
            {
                if (m_Sign[i, Size - i - 1] != sign)
                {
                    return false;
                }
            }
            return sign != null;
        }

    }

}