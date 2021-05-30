using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private Player player1;
        private Player player2;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            // if someone wins
            var isPLayer1Winner = player1.HasAtLeast4Points() && player1.HasAtLeast2PointsMoreThan(player2);
            if (isPLayer1Winner) return TennisConstant.WIN_FOR_PLAYER1;
            var isPLayer2Winner = player2.HasAtLeast4Points() && player2.HasAtLeast2PointsMoreThan(player1);
            if (isPLayer2Winner) return TennisConstant.WIN_FOR_PLAYER2;

            // if nobody wins
            var pointDifference = GetPointDifferenceOfTwoPlayers();
            var bothHasAtLeast3Points = player1.HasAtLeast3Points() && player2.HasAtLeast3Points();
            return GetScoreWhenNobodyWins(pointDifference, bothHasAtLeast3Points);
        }



        // Get the point difference of the two players 
        public PointDifference GetPointDifferenceOfTwoPlayers()
        {
            var pointOfPlayer1 = player1.Point;
            var pointOfPlayer2 = player2.Point;
            if (pointOfPlayer1 == pointOfPlayer2) return PointDifference.EQUALS;
            if (pointOfPlayer1 > pointOfPlayer2) return PointDifference.PLAYER1_HAS_MORE_POINTS;
            return PointDifference.PLAYER2_HAS_MORE_POINTS;
        }

        // Get the score result when threre is no winer
        public string GetScoreWhenNobodyWins(PointDifference pointDifference, bool bothHasAtLeast3Points)
        {
            return (pointDifference, bothHasAtLeast3Points) switch
            {
                (PointDifference.EQUALS, false) => player1.GetTennisScore() + TennisConstant.ALL,
                (PointDifference.EQUALS, true) => TennisConstant.DEUCE,
                (PointDifference.PLAYER1_HAS_MORE_POINTS, true) => TennisConstant.ADVANTAGE_PLAYER_1,
                (PointDifference.PLAYER2_HAS_MORE_POINTS, true) => TennisConstant.ADVANTAGE_PLAYER_2,
                _ => player1.GetTennisScore() + TennisConstant.TO + player2.GetTennisScore()
            };
        }


        public void WonPoint(string player)
        {
            if (player == "player1")
                player1.Score();
            else
                player2.Score();
        }

    }
}

