namespace FPBlackjack
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;
        private Button buttonNormal;
        private Button buttonHard;
        private Button buttonExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonNormal = new Button();
            buttonHard = new Button();
            buttonExit = new Button();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // buttonNormal
            // 
            buttonNormal.BackColor = Color.Transparent;
            buttonNormal.BackgroundImage = Properties.Resources.btn;
            buttonNormal.BackgroundImageLayout = ImageLayout.Stretch;
            buttonNormal.FlatStyle = FlatStyle.Flat;
            buttonNormal.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonNormal.Location = new Point(248, 182);
            buttonNormal.Name = "buttonNormal";
            buttonNormal.Size = new Size(177, 58);
            buttonNormal.TabIndex = 0;
            buttonNormal.Text = "Normal Mode";
            buttonNormal.UseVisualStyleBackColor = false;
            buttonNormal.Click += buttonNormal_Click;
            // 
            // buttonHard
            // 
            buttonHard.BackColor = Color.Transparent;
            buttonHard.BackgroundImage = Properties.Resources.btn;
            buttonHard.BackgroundImageLayout = ImageLayout.Stretch;
            buttonHard.FlatStyle = FlatStyle.Flat;
            buttonHard.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonHard.Location = new Point(248, 266);
            buttonHard.Name = "buttonHard";
            buttonHard.Size = new Size(177, 58);
            buttonHard.TabIndex = 1;
            buttonHard.Text = "Hard Mode";
            buttonHard.UseVisualStyleBackColor = false;
            buttonHard.Click += buttonHard_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.Transparent;
            buttonExit.BackgroundImage = Properties.Resources.btn;
            buttonExit.BackgroundImageLayout = ImageLayout.Stretch;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonExit.Location = new Point(248, 351);
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
            Controls.Add(buttonNormal);
            Controls.Add(buttonHard);
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
