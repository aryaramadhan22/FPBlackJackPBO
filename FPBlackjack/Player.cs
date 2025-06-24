using System.Collections.Generic;

namespace FPBlackjack
{
    public abstract class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
    }

    public class HumanPlayer : Player
    {

    }

    public class OpponentPlayer : Player
    {
        private Random rng = new Random();

        public void PlayTurn(Deck deck, int playerScore)
        {
            while (true)
            {
                int opponentScore = CalculateScore(Hand);

                // Player bust? Stand
                if (playerScore > 21) break;
                // Sudah 21 atau bust? Stand
                if (opponentScore >= 21) break;
                // Jika score 19 atau lebih, selalu stand! (Tidak pernah hit lagi)
                if (opponentScore >= 19) break;

                // Jika sudah menang/draw cukup dengan stand (defensive)
                if (opponentScore >= 17 && opponentScore >= playerScore && playerScore <= 21)
                {
                    break;
                }

                // Jika 17/18, dan player stand lebih tinggi, ada sedikit chance hit (AI berani dikit)
                if (opponentScore >= 17 && opponentScore < 19 && opponentScore < playerScore && playerScore <= 21)
                {
                    // 15% chance nekat hit
                    if (rng.Next(100) < 15)
                    {
                        Card card = deck.DrawCard();
                        if (card == null) break;
                        Hand.Add(card);
                        continue;
                    }
                    // Default: stand saja
                    break;
                }

                // Kalau <17, selalu hit!
                if (opponentScore < 17)
                {
                    Card card = deck.DrawCard();
                    if (card == null) break;
                    Hand.Add(card);
                    continue;
                }

                // Default: stand saja
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
