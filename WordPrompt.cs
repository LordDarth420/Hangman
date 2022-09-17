using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Hangman
{
    public partial class WordPrompt : Form
    {
        private int currentPlayer;
        private string word;
        private List<string> partsOfWord;
        private Dictionary<int, int> _scoreBoard;
        public WordPrompt(int player)
        {
            _scoreBoard = new Dictionary<int, int>();
            currentPlayer = player;
            InitializeComponent();
            
            if(currentPlayer == 1)
            {
                playerDisplay.Text = "Играч 2,";
            }
            else { playerDisplay.Text = "Играч 1,"; }
            _scoreBoard.Add(1, 0);
            _scoreBoard.Add(2, 0);
        }
        public WordPrompt(int player, Dictionary<int, int> scoreBoard)
        {
            currentPlayer = player;
            InitializeComponent();

            if (currentPlayer == 1)
            {
                playerDisplay.Text = "Играч 2,";
            }
            else { playerDisplay.Text = "Играч 1,"; }
            _scoreBoard = scoreBoard;
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            partsOfWord = new List<string>();
            word = wordBox.Text.ToString().Trim();
            word = Regex.Replace(word, @"\s+", " ");

            partsOfWord = word.Split(' ').ToList();

            if(partsOfWord.Count == 1 && word.Length > 17)
            {
                MessageBox.Show("Думата е твърде дълга и не може да бъде на един ред.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(String.IsNullOrWhiteSpace(word))
            {
                MessageBox.Show("Трябва да въведеш дума.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(word.Length < 3)
            {
                MessageBox.Show("Думата трябва да има повече от три букви.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Game game = new Game(currentPlayer, word, _scoreBoard);
                this.Hide();
                game.Show();
            }
        }
        private void WordPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideInactiveWindows();
            Intro intro = new Intro();
            intro.Show();
        }


        private static void HideInactiveWindows()
        {
            foreach (Form f in Application.OpenForms)
            {
                f.Hide();
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.CapsLock)
            {
                e.SuppressKeyPress = true;
            }
        }
    }                                                                               
}
