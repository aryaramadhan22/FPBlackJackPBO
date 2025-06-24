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
            this.BackgroundImage = Properties.Resources.BackgroundGame2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            bgPlayer = new SoundPlayer(Properties.Resources.bg_music);
            bgPlayer.PlayLooping();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1();
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
