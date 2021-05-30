using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    class Player
    {
        public string Name { get; set; }
        public int Point { get; set; }

        private static readonly IDictionary<int, string> tennisScoreDictionary = new Dictionary<int, string>
        {
            [0] = TennisConstant.ZERO_POINT,
            [1] = TennisConstant.ONE_POINT,
            [2] = TennisConstant.TWO_POINTS,
            [3] = TennisConstant.THREE_POINTS
        };

        public Player(string name)
        {
            Name = name;
        }

        public void Score()
        {
            Point++;
        }

        public bool HasAtLeast3Points()
        {
            return Point > 2;
        }

        public bool HasAtLeast4Points()
        {
            return Point > 3;
        }

        public bool HasAtLeast2PointsMoreThan(Player concurrent)
        {
            return Point - concurrent.Point > 1;
        }

        public string GetTennisScore()
        {
            return tennisScoreDictionary.ContainsKey(Point) ? tennisScoreDictionary[Point] : TennisConstant.UNKNOWN_POINTS;
        }
    }
}
