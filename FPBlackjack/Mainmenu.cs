using System;
using System.Media;
using System.Windows.Forms;


namespace FPBlackjack
{
    public partial class MainMenu : Form
    {
        private SoundPlayer bgPlayer;

        public MainMenu()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false;                           
            this.MinimizeBox = true;                            
            this.StartPosition = FormStartPosition.CenterScreen; 

            this.BackgroundImage = Properties.Resources.BackgroundGame2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            bgPlayer = new SoundPlayer(Properties.Resources.bg_music);
            bgPlayer.PlayLooping();
        }

        private void buttonNormal_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(new NormalOpponent());
            gameForm.Show();
            this.Hide();
        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(new HardOpponent());
            gameForm.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
