
namespace Hangman
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.wordGuessLabel = new System.Windows.Forms.Label();
            this.guessButton = new System.Windows.Forms.Button();
            this.player1ScoreBoardLabel = new System.Windows.Forms.Label();
            this.player1Score = new System.Windows.Forms.Label();
            this.something = new System.Windows.Forms.Label();
            this.player2ScoreBoardLabel = new System.Windows.Forms.Label();
            this.player2Score = new System.Windows.Forms.Label();
            this.usedLettersLabel = new System.Windows.Forms.Label();
            this.usedLettersBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(31, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 252);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "l";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(858, 362);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPress);
            // 
            // wordGuessLabel
            // 
            this.wordGuessLabel.AutoSize = true;
            this.wordGuessLabel.Location = new System.Drawing.Point(858, 335);
            this.wordGuessLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wordGuessLabel.Name = "wordGuessLabel";
            this.wordGuessLabel.Size = new System.Drawing.Size(41, 15);
            this.wordGuessLabel.TabIndex = 3;
            this.wordGuessLabel.Text = "Буква:";
            // 
            // guessButton
            // 
            this.guessButton.Location = new System.Drawing.Point(870, 391);
            this.guessButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guessButton.Name = "guessButton";
            this.guessButton.Size = new System.Drawing.Size(75, 23);
            this.guessButton.TabIndex = 4;
            this.guessButton.Text = "Въведи";
            this.guessButton.UseVisualStyleBackColor = true;
            this.guessButton.Click += new System.EventHandler(this.Guess);
            // 
            // player1ScoreBoardLabel
            // 
            this.player1ScoreBoardLabel.AutoSize = true;
            this.player1ScoreBoardLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player1ScoreBoardLabel.Location = new System.Drawing.Point(47, 387);
            this.player1ScoreBoardLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1ScoreBoardLabel.Name = "player1ScoreBoardLabel";
            this.player1ScoreBoardLabel.Size = new System.Drawing.Size(80, 25);
            this.player1ScoreBoardLabel.TabIndex = 3;
            this.player1ScoreBoardLabel.Text = "Играч 1";
            // 
            // player1Score
            // 
            this.player1Score.AutoSize = true;
            this.player1Score.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player1Score.Location = new System.Drawing.Point(135, 379);
            this.player1Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(32, 37);
            this.player1Score.TabIndex = 5;
            this.player1Score.Text = "0";
            // 
            // something
            // 
            this.something.AutoSize = true;
            this.something.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.something.Location = new System.Drawing.Point(164, 379);
            this.something.Name = "something";
            this.something.Size = new System.Drawing.Size(23, 37);
            this.something.TabIndex = 6;
            this.something.Text = ":";
            // 
            // player2ScoreBoardLabel
            // 
            this.player2ScoreBoardLabel.AutoSize = true;
            this.player2ScoreBoardLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player2ScoreBoardLabel.Location = new System.Drawing.Point(224, 387);
            this.player2ScoreBoardLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2ScoreBoardLabel.Name = "player2ScoreBoardLabel";
            this.player2ScoreBoardLabel.Size = new System.Drawing.Size(80, 25);
            this.player2ScoreBoardLabel.TabIndex = 7;
            this.player2ScoreBoardLabel.Text = "Играч 2";
            // 
            // player2Score
            // 
            this.player2Score.AutoSize = true;
            this.player2Score.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player2Score.Location = new System.Drawing.Point(184, 379);
            this.player2Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2Score.Name = "player2Score";
            this.player2Score.Size = new System.Drawing.Size(32, 37);
            this.player2Score.TabIndex = 8;
            this.player2Score.Text = "0";
            // 
            // usedLettersLabel
            // 
            this.usedLettersLabel.AutoSize = true;
            this.usedLettersLabel.Location = new System.Drawing.Point(682, 336);
            this.usedLettersLabel.Name = "usedLettersLabel";
            this.usedLettersLabel.Size = new System.Drawing.Size(111, 15);
            this.usedLettersLabel.TabIndex = 9;
            this.usedLettersLabel.Text = "Използвани букви:";
            // 
            // usedLettersBox
            // 
            this.usedLettersBox.Location = new System.Drawing.Point(682, 362);
            this.usedLettersBox.Multiline = true;
            this.usedLettersBox.Name = "usedLettersBox";
            this.usedLettersBox.Size = new System.Drawing.Size(111, 52);
            this.usedLettersBox.TabIndex = 10;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 447);
            this.Controls.Add(this.usedLettersBox);
            this.Controls.Add(this.usedLettersLabel);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.player2ScoreBoardLabel);
            this.Controls.Add(this.something);
            this.Controls.Add(this.player1Score);
            this.Controls.Add(this.player1ScoreBoardLabel);
            this.Controls.Add(this.guessButton);
            this.Controls.Add(this.wordGuessLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hangman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label wordGuessLabel;
        private System.Windows.Forms.Button guessButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label player1ScoreBoardLabel;
        private System.Windows.Forms.Label player1Score;
        private System.Windows.Forms.Label something;
        private System.Windows.Forms.Label player2ScoreBoardLabel;
        private System.Windows.Forms.Label player2Score;
        private System.Windows.Forms.Label usedLettersLabel;
        private System.Windows.Forms.TextBox usedLettersBox;
    }
}