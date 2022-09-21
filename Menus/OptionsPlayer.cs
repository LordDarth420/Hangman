using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class OptionsPlayer : Form
    {
        public OptionsPlayer()
        {
            InitializeComponent();
        }
        private void startButton_Clicked(object sender, EventArgs e)
        {
            //TODO: make the Game form and make two subforms that inherit Game - one for AI and one for player
            if(twoPlayers.Checked) 
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Hide();
                }
                WordPrompt wordPrompt = new WordPrompt(1);
                wordPrompt.Show();
            }
            else if(onePlayer.Checked)
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Hide();
                }
                new Game().Show();
            }
            else
            {
                MessageBox.Show("Изберете режим на игра.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
