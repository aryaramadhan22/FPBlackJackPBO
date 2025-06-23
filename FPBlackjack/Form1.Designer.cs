// Form1.Designer.cs
namespace FPBlackjack
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelPlayerCards = new Panel();
            panelOpponentCards = new Panel();
            labelPlayerScore = new Label();
            labelOpponentScore = new Label();
            labelPlayerHP = new Label();
            labelOpponentHP = new Label();
            buttonHit = new Button();
            buttonStand = new Button();
            buttonSkillPreventBust = new Button();
            buttonSkillDoubleDamage = new Button();
            progressBarSkill = new ProgressBar();
            labelRoundStatus = new Label();
            roundTransitionTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // panelPlayerCards
            // 
            panelPlayerCards.BackColor = Color.Transparent;
            panelPlayerCards.Location = new Point(57, 400);
            panelPlayerCards.Margin = new Padding(3, 4, 3, 4);
            panelPlayerCards.Name = "panelPlayerCards";
            panelPlayerCards.Size = new Size(686, 133);
            panelPlayerCards.TabIndex = 0;
            // 
            // panelOpponentCards
            // 
            panelOpponentCards.BackColor = Color.Transparent;
            panelOpponentCards.Location = new Point(57, 67);
            panelOpponentCards.Margin = new Padding(3, 4, 3, 4);
            panelOpponentCards.Name = "panelOpponentCards";
            panelOpponentCards.Size = new Size(686, 133);
            panelOpponentCards.TabIndex = 1;
            // 
            // labelPlayerScore
            // 
            labelPlayerScore.AutoSize = true;
            labelPlayerScore.BackColor = Color.Transparent;
            labelPlayerScore.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPlayerScore.ForeColor = Color.White;
            labelPlayerScore.Location = new Point(57, 360);
            labelPlayerScore.Name = "labelPlayerScore";
            labelPlayerScore.Size = new Size(117, 16);
            labelPlayerScore.TabIndex = 2;
            labelPlayerScore.Text = "Player Score:";
      
            // 
            // labelOpponentScore
            // 
            labelOpponentScore.AutoSize = true;
            labelOpponentScore.BackColor = Color.Transparent;
            labelOpponentScore.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelOpponentScore.ForeColor = Color.White;
            labelOpponentScore.Location = new Point(57, 27);
            labelOpponentScore.Name = "labelOpponentScore";
            labelOpponentScore.Size = new Size(132, 16);
            labelOpponentScore.TabIndex = 3;
            labelOpponentScore.Text = "Opponent Score:";
            // 
            // labelPlayerHP
            // 
            labelPlayerHP.AutoSize = true;
            labelPlayerHP.BackColor = Color.Transparent;
            labelPlayerHP.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPlayerHP.ForeColor = Color.White;
            labelPlayerHP.Location = new Point(571, 360);
            labelPlayerHP.Name = "labelPlayerHP";
            labelPlayerHP.Size = new Size(90, 16);
            labelPlayerHP.TabIndex = 4;
            labelPlayerHP.Text = "Player HP:";
            // 
            // labelOpponentHP
            // 
            labelOpponentHP.AutoSize = true;
            labelOpponentHP.BackColor = Color.Transparent;
            labelOpponentHP.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelOpponentHP.ForeColor = Color.White;
            labelOpponentHP.Location = new Point(571, 27);
            labelOpponentHP.Name = "labelOpponentHP";
            labelOpponentHP.Size = new Size(105, 16);
            labelOpponentHP.TabIndex = 5;
            labelOpponentHP.Text = "Opponent HP:";
            // 
            // buttonHit
            // 
            buttonHit.BackColor = Color.Transparent;
            buttonHit.BackgroundImage = Properties.Resources.btn;
            buttonHit.FlatStyle = FlatStyle.Flat;
            buttonHit.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonHit.Location = new Point(57, 560);
            buttonHit.Margin = new Padding(3, 4, 3, 4);
            buttonHit.Name = "buttonHit";
            buttonHit.Size = new Size(86, 40);
            buttonHit.TabIndex = 6;
            buttonHit.Text = "Hit";
            buttonHit.UseVisualStyleBackColor = false;
            buttonHit.Click += buttonHit_Click;
            // 
            // buttonStand
            // 
            buttonStand.BackColor = Color.Transparent;
            buttonStand.BackgroundImage = Properties.Resources.btn;
            buttonStand.FlatStyle = FlatStyle.Flat;
            buttonStand.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonStand.Location = new Point(160, 560);
            buttonStand.Margin = new Padding(3, 4, 3, 4);
            buttonStand.Name = "buttonStand";
            buttonStand.Size = new Size(86, 40);
            buttonStand.TabIndex = 7;
            buttonStand.Text = "Stand";
            buttonStand.UseVisualStyleBackColor = false;
            buttonStand.Click += buttonStand_Click;
            // 
            // buttonSkillPreventBust
            // 
            buttonSkillPreventBust.BackColor = Color.Transparent;
            buttonSkillPreventBust.BackgroundImage = Properties.Resources.btn;
            buttonSkillPreventBust.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSkillPreventBust.Enabled = false;
            buttonSkillPreventBust.FlatStyle = FlatStyle.Flat;
            buttonSkillPreventBust.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSkillPreventBust.ForeColor = SystemColors.ControlText;
            buttonSkillPreventBust.Location = new Point(263, 560);
            buttonSkillPreventBust.Margin = new Padding(3, 4, 3, 4);
            buttonSkillPreventBust.Name = "buttonSkillPreventBust";
            buttonSkillPreventBust.Size = new Size(137, 40);
            buttonSkillPreventBust.TabIndex = 8;
            buttonSkillPreventBust.Text = "Prevent Bust";
            buttonSkillPreventBust.UseVisualStyleBackColor = false;
            buttonSkillPreventBust.Click += buttonSkillPreventBust_Click;
            // 
            // buttonSkillDoubleDamage
            // 
            buttonSkillDoubleDamage.BackColor = Color.Transparent;
            buttonSkillDoubleDamage.BackgroundImage = Properties.Resources.btn;
            buttonSkillDoubleDamage.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSkillDoubleDamage.Enabled = false;
            buttonSkillDoubleDamage.FlatStyle = FlatStyle.Flat;
            buttonSkillDoubleDamage.Font = new Font("Algerian", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSkillDoubleDamage.Location = new Point(423, 560);
            buttonSkillDoubleDamage.Margin = new Padding(3, 4, 3, 4);
            buttonSkillDoubleDamage.Name = "buttonSkillDoubleDamage";
            buttonSkillDoubleDamage.Size = new Size(149, 40);
            buttonSkillDoubleDamage.TabIndex = 9;
            buttonSkillDoubleDamage.Text = "Double Damage";
            buttonSkillDoubleDamage.UseVisualStyleBackColor = false;
            buttonSkillDoubleDamage.Click += buttonSkillDoubleDamage_Click;
            // 
            // progressBarSkill
            // 
            progressBarSkill.BackColor = SystemColors.Control;
            progressBarSkill.Location = new Point(594, 560);
            progressBarSkill.Margin = new Padding(3, 4, 3, 4);
            progressBarSkill.Maximum = 50;
            progressBarSkill.Name = "progressBarSkill";
            progressBarSkill.Size = new Size(171, 40);
            progressBarSkill.TabIndex = 10;
            // 
            // labelRoundStatus
            // 
            labelRoundStatus.BackColor = Color.Transparent;
            labelRoundStatus.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRoundStatus.ForeColor = Color.White;
            labelRoundStatus.Location = new Point(57, 267);
            labelRoundStatus.Name = "labelRoundStatus";
            labelRoundStatus.Size = new Size(686, 53);
            labelRoundStatus.TabIndex = 11;
            labelRoundStatus.TextAlign = ContentAlignment.MiddleCenter;
            labelRoundStatus.Visible = false;
            // 
            // roundTransitionTimer
            // 
            roundTransitionTimer.Interval = 1500;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 640);
            Controls.Add(labelRoundStatus);
            Controls.Add(progressBarSkill);
            Controls.Add(buttonSkillPreventBust);
            Controls.Add(buttonSkillDoubleDamage);
            Controls.Add(buttonStand);
            Controls.Add(buttonHit);
            Controls.Add(labelOpponentHP);
            Controls.Add(labelPlayerHP);
            Controls.Add(labelOpponentScore);
            Controls.Add(labelPlayerScore);
            Controls.Add(panelOpponentCards);
            Controls.Add(panelPlayerCards);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Blackjack Battle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelPlayerCards;
        private System.Windows.Forms.Panel panelOpponentCards;
        private System.Windows.Forms.Label labelPlayerScore;
        private System.Windows.Forms.Label labelOpponentScore;
        private System.Windows.Forms.Label labelPlayerHP;
        private System.Windows.Forms.Label labelOpponentHP;
        private System.Windows.Forms.Button buttonHit;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.Button buttonSkillPreventBust;
        private System.Windows.Forms.Button buttonSkillDoubleDamage;
        private System.Windows.Forms.ProgressBar progressBarSkill;
        private System.Windows.Forms.Label labelRoundStatus;
        private System.Windows.Forms.Timer roundTransitionTimer;
    }
}
