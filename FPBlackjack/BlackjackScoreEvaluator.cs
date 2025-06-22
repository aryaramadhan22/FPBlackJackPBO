using System.Collections.Generic;

namespace FPBlackjack
{
    public class BlackjackScoreEvaluator : IScoreEvaluator
    {
        public int CalculateScore(List<Card> hand)
        {
            int total = 0;
            int aces = 0;

            foreach (var card in hand)
            {
                total += card.Value;

                // Hitung jumlah kartu As (Ace) yang dianggap 11
                if (card.Value == 11)
                    aces++;
            }

            // Jika total lebih dari 21 dan ada As, ubah nilainya jadi 1 (dari 11)
            while (total > 21 && aces > 0)
            {
                total -= 10; // Mengurangi 11 menjadi 1 artinya dikurang 10
                aces--;
            }

            return total;
        }
    }
}
