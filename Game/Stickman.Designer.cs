
namespace Hangman
{
    partial class Stickman
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
            this.executionScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.executionScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // executionScreen
            // 
            this.executionScreen.Image = global::Hangman.Properties.Resources.beginning;
            this.executionScreen.Location = new System.Drawing.Point(12, 12);
            this.executionScreen.Name = "executionScreen";
            this.executionScreen.Size = new System.Drawing.Size(256, 331);
            this.executionScreen.TabIndex = 0;
            this.executionScreen.TabStop = false;
            // 
            // Stickman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 355);
            this.Controls.Add(this.executionScreen);
            this.Name = "Stickman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stickman";
            ((System.ComponentModel.ISupportInitialize)(this.executionScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox executionScreen;
    }
}