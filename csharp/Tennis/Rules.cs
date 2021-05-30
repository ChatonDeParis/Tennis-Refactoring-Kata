using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    class Rules
    {
        public static Predicate<Players> isEqualsWithLessThan3Points = delegate (Players players) { return players.HasSamePoints() && !players.BothHasAtLeast3Points(); };
        public static Predicate<Players> isEqualsWithAtLeast3Points = delegate (Players players) { return players.HasSamePoints() && players.BothHasAtLeast3Points(); };
        public static Predicate<Players> isPlayer1InAdvantage = delegate (Players players) { return players.Player1HasMorePoints() && players.BothHasAtLeast3Points(); };
        public static Predicate<Players> isPlayer2InAdvantage = delegate (Players players) { return players.Player2HasMorePoints() && players.BothHasAtLeast3Points(); };
        public static Predicate<Players> isPLayer1Winner = delegate (Players players) { return players.Player1.HasAtLeast4Points() && players.Player1.HasAtLeast2PointsMoreThan(players.Player2); };
        public static Predicate<Players> isPLayer2Winner = delegate (Players players) { return players.Player2.HasAtLeast4Points() && players.Player2.HasAtLeast2PointsMoreThan(players.Player1); };
    }
}
