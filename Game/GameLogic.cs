using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameLogic
    {
        public string CurrentPlayer { get; set; } = "X";
        private const string x = "X";
        private const string o = "O";
        private string[,] Board = new string[3, 3];

        public void SetNextPlayer()
        {
            if(CurrentPlayer == x)
            {
                CurrentPlayer = o;
            }
            else
            {
                CurrentPlayer = x;
            }
        }

        public bool PlayerWin()
        {
            // Check rows
            for (var i = 0; i < 3; i++)
            {
                if (!String.IsNullOrEmpty(Board[i, 0]))
                {
                    if (Board[i, 0] == Board[i, 1] && Board[i, 0] == Board[i, 2])
                    {
                        return true;
                    }
                }
            }

            // Check Columns
            for (var i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(Board[0, i]))
                {
                    if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
                    {
                        return true;
                    }
                }
            }

            // Check diagonal
            if (!string.IsNullOrEmpty(Board[1, 1]))
            {
                if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
                {
                    return true;
                }

                if (Board[0, 2] == Board[1, 1] && Board[0, 2] == Board[2, 0])
                {
                    return true;
                }
            }
            return false;
        }


        public bool BoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(Board[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;

        }


            public void UpdateBoard(Position position, string value)
        {
            Board[position.x, position.y] = value;
        }

    }
}
