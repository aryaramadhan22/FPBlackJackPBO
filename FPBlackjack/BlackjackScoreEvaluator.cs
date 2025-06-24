using System.Collections.Generic;

namespace FPBlackjack
{
    public class BlackjackScoreEvaluator : IScoreEvaluator
    {
        public int CalculateScore(List<Card> hand)
        {
            int total = 0;
            int aces = 0;

            foreach (Card card in hand)
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
