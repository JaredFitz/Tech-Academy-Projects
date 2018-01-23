using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private Random _random;

        public Game (string player1Name, string player2Name)
        {
            _player1 = new Player();
            _player2 = new Player();

            _player1.Name = player1Name;
            _player2.Name = player2Name;

            _random = new Random();
        }

        public string PlayGame()
        {
            string summaryOfRound = "";
            int round = 1;
            while (_player1.Score < 300 && _player2.Score < 300)
            {
                summaryOfRound += String.Format("Round {0}:<br/>", round);
                summaryOfRound += dartRound(_player1, summaryOfRound);
                summaryOfRound += dartRound(_player2, summaryOfRound);
                round++;
            }

            return displayResults(summaryOfRound);
        }

        private string displayResults(string summaryOfRound)
        {
            string summary = summaryOfRound;
            string result = String.Format("{0}: {1}<br/>{2}: {3}<br/><br/>", _player1.Name, _player1.Score, _player2.Name, _player2.Score);

            return result += "Winner: " + 
                (_player1.Score > _player2.Score ? _player1.Name : (_player2.Score > _player1.Score ? _player2.Name : "It's a Tie!")) + 
                summary;
        }

        private string dartRound(Player player, string summaryOfRound)
        {
            string summary = summaryOfRound;
            for (int i = 0; i < 3; i++)
            {
                Dart dart = new Dart(_random);
                dart.Throw();
                Score.ScoreDart(player, dart);
                if (i == 0) summary += String.Format("{0}: {1}x{2}", player.Name, dart.Multiplier, dart.Score);
                else summary += String.Format("   {0}x{1}",dart.Multiplier, dart.Score);
            }
            summary += " - Total: " + player.Score.ToString() + "<br/>";

            return summary;
        }
    }
}