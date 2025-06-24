using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPBlackjack
{
    public class HardOpponent : Opponent
    {
        private Random rng = new Random();

        public HardOpponent()
        {
            Name = "Hard Opponent";
            HP = 150;
        }

        public override void PlayTurn(Deck deck, int playerScore)
        {
            while (true)
            {
                int score = GetScore();

                if (score >= 18) break;

                if (score < playerScore && rng.Next(100) < 50)
                {
                    Card card = deck.DrawCard();
                    if (card == null) break;
                    Hand.Add(card);
                    continue;
                }

                if (score < 16)
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
