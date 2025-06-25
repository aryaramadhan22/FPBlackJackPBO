using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPBlackjack
{
    public class NormalOpponent : Player
    {
        private Random rng = new Random();

        public NormalOpponent()
        {
            Name = "Normal Opponent";
            HP = 100;
        }

        public override void PlayTurn(Deck deck, int playerScore)
        {
            while (true)
            {
                int opponentScore = GetScore();
                if (opponentScore >= 19) break;

                if (opponentScore >= 17 && opponentScore < 19 && opponentScore < playerScore && playerScore <= 21)
                {
                    if (rng.Next(100) < 15)
                    {
                        Card card = deck.DrawCard();
                        if (card == null) break;
                        Hand.Add(card);
                        continue;
                    }
                    break;
                }

                if (opponentScore < 17)
                {
                    Card card = deck.DrawCard();
                    if (card == null) break;
                    Hand.Add(card);
                    continue;
                }

                break;
            }
        }
    }

}
