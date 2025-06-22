// Form1.cs
using FPBlackjack.Properties;
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

        private bool isSkillActive = false;
        private int skillGauge = 0;
        private const int maxGauge = 40;

        public Form1()
        {
            InitializeComponent();
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
            progressBarSkill.Value = 0;
            buttonSkill.Enabled = false;

            human.Hand.Clear();
            ai.Hand.Clear();

            UpdateUI();
        }

        private void UpdateUI()
        {
            labelPlayerScore.Text = $"Player Score: {evaluator.CalculateScore(human.Hand)}";
            labelAIScore.Text = $"AI Score: {evaluator.CalculateScore(ai.Hand)}";
            labelPlayerHP.Text = $"Player HP: {playerHP}";
            labelAIHP.Text = $"AI HP: {aiHP}";

            panelPlayerCards.Controls.Clear();
            panelAICards.Controls.Clear();

            int x = 0;
            foreach (Card card in human.Hand)
            {
                PictureBox pic = CreateCardImage(card);
                pic.Location = new Point(x, 0);
                x += 65; // Jarak antar kartu
                panelPlayerCards.Controls.Add(pic);
            }

            x = 0;
            foreach (Card card in ai.Hand)
            {
                PictureBox pic = CreateCardImage(card);
                pic.Location = new Point(x, 0);
                x += 65;
                panelAICards.Controls.Add(pic);
            }
        }

        private PictureBox CreateCardImage(Card card)
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(60, 90);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                var image = (Image)Resources.ResourceManager.GetObject(card.Image);
                if (image == null)
                {
                    Console.WriteLine($" Gambar tidak ditemukan untuk: {card.Image}");
                    pic.BackColor = Color.Red;
                }
                else
                {
                    Console.WriteLine($"Gambar ditemukan: {card.Image} - Value: {card.Value}");
                    pic.Image = image;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"‼️ ERROR ambil gambar {card.Image}: {ex.Message}");
                pic.BackColor = Color.Red;
            }

            return pic;
        }

        private void buttonHit_Click(object sender, EventArgs e)
        {
            int currentScore = evaluator.CalculateScore(human.Hand);
            Card drawnCard = null;

            if (isSkillActive)
            {
                int maxValue = 21 - currentScore;
                int safetyCounter = 0;

                do
                {
                    drawnCard = deck.DrawCard();
                    safetyCounter++;

                    if (drawnCard == null || safetyCounter > 100)
                    {
                        MessageBox.Show("Tidak ada kartu yang sesuai tersedia.");
                        isSkillActive = false;
                        return;
                    }

                } while (drawnCard.Value > maxValue);

                isSkillActive = false;
            }
            else
            {
                drawnCard = deck.DrawCard();
                if (drawnCard == null)
                {
                    MessageBox.Show("Deck habis! Tidak ada kartu yang bisa ditarik.");
                    return;
                }
            }

            // Tambahkan kartu ke tangan player
            human.Hand.Add(drawnCard);

            // Tambahkan ke skill gauge
            skillGauge += drawnCard.Value;
            if (skillGauge > maxGauge) skillGauge = maxGauge;
            progressBarSkill.Value = skillGauge;
            buttonSkill.Enabled = skillGauge >= maxGauge;

            // Cek apakah player bust
            int playerScore = evaluator.CalculateScore(human.Hand);
            if (playerScore > 21)
            {
                UpdateUI();
                MessageBox.Show("Kamu bust! AI menang ronde ini.");
                playerHP -= evaluator.CalculateScore(ai.Hand);
                CekKondisiKalahMenang();
                NextRound();
                return;
            }

            // === AI HIT satu kali setelah player hit ===
            Card aiCard = deck.DrawCard();
            if (aiCard != null)
            {
                ai.Hand.Add(aiCard);
            }

            int aiScore = evaluator.CalculateScore(ai.Hand);
            if (aiScore > 21)
            {
                UpdateUI();
                MessageBox.Show("AI bust! Kamu serang AI sebesar " + playerScore);
                aiHP -= playerScore;
                CekKondisiKalahMenang();
                NextRound();
                return;
            }

            UpdateUI();
        }



        private void buttonStand_Click(object sender, EventArgs e)
        {
            ai.PlayTurn(deck);

            int aiScore = evaluator.CalculateScore(ai.Hand);
            int playerScore = evaluator.CalculateScore(human.Hand);

            UpdateUI();

            // ✅ Tambahkan ini: cek apakah AI bust
            if (aiScore > 21)
            {
                MessageBox.Show("AI bust! Kamu serang AI sebesar " + playerScore);
                aiHP -= playerScore;
                CekKondisiKalahMenang();
                NextRound();
                return;
            }

            // ✅ Jika tidak bust, baru bandingkan
            string result;

            if (playerScore > aiScore)
            {
                aiHP -= playerScore;
                result = $"You win the round! AI kehilangan {playerScore} HP!";
            }
            else if (aiScore > playerScore)
            {
                playerHP -= aiScore;
                result = $"AI win the round! Kamu kehilangan {aiScore} HP!";
            }
            else
            {
                result = "Draw! Tidak ada damage.";
            }

            MessageBox.Show(result);
            CekKondisiKalahMenang();
            NextRound();
        }

        private void buttonSkill_Click(object sender, EventArgs e)
        {
            if (skillGauge >= maxGauge)
            {
                isSkillActive = true;
                skillGauge = 0;
                progressBarSkill.Value = 0;
                buttonSkill.Enabled = false;
                MessageBox.Show("Skill aktif! Hit berikutnya dijamin tidak bust.");
            }
        }

        private void CekKondisiKalahMenang()
        {
            if (playerHP <= 0)
            {
                MessageBox.Show("Kamu kalah! HP kamu habis.");
                StartGame();
            }
            else if (aiHP <= 0)
            {
                MessageBox.Show("Kamu menang! AI KO.");
                StartGame();
            }
        }

        private void NextRound()
        {
            human.Hand.Clear();
            ai.Hand.Clear();
            deck.Shuffle();
            UpdateUI();
        }

        private void labelAIScore_Click(object sender, EventArgs e)
        {

        }
    }
}
