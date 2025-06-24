using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace FPBlackjack
{
    public partial class Form1 : Form
    {
        private Deck deck;
        private HumanPlayer human;
        private OpponentPlayer opponent;
        private IScoreEvaluator evaluator = new BlackjackScoreEvaluator();

        private WindowsMediaPlayer bgMusicPlayer;
        private WindowsMediaPlayer sfxPlayer;

        private int playerHP = 100;
        private int opponentHP = 100;
        private int skillGauge = 0;
        private const int maxGauge = 50;
        private bool isSkillPreventBustActive = false;
        private bool isSkillDoubleDamageActive = false;
        private bool isRevealed = false;

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.BackgroundGame2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            roundTransitionTimer.Tick += roundTransitionTimer_Tick;
            StartGame();
        }

        private void PlayCardDrawSound()
        {
            sfxPlayer = new WindowsMediaPlayer();
            sfxPlayer.URL = @"D:\Blackjack assets\card_draw.mp3";
            sfxPlayer.settings.volume = 80;
            sfxPlayer.controls.play();
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
            isRevealed = false;

            human.Hand.Clear();
            opponent.Hand.Clear();

            human.Hand.Add(deck.DrawCard());
            opponent.Hand.Add(deck.DrawCard());

            UpdateUI();

            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
        }

        private void UpdateUI()
        {
            labelPlayerHP.Text = $"Player HP: {playerHP}";
            labelOpponentHP.Text = $"Opponent HP: {opponentHP}";
            progressBarSkill.Value = skillGauge;

            panelPlayerCards.Controls.Clear();
            int x = 0;
            foreach (Card card in human.Hand)
            {
                PictureBox pic = CreateCardImage(card);
                pic.Location = new Point(x, 0);
                panelPlayerCards.Controls.Add(pic);
                x += 65;
            }

            panelOpponentCards.Controls.Clear();
            x = 0;
            if (!isRevealed && opponent.Hand.Count > 0)
            {
                PictureBox pic = CreateCardImage(opponent.Hand[0]);
                pic.Location = new Point(0, 0);
                panelOpponentCards.Controls.Add(pic);
            }
            else
            {
                foreach (Card card in opponent.Hand)
                {
                    PictureBox pic = CreateCardImage(card);
                    pic.Location = new Point(x, 0);
                    panelOpponentCards.Controls.Add(pic);
                    x += 65;
                }
            }

            labelPlayerScore.Text = $"Player Score: {evaluator.CalculateScore(human.Hand)}";

            if (!isRevealed && opponent.Hand.Count > 0)
                labelOpponentScore.Text = $"Opponent Score: {opponent.Hand[0].Value} + ?";
            else
                labelOpponentScore.Text = $"Opponent Score: {evaluator.CalculateScore(opponent.Hand)}";

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
            PlayCardDrawSound();

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
                labelRoundStatus.Text = "Skill Prevent Bust aktif!";
                labelRoundStatus.ForeColor = Color.Aqua;
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
            if (playerScore > 21)
            {
                int opponentScore = evaluator.CalculateScore(opponent.Hand);
                playerHP -= opponentScore;
                labelRoundStatus.Text = "Kamu bust! Opponent menang ronde ini.";
                labelRoundStatus.ForeColor = Color.White;
                labelRoundStatus.Visible = true;

                DisableAllButtons();
                isRevealed = true;
                UpdateUI();
                roundTransitionTimer.Start();
            }
        }

        private void buttonStand_Click(object sender, EventArgs e)
        {
            int playerScore = evaluator.CalculateScore(human.Hand);

            opponent.PlayTurn(deck, playerScore);
            isRevealed = true;
            UpdateUI();

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
            labelRoundStatus.ForeColor = Color.White;
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
                labelRoundStatus.Text = "Skill Prevent Bust aktif!";
                labelRoundStatus.ForeColor = Color.Aqua;
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
                labelRoundStatus.Text = "Skill Double Damage aktif!";
                labelRoundStatus.ForeColor = Color.Gold;
                labelRoundStatus.Visible = true;
            }
        }

        private void roundTransitionTimer_Tick(object sender, EventArgs e)
        {
            roundTransitionTimer.Stop();

            if (playerHP <= 0)
            {
                labelRoundStatus.Text = "You Lose! HP kamu habis.";
                labelRoundStatus.ForeColor = Color.Red;
                labelRoundStatus.Visible = true;
                DisableAllButtons();
                ReturnToMainMenuWithDelay();
                return;
            }

            if (opponentHP <= 0)
            {
                labelRoundStatus.Text = "You Win! Opponent KO.";
                labelRoundStatus.ForeColor = Color.Lime;
                labelRoundStatus.Visible = true;
                DisableAllButtons();
                ReturnToMainMenuWithDelay();
                return;
            }

            labelRoundStatus.Visible = false;
            NextRound();
        }

        private async void ReturnToMainMenuWithDelay()
        {
            await System.Threading.Tasks.Task.Delay(3000);
            var menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        private void NextRound()
        {
            human.Hand.Clear();
            opponent.Hand.Clear();
            if (deck.IsEmpty()) deck.Refill();

            isSkillPreventBustActive = false;
            isSkillDoubleDamageActive = false;
            isRevealed = false;

            human.Hand.Add(deck.DrawCard());
            opponent.Hand.Add(deck.DrawCard());

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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void labelRoundStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
