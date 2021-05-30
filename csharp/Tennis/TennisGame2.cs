using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private Players players;
       
        public TennisGame2(string player1Name, string player2Name)
        {
            var player1 = new Player(player1Name);
            var player2 = new Player(player2Name);
            players = new Players(player1, player2);
        }

        public string GetScore()
        {
            if (Rules.isPLayer1Winner(players)) return TennisConstant.WIN_FOR_PLAYER1;
            if (Rules.isPLayer2Winner(players)) return TennisConstant.WIN_FOR_PLAYER2;
            if (Rules.isEqualsWithAtLeast3Points(players)) return TennisConstant.DEUCE; 
            if (Rules.isEqualsWithLessThan3Points(players)) return players.Player1.GetTennisScore() + TennisConstant.ALL;
            if (Rules.isPlayer1InAdvantage(players)) return TennisConstant.ADVANTAGE_PLAYER_1;
            if (Rules.isPlayer2InAdvantage(players)) return TennisConstant.ADVANTAGE_PLAYER_2;
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

