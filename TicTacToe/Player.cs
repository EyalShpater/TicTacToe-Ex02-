using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        private readonly string m_Sign; // id
        private readonly bool m_IsHuman;

        public Player(string i_Sign, bool i_IsHuman)
        {
            m_Sign = i_Sign;
            m_IsHuman = i_IsHuman;
        }
        
        public string Sign
        {
            get { return m_Sign; }
        }

        public bool IsHuman
        {
            get { return m_IsHuman; }
        }
    }
}
