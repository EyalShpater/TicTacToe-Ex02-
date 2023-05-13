using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public enum ePlayerId 
        { 
            Player1 = 1, Player2, Computer 
        }

        private readonly ePlayerId r_Id;
        private int m_Score;

        internal Player(ePlayerId i_Id)
        {
            r_Id = i_Id;
            m_Score = 0;
        }

        public ePlayerId Id 
        {
            get { return r_Id; }
        }

        public int Score
        { 
            get 
            { 
                return m_Score; 
            }

            set 
            { 
                m_Score = value; 
            }
        }
    }
}
