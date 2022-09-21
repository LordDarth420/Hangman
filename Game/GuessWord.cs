using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class GuessWord : Form
    {
        private string guess;
        public string GuessedWord
        {
            get { return this.guess; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else { this.guess = value; }
            }
        }
        public GuessWord()
        {
            InitializeComponent();
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string word = wordBox.Text.ToString().Trim();
            word = Regex.Replace(word, @"\s+", " ");
            try
            {
                GuessedWord = word;
                (Application.OpenForms["Game"] as Game).GuessWholeWord();
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("Няма написана дума!", "Полето е празно", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }
    }
}
