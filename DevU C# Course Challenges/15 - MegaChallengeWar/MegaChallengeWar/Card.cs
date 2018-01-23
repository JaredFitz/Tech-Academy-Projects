using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChallengeWar
{
    public class Card
    {
        public string Name { get; set; }
        public int Value { get; set; }
        
        public string DoBattle(Player player1, Player player2)
        {
            string roundSummary = "";           
            Card player1BattleCard = player1.PlayerCards.ElementAt(0);
            Card player2BattleCard = player2.PlayerCards.ElementAt(0);
            player1.PlayerCards.Remove(player1BattleCard);
            player2.PlayerCards.Remove(player2BattleCard);

            List<Card> bountyList = new List<Card>() { player1BattleCard, player2BattleCard };

            roundSummary += BattleDialogue(player1BattleCard, player2BattleCard);

            roundSummary += EvaluateWinner(player1BattleCard, player2BattleCard, player1, player2, bountyList);

            return roundSummary;
        }

        private string EvaluateWinner(Card player1BattleCard, Card player2BattleCard, Player player1, Player player2, List<Card> bountyList)
        {
            string roundSummary = "";
            if (player1BattleCard.Value > player2BattleCard.Value)
            {
                roundSummary += "Bounty ..." + Environment.NewLine;
                roundSummary += BountyDialogue(bountyList);
                roundSummary += PlayerWinDialogue(player1, player2, bountyList);
            }
            else if (player2BattleCard.Value > player1BattleCard.Value)
            {
                roundSummary += "Bounty ..." + Environment.NewLine;
                roundSummary += BountyDialogue(bountyList);
                roundSummary += PlayerWinDialogue(player2, player1, bountyList);
            }
            else
            {
                roundSummary += "***************War***************" + Environment.NewLine + Environment.NewLine;
                roundSummary += War(player1, player2, bountyList);
            }

            return roundSummary;
        }

        private string BattleDialogue(Card player1BattleCard, Card player2BattleCard)
        {
            return String.Format("Battle Cards: {0} versus {1}{2}",
                player1BattleCard.Name,
                player2BattleCard.Name,
                Environment.NewLine);
        }

        private string BountyDialogue(List<Card> bountyList)
        {
            string bountySummary = "";
            foreach (var card in bountyList)
            {
                bountySummary += "    " + card.Name + Environment.NewLine;
            }

            return bountySummary;
        }

        private string PlayerWinDialogue(Player winningPlayer, Player losingPlayer, List<Card> bountyList)
        {
            winningPlayer.Score += bountyList.Count;
            return String.Format("{0} wins!{1}{1}", winningPlayer.Name, Environment.NewLine);
        }

        public string War(Player player1, Player player2, List<Card> bountyList)
        {
            int warCards = 0;
            string evaluateWar = "";

            if (player1.PlayerCards.Count == 0) { return "There were no cards to war with"; }
            if (player1.PlayerCards.Count >= 4) { warCards = 4; }
            else { warCards = player1.PlayerCards.Count; }

            Card player1BattleCard = player1.PlayerCards.ElementAt(warCards - 1);
            Card player2BattleCard = player2.PlayerCards.ElementAt(warCards - 1);

            for (int i = 0; i < warCards; i++)
            {
                bountyList.Add(player1.PlayerCards.ElementAt(0));
                bountyList.Add(player2.PlayerCards.ElementAt(0));
                player1.PlayerCards.RemoveAt(0);
                player2.PlayerCards.RemoveAt(0);
            }

            evaluateWar += BattleDialogue(player1BattleCard, player2BattleCard);
            evaluateWar += EvaluateWinner(player1BattleCard, player2BattleCard, player1, player2, bountyList);

            return evaluateWar;
        }
    }
}
