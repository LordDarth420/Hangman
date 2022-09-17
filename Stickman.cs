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
    public partial class Stickman : Form
    {
        private int strikes;
        public Stickman()
        {
            strikes = 0;
            InitializeComponent();
        }
        public bool Penalize()
        {
            strikes++;
            bool lost = false;
            switch(strikes)
            {
                case 1:
                    executionScreen.Image = Properties.Resources.head;
                    break;
                case 2:
                    executionScreen.Image = Properties.Resources.body;
                    break;
                case 3:
                    executionScreen.Image = Properties.Resources.right_leg;
                    break;
                case 4:
                    executionScreen.Image = Properties.Resources.left_leg;
                    break;
                case 5:
                    executionScreen.Image = Properties.Resources.right_hand;
                    break;
                case 6:
                    executionScreen.Image = Properties.Resources.dead;
                    lost = true;
                    break;
            }
            return lost;
        }
    }
}
