using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    class Player
    {
        public string Name { get; set; }
        public int Point { get; set; }

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

        public string GetTennisScore()
        {
            var tennisScore = "";
            switch (Point) {
                case 0: 
                    tennisScore = TennisConstant.ZERO_POINT;
                    break;
                case 1:
                    tennisScore = TennisConstant.ONE_POINT;
                    break;
                case 2:
                    tennisScore = TennisConstant.TWO_POINTS;
                    break;
                case 3:
                    tennisScore = TennisConstant.THREE_POINTS;
                    break;
            }
            return tennisScore;
        }
    }
}
