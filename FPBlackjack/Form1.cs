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
        private int maxGauge = 40;
        private bool isSkillActive = false;

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
            isSkillActive = false;

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
            if (deck.IsEmpty()) deck.Refill();

            int currentScore = evaluator.CalculateScore(human.Hand);
            Card drawnCard = null;

            if (isSkillActive)
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

                isSkillActive = false;
            }
            else
            {
                drawnCard = deck.DrawCard();
            }

            if (drawnCard == null) return;

            human.Hand.Add(drawnCard);
            skillGauge += drawnCard.Value;
            if (skillGauge > maxGauge) skillGauge = maxGauge;
            buttonSkill.Enabled = skillGauge >= maxGauge;

            int playerScore = evaluator.CalculateScore(human.Hand);

            // === Opponent HIT Sekali ===
            if (deck.IsEmpty()) deck.Refill();
            opponent.Hand.Add(deck.DrawCard());

            int opponentScore = evaluator.CalculateScore(opponent.Hand);

            UpdateUI();

            if (playerScore > 21)
            {
                playerHP -= opponentScore;
                labelRoundStatus.Text = $"Kamu bust! Opponent menang ronde ini.";
                labelRoundStatus.Visible = true;

                buttonHit.Enabled = false;
                buttonStand.Enabled = false;
                buttonSkill.Enabled = false;

                roundTransitionTimer.Start();
                return;
            }

            if (opponentScore > 21)
            {
                opponentHP -= playerScore;
                labelRoundStatus.Text = $"Opponent bust! Kamu serang Opponent sebesar {playerScore}!";
                labelRoundStatus.Visible = true;

                buttonHit.Enabled = false;
                buttonStand.Enabled = false;
                buttonSkill.Enabled = false;

                roundTransitionTimer.Start();
                return;
            }
        }


        private void buttonStand_Click(object sender, EventArgs e)
        {
            int playerScore = evaluator.CalculateScore(human.Hand);
            int opponentScore = evaluator.CalculateScore(opponent.Hand);

            string result;

            if (playerScore > opponentScore && playerScore <= 21 || opponentScore > 21)
            {
                opponentHP -= playerScore;
                result = $"You win the round! Opponent kehilangan {playerScore} HP!";
            }
            else if (opponentScore > playerScore && opponentScore <= 21 || playerScore > 21)
            {
                playerHP -= opponentScore;
                result = $"Opponent win the round! Kamu kehilangan {opponentScore} HP!";
            }
            else
            {
                result = "Draw! Tidak ada damage.";
            }

            labelRoundStatus.Text = result;
            labelRoundStatus.Visible = true;
            roundTransitionTimer.Start();
        }

        private void buttonSkill_Click(object sender, EventArgs e)
        {
            if (skillGauge >= maxGauge)
            {
                isSkillActive = true;
                skillGauge = 0;
                buttonSkill.Enabled = false;
                UpdateUI();
            }
        }

        private void roundTransitionTimer_Tick(object sender, EventArgs e)
        {
            roundTransitionTimer.Stop();
            labelRoundStatus.Visible = false;

            if (playerHP <= 0)
            {
                MessageBox.Show("You Lose! HP kamu habis.");
                StartGame();
                return;
            }
            else if (opponentHP <= 0)
            {
                MessageBox.Show("You Win! Opponent KO.");
                StartGame();
                return;
            }

            NextRound();
        }

        private void NextRound()
        {
            human.Hand.Clear();
            opponent.Hand.Clear();
            if (deck.IsEmpty()) deck.Refill();
            UpdateUI();

            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
            buttonSkill.Enabled = skillGauge >= maxGauge;
        }
    }
}
