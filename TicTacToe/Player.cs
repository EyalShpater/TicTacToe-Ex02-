using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        private readonly string m_sign;
        private readonly bool m_isHuman;
        public Player(string i_sign, bool i_isHuman)
        {
            m_sign = i_sign;
            m_isHuman = i_isHuman;
        }
        
        public string Sign
        {
            get { return m_sign; }
        }

        public bool IsHuman
        {
            get { return m_isHuman; }
        }
    }
}
