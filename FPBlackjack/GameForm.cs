using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;

namespace FPBlackjack
{
    public partial class GameForm : Form
    {
        private Deck deck;
        private HumanPlayer human;
        private Player opponent;
        private GameManager gameManager = new GameManager();
        private SkillManager skillManager = new SkillManager();
        private WindowsMediaPlayer sfxPlayer;

        private bool isRevealed = false;

        public GameForm(Player opponentPlayer)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false;                           
            this.MinimizeBox = true;                            
            this.StartPosition = FormStartPosition.CenterScreen; 


            this.opponent = opponentPlayer;
            this.BackgroundImage = Properties.Resources.BackgroundGame2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            roundTransitionTimer.Tick += roundTransitionTimer_Tick;
            StartGame();
        }

        private void PlayCardDrawSound()
        {
            sfxPlayer = new WindowsMediaPlayer();
            sfxPlayer.URL = @"D:\\Blackjack assets\\card_draw.mp3";
            sfxPlayer.settings.volume = 80;
            sfxPlayer.controls.play();
        }

        private void StartGame()
        {
            deck = new Deck();
            deck.Shuffle();

            human = new HumanPlayer { Name = "Player" };
            opponent.Name = "Opponent";

            skillManager.ResetSkills();
            isRevealed = false;

            human.ResetHand();
            opponent.ResetHand();

            human.Hand.Add(deck.DrawCard());
            opponent.Hand.Add(deck.DrawCard());

            UpdateUI();

            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
        }

        private void UpdateUI()
        {
            labelPlayerHP.Text = $"Player HP: {human.HP}";
            labelOpponentHP.Text = $"Opponent HP: {opponent.HP}";
            progressBarSkill.Value = skillManager.SkillGauge;

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

            labelPlayerScore.Text = $"Player Score: {human.GetScore()}";

            if (!isRevealed && opponent.Hand.Count > 0)
                labelOpponentScore.Text = $"Opponent Score: {opponent.Hand[0].Value} + ?";
            else
                labelOpponentScore.Text = $"Opponent Score: {opponent.GetScore()}";

            bool canActivate = skillManager.CanActivateSkill();
            buttonSkillPreventBust.Enabled = canActivate;
            buttonSkillDoubleDamage.Enabled = canActivate;
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
            PlayCardDrawSound();

            if (deck.IsEmpty()) deck.Refill();

            int currentScore = human.GetScore();
            Card drawnCard = null;

            if (skillManager.PreventBustActive)
            {
                int maxValue = 21 - currentScore;
                int attempts = 0;
                do
                {
                    drawnCard = deck.DrawCard();
                    attempts++;
                    if (drawnCard == null) break;
                    if (drawnCard.Value <= maxValue || drawnCard.Name.Contains("Ace"))
                        break;
                } while (attempts < 30);

                skillManager.ResetSkills();
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
            skillManager.AddGauge(drawnCard.Value);

            UpdateUI();

            if (human.GetScore() > 21)
            {
                isRevealed = true;

                opponent.PlayTurn(deck, human.GetScore());

                int opponentScore = opponent.GetScore();
                human.HP -= opponentScore;

                labelRoundStatus.Text = "Kamu bust! Opponent menang ronde ini.";
                labelRoundStatus.ForeColor = Color.White;
                labelRoundStatus.Visible = true;

                UpdateUI();
                DisableAllButtons();
                roundTransitionTimer.Start();
            }
        }

        private void buttonStand_Click(object sender, EventArgs e)
        {
            opponent.PlayTurn(deck, human.GetScore());
            isRevealed = true;

            string result = gameManager.EvaluateRound(human, opponent, skillManager.DoubleDamageActive, out int damage);
            skillManager.ResetSkills();

            if (result == "PlayerWin")
            {
                labelRoundStatus.Text = $"You win the round! Opponent kehilangan {damage} HP!";
            }
            else if (result == "OpponentWin")
            {
                labelRoundStatus.Text = $"Opponent win the round! Kamu kehilangan {damage} HP!";
            }
            else
            {
                labelRoundStatus.Text = "Draw! Tidak ada damage.";
            }

            labelRoundStatus.ForeColor = Color.White;
            labelRoundStatus.Visible = true;
            UpdateUI();
            roundTransitionTimer.Start();
        }

        private void buttonSkillPreventBust_Click(object sender, EventArgs e)
        {
            skillManager.ActivatePreventBust();
            UpdateUI();
        }

        private void buttonSkillDoubleDamage_Click(object sender, EventArgs e)
        {
            skillManager.ActivateDoubleDamage();
            UpdateUI();
        }

        private void roundTransitionTimer_Tick(object sender, EventArgs e)
        {
            roundTransitionTimer.Stop();

            if (gameManager.IsGameOver(human, opponent, out string message))
            {
                labelRoundStatus.Text = message;
                labelRoundStatus.ForeColor = Color.Red;
                labelRoundStatus.Visible = true;
                DisableAllButtons();
                ReturnToMainMenuWithDelay();
                return;
            }

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
            labelRoundStatus.Visible = false;
            human.ResetHand();
            opponent.ResetHand();
            if (deck.IsEmpty()) deck.Refill();

            skillManager.ResetSkills();
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
        private void Form1_Load(object sender, EventArgs e) { }
        private void labelRoundStatus_Click(object sender, EventArgs e) { }
    }
}
