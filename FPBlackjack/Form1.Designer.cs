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
            this.components = new System.ComponentModel.Container();
            this.panelPlayerCards = new System.Windows.Forms.Panel();
            this.panelOpponentCards = new System.Windows.Forms.Panel();
            this.labelPlayerScore = new System.Windows.Forms.Label();
            this.labelOpponentScore = new System.Windows.Forms.Label();
            this.labelPlayerHP = new System.Windows.Forms.Label();
            this.labelOpponentHP = new System.Windows.Forms.Label();
            this.buttonHit = new System.Windows.Forms.Button();
            this.buttonStand = new System.Windows.Forms.Button();
            this.buttonSkill = new System.Windows.Forms.Button();
            this.progressBarSkill = new System.Windows.Forms.ProgressBar();
            this.labelRoundStatus = new System.Windows.Forms.Label();
            this.roundTransitionTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // panelPlayerCards
            this.panelPlayerCards.Location = new System.Drawing.Point(50, 300);
            this.panelPlayerCards.Name = "panelPlayerCards";
            this.panelPlayerCards.Size = new System.Drawing.Size(600, 100);
            this.panelPlayerCards.TabIndex = 0;

            // panelOpponentCards
            this.panelOpponentCards.Location = new System.Drawing.Point(50, 50);
            this.panelOpponentCards.Name = "panelOpponentCards";
            this.panelOpponentCards.Size = new System.Drawing.Size(600, 100);
            this.panelOpponentCards.TabIndex = 1;

            // labelPlayerScore
            this.labelPlayerScore.AutoSize = true;
            this.labelPlayerScore.Location = new System.Drawing.Point(50, 270);
            this.labelPlayerScore.Name = "labelPlayerScore";
            this.labelPlayerScore.Size = new System.Drawing.Size(85, 15);
            this.labelPlayerScore.TabIndex = 2;
            this.labelPlayerScore.Text = "Player Score:";

            // labelOpponentScore
            this.labelOpponentScore.AutoSize = true;
            this.labelOpponentScore.Location = new System.Drawing.Point(50, 20);
            this.labelOpponentScore.Name = "labelOpponentScore";
            this.labelOpponentScore.Size = new System.Drawing.Size(97, 15);
            this.labelOpponentScore.TabIndex = 3;
            this.labelOpponentScore.Text = "Opponent Score:";

            // labelPlayerHP
            this.labelPlayerHP.AutoSize = true;
            this.labelPlayerHP.Location = new System.Drawing.Point(500, 270);
            this.labelPlayerHP.Name = "labelPlayerHP";
            this.labelPlayerHP.Size = new System.Drawing.Size(65, 15);
            this.labelPlayerHP.TabIndex = 4;
            this.labelPlayerHP.Text = "Player HP:";

            // labelOpponentHP
            this.labelOpponentHP.AutoSize = true;
            this.labelOpponentHP.Location = new System.Drawing.Point(500, 20);
            this.labelOpponentHP.Name = "labelOpponentHP";
            this.labelOpponentHP.Size = new System.Drawing.Size(81, 15);
            this.labelOpponentHP.TabIndex = 5;
            this.labelOpponentHP.Text = "Opponent HP:";

            // buttonHit
            this.buttonHit.Location = new System.Drawing.Point(50, 420);
            this.buttonHit.Name = "buttonHit";
            this.buttonHit.Size = new System.Drawing.Size(75, 30);
            this.buttonHit.TabIndex = 6;
            this.buttonHit.Text = "Hit";
            this.buttonHit.UseVisualStyleBackColor = true;
            this.buttonHit.Click += new System.EventHandler(this.buttonHit_Click);

            // buttonStand
            this.buttonStand.Location = new System.Drawing.Point(140, 420);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(75, 30);
            this.buttonStand.TabIndex = 7;
            this.buttonStand.Text = "Stand";
            this.buttonStand.UseVisualStyleBackColor = true;
            this.buttonStand.Click += new System.EventHandler(this.buttonStand_Click);

            // buttonSkill
            this.buttonSkill.Location = new System.Drawing.Point(230, 420);
            this.buttonSkill.Name = "buttonSkill";
            this.buttonSkill.Size = new System.Drawing.Size(75, 30);
            this.buttonSkill.TabIndex = 8;
            this.buttonSkill.Text = "Skill";
            this.buttonSkill.UseVisualStyleBackColor = true;
            this.buttonSkill.Click += new System.EventHandler(this.buttonSkill_Click);

            // progressBarSkill
            this.progressBarSkill.Location = new System.Drawing.Point(320, 420);
            this.progressBarSkill.Maximum = 40;
            this.progressBarSkill.Name = "progressBarSkill";
            this.progressBarSkill.Size = new System.Drawing.Size(150, 30);
            this.progressBarSkill.TabIndex = 9;

            // labelRoundStatus
            this.labelRoundStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRoundStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.labelRoundStatus.Location = new System.Drawing.Point(50, 200);
            this.labelRoundStatus.Name = "labelRoundStatus";
            this.labelRoundStatus.Size = new System.Drawing.Size(600, 40);
            this.labelRoundStatus.TabIndex = 10;
            this.labelRoundStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRoundStatus.Text = "";
            this.labelRoundStatus.Visible = false;

            // roundTransitionTimer
            this.roundTransitionTimer.Interval = 1500;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Controls.Add(this.labelRoundStatus);
            this.Controls.Add(this.progressBarSkill);
            this.Controls.Add(this.buttonSkill);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.buttonHit);
            this.Controls.Add(this.labelOpponentHP);
            this.Controls.Add(this.labelPlayerHP);
            this.Controls.Add(this.labelOpponentScore);
            this.Controls.Add(this.labelPlayerScore);
            this.Controls.Add(this.panelOpponentCards);
            this.Controls.Add(this.panelPlayerCards);
            this.Name = "Form1";
            this.Text = "Blackjack Battle";
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Button buttonSkill;
        private System.Windows.Forms.ProgressBar progressBarSkill;
        private System.Windows.Forms.Label labelRoundStatus;
        private System.Windows.Forms.Timer roundTransitionTimer;
    }
}
