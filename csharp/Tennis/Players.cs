using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    class Players
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Players(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public bool BothHasAtLeast3Points()
        {
            return Player1.HasAtLeast3Points() && Player2.HasAtLeast3Points();
        }

        public bool HasSamePoints()
        {
            return Player1.Point == Player2.Point;
        }

        public bool Player1HasMorePoints()
        {
            return Player1.Point > Player2.Point;
        }

        public bool Player2HasMorePoints()
        {
            return Player1.Point < Player2.Point;
        }

        public void Player1Score()
        {
            Player1.Score();
        }

        public void Player2Score()
        {
            Player2.Score();
        }
    }
}
