
namespace Hangman
{
    partial class OptionsPlayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.onePlayer = new System.Windows.Forms.RadioButton();
            this.twoPlayers = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(74, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Режим на игра:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(95, 360);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(124, 45);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "СТАРТ";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Clicked);
            // 
            // onePlayer
            // 
            this.onePlayer.AutoSize = true;
            this.onePlayer.Location = new System.Drawing.Point(38, 172);
            this.onePlayer.Name = "onePlayer";
            this.onePlayer.Size = new System.Drawing.Size(68, 19);
            this.onePlayer.TabIndex = 3;
            this.onePlayer.TabStop = true;
            this.onePlayer.Text = "1 Играч";
            this.onePlayer.UseVisualStyleBackColor = true;
            // 
            // twoPlayers
            // 
            this.twoPlayers.AutoSize = true;
            this.twoPlayers.Location = new System.Drawing.Point(38, 212);
            this.twoPlayers.Name = "twoPlayers";
            this.twoPlayers.Size = new System.Drawing.Size(74, 19);
            this.twoPlayers.TabIndex = 4;
            this.twoPlayers.TabStop = true;
            this.twoPlayers.Text = "2 Играча";
            this.twoPlayers.UseVisualStyleBackColor = true;
            // 
            // OptionsPlayer
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 450);
            this.Controls.Add(this.twoPlayers);
            this.Controls.Add(this.onePlayer);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
            this.Name = "OptionsPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Опции";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RadioButton onePlayer;
        private System.Windows.Forms.RadioButton twoPlayers;
    }
}