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
        private AIPlayer ai;
        private IScoreEvaluator evaluator = new BlackjackScoreEvaluator();

        private int playerHP = 100;
        private int aiHP = 100;
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
            ai = new AIPlayer { Name = "AI" };

            playerHP = 100;
            aiHP = 100;
            skillGauge = 0;
            isSkillActive = false;

            human.Hand.Clear();
            ai.Hand.Clear();

            UpdateUI();

            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
        }

        private void UpdateUI()
        {
            labelPlayerScore.Text = $"Player Score: {evaluator.CalculateScore(human.Hand)}";
            labelAIScore.Text = $"AI Score: {evaluator.CalculateScore(ai.Hand)}";
            labelPlayerHP.Text = $"Player HP: {playerHP}";
            labelAIHP.Text = $"AI HP: {aiHP}";
            progressBarSkill.Value = skillGauge;

            panelPlayerCards.Controls.Clear();
            panelAICards.Controls.Clear();

            int x = 0;
            foreach (Card card in human.Hand)
            {
                PictureBox pic = CreateCardImage(card);
                pic.Location = new Point(x, 0);
                panelPlayerCards.Controls.Add(pic);
                x += 65;
            }

            x = 0;
            foreach (Card card in ai.Hand)
            {
                PictureBox pic = CreateCardImage(card);
                pic.Location = new Point(x, 0);
                panelAICards.Controls.Add(pic);
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

            // === AI HIT Sekali ===
            if (deck.IsEmpty()) deck.Refill();
            ai.Hand.Add(deck.DrawCard());

            int aiScore = evaluator.CalculateScore(ai.Hand);

            UpdateUI();

            if (playerScore > 21)
            {
                playerHP -= aiScore;
                labelRoundStatus.Text = $"Kamu bust! AI menang ronde ini.";
                labelRoundStatus.Visible = true;

                buttonHit.Enabled = false;
                buttonStand.Enabled = false;
                buttonSkill.Enabled = false;

                roundTransitionTimer.Start();
                return;
            }

            if (aiScore > 21)
            {
                aiHP -= playerScore;
                labelRoundStatus.Text = $"AI bust! Kamu serang AI sebesar {playerScore}!";
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
            int aiScore = evaluator.CalculateScore(ai.Hand);

            string result;

            if (playerScore > aiScore && playerScore <= 21 || aiScore > 21)
            {
                aiHP -= playerScore;
                result = $"You win the round! AI kehilangan {playerScore} HP!";
            }
            else if (aiScore > playerScore && aiScore <= 21 || playerScore > 21)
            {
                playerHP -= aiScore;
                result = $"AI win the round! Kamu kehilangan {aiScore} HP!";
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
            else if (aiHP <= 0)
            {
                MessageBox.Show("You Win! AI KO.");
                StartGame();
                return;
            }

            NextRound();
        }

        private void NextRound()
        {
            human.Hand.Clear();
            ai.Hand.Clear();
            if (deck.IsEmpty()) deck.Refill();
            UpdateUI();

            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
            buttonSkill.Enabled = skillGauge >= maxGauge;
        }
    }
}
