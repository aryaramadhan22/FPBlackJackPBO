using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FPBlackjack
{
    public abstract class Player
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public int GetScore()
        {
            int total = 0;
            int aces = 0;

            foreach (Card card in Hand)
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

        public void ResetHand()
        {
            Hand.Clear();
        }

        public virtual void PlayTurn(Deck deck, int playerScore)
        {
            
        }
    }
}
