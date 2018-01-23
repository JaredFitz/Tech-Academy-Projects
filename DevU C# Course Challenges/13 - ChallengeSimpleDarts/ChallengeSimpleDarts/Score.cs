using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Score
    {

        public static void ScoreDart(Player player, Dart dart)
        {
            player.Score += dart.Score * dart.Multiplier;
        }

    }
}