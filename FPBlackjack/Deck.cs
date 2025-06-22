using System;
using System.Collections.Generic;
using System.Linq;

namespace FPBlackjack
{
    public class Deck
    {
        private List<Card> cards;
        private static readonly string[] Suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
        private static readonly string[] Ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        public Deck()
        {
            cards = new List<Card>();

            foreach (string suit in Suits)
            {
                foreach (string rank in Ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            cards = cards.OrderBy(c => rng.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (cards.Count == 0) return null;
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public List<Card> PeekAllCards()
        {
            return new List<Card>(cards);
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }
    }
}
