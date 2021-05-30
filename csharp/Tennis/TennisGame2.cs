using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private Players players;
        // delegates for different cases
        private Predicate<Players> isEqualsWithLessThan3Points = delegate (Players players) { return players.HasSamePoints() && !players.BothHasAtLeast3Points(); };
        private Predicate<Players> isEqualsWithAtLeast3Points = delegate (Players players) { return players.HasSamePoints() && players.BothHasAtLeast3Points(); };
        private Predicate<Players> isPlayer1InAdvantage = delegate (Players players) { return players.Player1HasMorePoints() && players.BothHasAtLeast3Points(); };
        private Predicate<Players> isPlayer2InAdvantage = delegate (Players players) { return players.Player2HasMorePoints() && players.BothHasAtLeast3Points(); };
        private Predicate<Players> isPLayer1Winner = delegate (Players players) { return players.Player1.HasAtLeast4Points() && players.Player1.HasAtLeast2PointsMoreThan(players.Player2); };
        private Predicate<Players> isPLayer2Winner = delegate (Players players) { return players.Player2.HasAtLeast4Points() && players.Player2.HasAtLeast2PointsMoreThan(players.Player1); };

        public TennisGame2(string player1Name, string player2Name)
        {
            var player1 = new Player(player1Name);
            var player2 = new Player(player2Name);
            players = new Players(player1, player2);
        }

        public string GetScore()
        {
            if (isPLayer1Winner(players)) return TennisConstant.WIN_FOR_PLAYER1;
            if (isPLayer2Winner(players)) return TennisConstant.WIN_FOR_PLAYER2;
            if (isEqualsWithAtLeast3Points(players)) return TennisConstant.DEUCE; 
            if (isEqualsWithLessThan3Points(players)) return players.Player1.GetTennisScore() + TennisConstant.ALL;
            if (isPlayer1InAdvantage(players)) return TennisConstant.ADVANTAGE_PLAYER_1;
            if (isPlayer2InAdvantage(players)) return TennisConstant.ADVANTAGE_PLAYER_2;
            return players.Player1.GetTennisScore() + TennisConstant.TO + players.Player2.GetTennisScore();
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                players.Player1Score();
            else
                players.Player2Score();
        }
    }
}

