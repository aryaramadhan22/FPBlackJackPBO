using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FPBlackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private HumanPlayer human;
        private OpponentPlayer opponent;
        private IScoreEvaluator evaluator = new BlackjackScoreEvaluator();

        private int playerHP = 100;
        private int opponentHP = 100;
        private int skillGauge = 0;
        private const int maxGauge = 50;
        private bool isSkillPreventBustActive = false;
        private bool isSkillDoubleDamageActive = false;

        public Form1()
        {
            InitializeComponent();
            roundTransitionTimer.Tick += roundTransitionTimer_Tick;
            StartGame();
        }

        private void StartGame()
        {
            deck = new Deck();
            deck.Shuffle();

            human = new HumanPlayer { Name = "Player" };
            opponent = new OpponentPlayer { Name = "Opponent" };

            playerHP = 100;
            opponentHP = 100;
            skillGauge = 0;
            isSkillPreventBustActive = false;
            isSkillDoubleDamageActive = false;

            human.Hand.Clear();
            opponent.Hand.Clear();

            UpdateUI();

            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
        }

        private void UpdateUI()
        {
            labelPlayerScore.Text = $"Player Score: {evaluator.CalculateScore(human.Hand)}";
            labelOpponentScore.Text = $"Opponent Score: {evaluator.CalculateScore(opponent.Hand)}";
            labelPlayerHP.Text = $"Player HP: {playerHP}";
            labelOpponentHP.Text = $"Opponent HP: {opponentHP}";
            progressBarSkill.Value = skillGauge;

            panelPlayerCards.Controls.Clear();
            panelOpponentCards.Controls.Clear();

            int x = 0;
            foreach (Card card in human.Hand)
            {
                PictureBox pic = CreateCardImage(card);
                pic.Location = new Point(x, 0);
                panelPlayerCards.Controls.Add(pic);
                x += 65;
            }

            x = 0;
            foreach (Card card in opponent.Hand)
            {
                PictureBox pic = CreateCardImage(card);
                pic.Location = new Point(x, 0);
                panelOpponentCards.Controls.Add(pic);
                x += 65;
            }

            bool canActivateSkill = skillGauge >= maxGauge && !isSkillPreventBustActive && !isSkillDoubleDamageActive;
            buttonSkillPreventBust.Enabled = canActivateSkill;
            buttonSkillDoubleDamage.Enabled = canActivateSkill;
        }

        private PictureBox CreateCardImage(Card card)
        {
            PictureBox pic = new PictureBox
            {
                Size = new Size(60, 90),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            try
            {
                var img = card.GetImage();
                if (img != null)
                    pic.Image = img;
                else
                    pic.BackColor = Color.Red;
            }
            catch
            {
                pic.BackColor = Color.Red;
            }

            return pic;
        }

        private void buttonHit_Click(object sender, EventArgs e)
        {
            labelRoundStatus.Visible = false;

            if (deck.IsEmpty()) deck.Refill();

            int currentScore = evaluator.CalculateScore(human.Hand);
            Card drawnCard = null;

            if (isSkillPreventBustActive)
            {
                int maxValue = 21 - currentScore;
                int attempts = 0;

                do
                {
                    if (deck.IsEmpty()) deck.Refill();
                    drawnCard = deck.DrawCard();
                    attempts++;

                    if (drawnCard == null) break;

                    bool isAce = drawnCard.Name.Contains("Ace");
                    if (drawnCard.Value <= maxValue || isAce)
                        break;

                } while (attempts < 30);

                isSkillPreventBustActive = false;
                labelRoundStatus.Text = "Skill Prevent Bust aktif! Hit berikutnya dijamin tidak bust.";
                labelRoundStatus.ForeColor = Color.Blue;
                labelRoundStatus.Visible = true;
            }
            else
            {
                drawnCard = deck.DrawCard();
            }

            if (drawnCard == null) return;

            human.Hand.Add(drawnCard);
            skillGauge += drawnCard.Value;
            if (skillGauge > maxGauge) skillGauge = maxGauge;

            UpdateUI();

            int playerScore = evaluator.CalculateScore(human.Hand);

            // Opponent HIT sekali (jika memang perlu)
            if (deck.IsEmpty()) deck.Refill();
            opponent.Hand.Add(deck.DrawCard());

            int opponentScore = evaluator.CalculateScore(opponent.Hand);

            UpdateUI();

            if (playerScore > 21)
            {
                playerHP -= opponentScore;
                labelRoundStatus.Text = $"Kamu bust! Opponent menang ronde ini.";
                labelRoundStatus.ForeColor = Color.DarkRed;
                labelRoundStatus.Visible = true;

                buttonHit.Enabled = false;
                buttonStand.Enabled = false;
                buttonSkillPreventBust.Enabled = false;
                buttonSkillDoubleDamage.Enabled = false;

                roundTransitionTimer.Start();
                return;
            }

            if (opponentScore > 21)
            {
                int damage = playerScore;
                if (isSkillDoubleDamageActive)
                {
                    damage *= 2;
                    isSkillDoubleDamageActive = false;
                }
                opponentHP -= damage;
                labelRoundStatus.Text = $"Opponent bust! Kamu serang Opponent sebesar {damage}!";
                labelRoundStatus.ForeColor = Color.DarkRed;
                labelRoundStatus.Visible = true;

                buttonHit.Enabled = false;
                buttonStand.Enabled = false;
                buttonSkillPreventBust.Enabled = false;
                buttonSkillDoubleDamage.Enabled = false;

                roundTransitionTimer.Start();
                return;
            }
        }

        private void buttonStand_Click(object sender, EventArgs e)
        {
            // Logic Opponent: Hit hingga 17-21, Stand jika >= 17, berhenti jika dapat 21
            while (true)
            {
                int score = evaluator.CalculateScore(opponent.Hand);
                if (score >= 17)
                    break;
                Card card = deck.DrawCard();
                if (card == null) break;
                opponent.Hand.Add(card);
                score = evaluator.CalculateScore(opponent.Hand);
                if (score >= 21)
                    break;
            }

            UpdateUI();

            int playerScore = evaluator.CalculateScore(human.Hand);
            int opponentScore = evaluator.CalculateScore(opponent.Hand);

            string result;
            if (playerScore > opponentScore && playerScore <= 21 || opponentScore > 21)
            {
                int damage = playerScore;
                if (isSkillDoubleDamageActive)
                {
                    damage *= 2;
                    isSkillDoubleDamageActive = false;
                }
                opponentHP -= damage;
                result = $"You win the round! Opponent kehilangan {damage} HP!";
                labelRoundStatus.ForeColor = Color.DarkGreen;
            }
            else if (opponentScore > playerScore && opponentScore <= 21 || playerScore > 21)
            {
                playerHP -= opponentScore;
                result = $"Opponent win the round! Kamu kehilangan {opponentScore} HP!";
                labelRoundStatus.ForeColor = Color.DarkRed;
            }
            else
            {
                result = "Draw! Tidak ada damage.";
                labelRoundStatus.ForeColor = Color.Black;
            }

            labelRoundStatus.Text = result;
            labelRoundStatus.Visible = true;
            roundTransitionTimer.Start();
        }

        private void buttonSkillPreventBust_Click(object sender, EventArgs e)
        {
            if (skillGauge >= maxGauge && !isSkillDoubleDamageActive)
            {
                isSkillPreventBustActive = true;
                skillGauge = 0;
                UpdateUI();
                labelRoundStatus.Text = "Skill Prevent Bust aktif! Hit berikutnya dijamin tidak bust.";
                labelRoundStatus.ForeColor = Color.Blue;
                labelRoundStatus.Visible = true;
            }
        }

        private void buttonSkillDoubleDamage_Click(object sender, EventArgs e)
        {
            if (skillGauge >= maxGauge && !isSkillPreventBustActive)
            {
                isSkillDoubleDamageActive = true;
                skillGauge = 0;
                UpdateUI();
                labelRoundStatus.Text = "Skill Double Damage aktif! Jika kamu menang ronde ini, damage ke lawan x2.";
                labelRoundStatus.ForeColor = Color.Blue;
                labelRoundStatus.Visible = true;
            }
        }

        private void roundTransitionTimer_Tick(object sender, EventArgs e)
        {
            roundTransitionTimer.Stop();

            if (playerHP <= 0)
            {
                labelRoundStatus.Text = "You Lose! HP kamu habis.";
                labelRoundStatus.ForeColor = Color.DarkRed;
                labelRoundStatus.Visible = true;
                DisableAllButtons();
                StartGameAfterDelay();
                return;
            }
            else if (opponentHP <= 0)
            {
                labelRoundStatus.Text = "You Win! Opponent KO.";
                labelRoundStatus.ForeColor = Color.DarkGreen;
                labelRoundStatus.Visible = true;
                DisableAllButtons();
                StartGameAfterDelay();
                return;
            }

            labelRoundStatus.Visible = false;
            NextRound();
        }

        private async void StartGameAfterDelay()
        {
            await System.Threading.Tasks.Task.Delay(2000); // 2 detik delay
            StartGame();
        }

        private void NextRound()
        {
            human.Hand.Clear();
            opponent.Hand.Clear();
            if (deck.IsEmpty()) deck.Refill();

            isSkillPreventBustActive = false;
            isSkillDoubleDamageActive = false;

            UpdateUI();

            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
        }

        private void DisableAllButtons()
        {
            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonSkillPreventBust.Enabled = false;
            buttonSkillDoubleDamage.Enabled = false;
        }
    }
}

