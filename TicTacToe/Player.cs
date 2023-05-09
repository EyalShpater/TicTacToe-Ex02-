using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public enum ePlayerId { Player1 = 1, Player2, Computer };

        private readonly ePlayerId m_Id;

        public Player(ePlayerId i_Id)
        {
            m_Id = i_Id;
        }

        public ePlayerId Id
        {
            get { return m_Id; }
        }

    }
}
