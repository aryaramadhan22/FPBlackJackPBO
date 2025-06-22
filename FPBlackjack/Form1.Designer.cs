// Form1.Designer.cs
namespace FPBlackjack
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button buttonHit;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.Button buttonSkill;
        private System.Windows.Forms.Label labelPlayerScore;
        private System.Windows.Forms.Label labelAIScore;
        private System.Windows.Forms.Label labelPlayerHP;
        private System.Windows.Forms.Label labelAIHP;
        private System.Windows.Forms.Panel panelPlayerCards;
        private System.Windows.Forms.Panel panelAICards;
        private System.Windows.Forms.ProgressBar progressBarSkill;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonHit = new Button();
            buttonStand = new Button();
            buttonSkill = new Button();
            labelPlayerScore = new Label();
            labelAIScore = new Label();
            labelPlayerHP = new Label();
            labelAIHP = new Label();
            panelPlayerCards = new Panel();
            panelAICards = new Panel();
            progressBarSkill = new ProgressBar();
            SuspendLayout();
            // 
            // buttonHit
            // 
            buttonHit.Location = new Point(240, 223);
            buttonHit.Margin = new Padding(3, 4, 3, 4);
            buttonHit.Name = "buttonHit";
            buttonHit.Size = new Size(100, 38);
            buttonHit.TabIndex = 0;
            buttonHit.Text = "Hit";
            buttonHit.Click += buttonHit_Click;
            // 
            // buttonStand
            // 
            buttonStand.Location = new Point(240, 281);
            buttonStand.Margin = new Padding(3, 4, 3, 4);
            buttonStand.Name = "buttonStand";
            buttonStand.Size = new Size(100, 38);
            buttonStand.TabIndex = 1;
            buttonStand.Text = "Stand";
            buttonStand.Click += buttonStand_Click;
            // 
            // buttonSkill
            // 
            buttonSkill.Enabled = false;
            buttonSkill.Location = new Point(250, 500);
            buttonSkill.Margin = new Padding(3, 4, 3, 4);
            buttonSkill.Name = "buttonSkill";
            buttonSkill.Size = new Size(100, 38);
            buttonSkill.TabIndex = 2;
            buttonSkill.Text = "Skill";
            buttonSkill.Click += buttonSkill_Click;
            // 
            // labelPlayerScore
            // 
            labelPlayerScore.Location = new Point(53, 339);
            labelPlayerScore.Name = "labelPlayerScore";
            labelPlayerScore.Size = new Size(200, 25);
            labelPlayerScore.TabIndex = 3;
            labelPlayerScore.Text = "Player Score: 0";
            // 
            // labelAIScore
            // 
            labelAIScore.Location = new Point(53, 185);
            labelAIScore.Name = "labelAIScore";
            labelAIScore.Size = new Size(200, 25);
            labelAIScore.TabIndex = 4;
            labelAIScore.Text = "AI Score: 0";
            labelAIScore.Click += labelAIScore_Click;
            // 
            // labelPlayerHP
            // 
            labelPlayerHP.Location = new Point(53, 496);
            labelPlayerHP.Name = "labelPlayerHP";
            labelPlayerHP.Size = new Size(150, 25);
            labelPlayerHP.TabIndex = 5;
            labelPlayerHP.Text = "Player HP: 100";
            // 
            // labelAIHP
            // 
            labelAIHP.Location = new Point(57, 28);
            labelAIHP.Name = "labelAIHP";
            labelAIHP.Size = new Size(150, 25);
            labelAIHP.TabIndex = 6;
            labelAIHP.Text = "AI HP: 100";
            // 
            // panelPlayerCards
            // 
            panelPlayerCards.BorderStyle = BorderStyle.FixedSingle;
            panelPlayerCards.Location = new Point(53, 368);
            panelPlayerCards.Margin = new Padding(3, 4, 3, 4);
            panelPlayerCards.Name = "panelPlayerCards";
            panelPlayerCards.Size = new Size(500, 124);
            panelPlayerCards.TabIndex = 7;
            // 
            // panelAICards
            // 
            panelAICards.BorderStyle = BorderStyle.FixedSingle;
            panelAICards.Location = new Point(53, 57);
            panelAICards.Margin = new Padding(3, 4, 3, 4);
            panelAICards.Name = "panelAICards";
            panelAICards.Size = new Size(500, 124);
            panelAICards.TabIndex = 8;
            // 
            // progressBarSkill
            // 
            progressBarSkill.Location = new Point(370, 500);
            progressBarSkill.Margin = new Padding(3, 4, 3, 4);
            progressBarSkill.Maximum = 40;
            progressBarSkill.Name = "progressBarSkill";
            progressBarSkill.Size = new Size(150, 29);
            progressBarSkill.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 575);
            Controls.Add(buttonHit);
            Controls.Add(buttonStand);
            Controls.Add(buttonSkill);
            Controls.Add(labelPlayerScore);
            Controls.Add(labelAIScore);
            Controls.Add(labelPlayerHP);
            Controls.Add(labelAIHP);
            Controls.Add(panelPlayerCards);
            Controls.Add(panelAICards);
            Controls.Add(progressBarSkill);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Blackjack Game";
            ResumeLayout(false);
        }
    }
}
