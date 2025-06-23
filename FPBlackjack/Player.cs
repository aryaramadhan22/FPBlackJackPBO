using System.Collections.Generic;

namespace FPBlackjack
{
    public abstract class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
    }

    public class HumanPlayer : Player { }

    public class OpponentPlayer : Player
    {
        public void PlayTurn(Deck deck)
        {
            while (CalculateScore(Hand) < 17)
            {
                Card card = deck.DrawCard();
                if (card == null) break;
                Hand.Add(card);

                int score = CalculateScore(Hand);
                if (score >= 21)
                    break;
            }
        }

        private int CalculateScore(List<Card> hand)
        {
            int total = 0;
            int aces = 0;

            foreach (var card in hand)
            {
                if (card == null) continue;
                total += card.Value;
                if (card.Value == 11) aces++;
            }

            while (total > 21 && aces > 0)
            {
                total -= 10;
                aces--;
            }

            return total;
        }
    }


}
