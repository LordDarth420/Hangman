using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            OptionsPlayer options = new OptionsPlayer();
            options.Show();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
        private void Intro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
