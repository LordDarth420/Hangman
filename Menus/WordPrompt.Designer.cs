
namespace Hangman
{
    partial class WordPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordPrompt));
            this.label1 = new System.Windows.Forms.Label();
            this.wordBox = new System.Windows.Forms.TextBox();
            this.playerDisplay = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(54, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Въведи тайно своята дума:";
            // 
            // wordBox
            // 
            this.wordBox.Location = new System.Drawing.Point(24, 125);
            this.wordBox.MaxLength = 28;
            this.wordBox.Name = "wordBox";
            this.wordBox.PasswordChar = '*';
            this.wordBox.Size = new System.Drawing.Size(267, 23);
            this.wordBox.TabIndex = 1;
            this.wordBox.UseSystemPasswordChar = true;
            this.wordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // playerDisplay
            // 
            this.playerDisplay.AutoSize = true;
            this.playerDisplay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerDisplay.Location = new System.Drawing.Point(125, 9);
            this.playerDisplay.Name = "playerDisplay";
            this.playerDisplay.Size = new System.Drawing.Size(0, 19);
            this.playerDisplay.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(116, 170);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // WordPrompt
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 215);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.playerDisplay);
            this.Controls.Add(this.wordBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WordPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дума";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WordPrompt_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wordBox;
        private System.Windows.Forms.Label playerDisplay;
        private System.Windows.Forms.Button okButton;
    }
}