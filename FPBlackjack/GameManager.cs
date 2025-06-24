using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPBlackjack
{
    public class GameManager
    {
        public string EvaluateRound(Player player, Player opponent, bool isDoubleDamage, out int damage)
        {
            int playerScore = player.GetScore();
            int opponentScore = opponent.GetScore();
            damage = 0;

            if ((playerScore > opponentScore && playerScore <= 21) || opponentScore > 21)
            {
                damage = playerScore;
                if (isDoubleDamage) damage *= 2;
                opponent.HP -= damage;
                return "PlayerWin";
            }
            else if ((opponentScore > playerScore && opponentScore <= 21) || playerScore > 21)
            {
                damage = opponentScore;
                player.HP -= damage;
                return "OpponentWin";
            }
            else
            {
                return "Draw";
            }
        }

        public bool IsGameOver(Player player, Player opponent, out string message)
        {
            if (player.HP <= 0)
            {
                message = "You Lose! HP kamu habis.";
                return true;
            }

            if (opponent.HP <= 0)
            {
                message = "You Win! Opponent KO.";
                return true;
            }

            message = "";
            return false;
        }
    }
}
