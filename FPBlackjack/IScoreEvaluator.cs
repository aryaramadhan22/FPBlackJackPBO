using System.Collections.Generic;

namespace FPBlackjack
{
    public interface IScoreEvaluator
    {
        int CalculateScore(List<Card> hand);
    }

    
}
