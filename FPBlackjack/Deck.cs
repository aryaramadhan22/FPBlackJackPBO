using System;
using System.Collections.Generic;

namespace FPBlackjack
{
    public class Deck
    {
        private List<Card> cards;
        private Random rng = new Random();

        public Deck()
        {
            Refill();
        }

        public void Refill()
        {
            cards = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            if (cards.Count == 0) return null;
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public bool IsEmpty()
        {
            return cards.Count == 0;
        }
    }
}
