using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPBlackjack
{
    public abstract class Opponent : Player
    {
        public override void PlayTurn(Deck deck, int playerScore) { }
    }
}
