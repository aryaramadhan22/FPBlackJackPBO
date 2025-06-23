namespace FPBlackjack
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;
        private Button buttonStart;
        private Button buttonExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonStart = new Button();
            this.buttonExit = new Button();
            this.SuspendLayout();

            // buttonStart
            this.buttonStart.Location = new System.Drawing.Point(100, 50);
            this.buttonStart.Size = new System.Drawing.Size(120, 40);
            this.buttonStart.Text = "Start Game";
            this.buttonStart.Click += new EventHandler(this.buttonStart_Click);

            // buttonExit
            this.buttonExit.Location = new System.Drawing.Point(100, 110);
            this.buttonExit.Size = new System.Drawing.Size(120, 40);
            this.buttonExit.Text = "Exit";
            this.buttonExit.Click += new EventHandler(this.buttonExit_Click);

            // MainMenu
            this.ClientSize = new System.Drawing.Size(320, 200);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonExit);
            this.Text = "Main Menu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
