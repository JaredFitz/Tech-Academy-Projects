using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChallengeWar
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private Random _random;

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name, Score = 0, PlayerCards = new List<Card>() };
            _player2 = new Player() { Name = player2Name, Score = 0, PlayerCards = new List<Card>() };
            _random = new Random();
        }

        public void PlayGame(out string roundsSummary, out Player player1, out Player player2)
        {
            var Deck = new List<Card>();
            roundsSummary = "";

            DealCards(CreateDeck(Deck), _player1, _player2);

            string displayDeal = DisplayDeal(_player1, _player2); 
            
            while (_player1.PlayerCards.Count > 0)
            {
                roundsSummary += _player1.PlayerCards.ElementAt(0).DoBattle(_player1, _player2);
            }

            roundsSummary = displayDeal + Environment.NewLine + Environment.NewLine + roundsSummary;
            player1 = _player1;
            player2 = _player2;

        }

        private string DisplayDeal(Player player1, Player player2)
        {
            string dealingResult = "";
            for (int i = 0; i < 26; i++)
            {
                dealingResult += String.Format("{0} is dealt the {1}{2}{3} is dealt the {4}{2}",
                    player1.Name,
                    player1.PlayerCards.ElementAt(i).Name,
                    Environment.NewLine,
                    player2.Name,
                    player2.PlayerCards.ElementAt(i).Name);
            }
            return dealingResult;
        }

        private List<Card> CreateDeck(List<Card> deck)
        {
            string nameOfCard;

            for (int i = 2; i < 15; i++)
            {
                switch (i)
                {
                    case 11:
                        nameOfCard = "Jack";
                        break;
                    case 12:
                        nameOfCard = "Queen";
                        break;
                    case 13:
                        nameOfCard = "King";
                        break;
                    case 14:
                        nameOfCard = "Ace";
                        break;
                    default:
                        nameOfCard = i.ToString();
                        break;
                }

                deck.Add(new Card { Value = i, Name = nameOfCard + " of Spades" });
                deck.Add(new Card { Value = i, Name = nameOfCard + " of Clubs" });
                deck.Add(new Card { Value = i, Name = nameOfCard + " of Hearts" });
                deck.Add(new Card { Value = i, Name = nameOfCard + " of Diamonds" });
            }

            return deck;
        }

        private void DealCards(List<Card> Deck, Player player1, Player player2)
        {

            int player1NewCard, player2NewCard;

            while (Deck.Count > 0) // Dealing cards
            {
                player1NewCard = _random.Next(0, Deck.Count - 1);
                player1.PlayerCards.Add(Deck.ElementAt(player1NewCard));
                Deck.RemoveAt(player1NewCard);

                player2NewCard = _random.Next(0, Deck.Count - 1);
                player2.PlayerCards.Add(Deck.ElementAt(player2NewCard));
                Deck.RemoveAt(player2NewCard);
            }
        }

    }
}
