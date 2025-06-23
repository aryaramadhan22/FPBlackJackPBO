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
            buttonStart = new Button();
            buttonExit = new Button();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.BackColor = Color.Transparent;
            buttonStart.BackgroundImage = Properties.Resources.btn;
            buttonStart.BackgroundImageLayout = ImageLayout.Stretch;
            buttonStart.FlatStyle = FlatStyle.Flat;
            buttonStart.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonStart.Location = new Point(248, 188);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(177, 58);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start Game";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.Transparent;
            buttonExit.BackgroundImage = Properties.Resources.btn;
            buttonExit.BackgroundImageLayout = ImageLayout.Stretch;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonExit.Location = new Point(248, 281);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(177, 58);
            buttonExit.TabIndex = 1;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Algerian", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.WhiteSmoke;
            labelTitle.Location = new Point(35, 27);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(628, 66);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "BLACKJACK BATTLE";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.Click += labelTitle_Click;
            // 
            // MainMenu
            // 
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(698, 488);
            Controls.Add(buttonStart);
            Controls.Add(buttonExit);
            Controls.Add(labelTitle);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();

        }
        private Label labelTitle;
    }
}
