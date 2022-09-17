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
using System.Reflection;

namespace Hangman
{
    public partial class Game : Form
    {
        private bool twoPlayerMode = false;
        private int _currentPlayer;
        private string _word;
        private List<string> partsOfWord;
        private List<Label> labels;
        private List<PictureBox> pictureBoxes;
        private List<char> usedLetters;
        private Dictionary<int, int> _scoreBoard;
        private Stickman stickMan;
        public Game(int currentPlayer, string word, Dictionary<int, int> scoreBoard)
        {
            twoPlayerMode = true;
            InitializeComponent();


            usedLetters = new List<char>();
            _word = word;
            _scoreBoard = scoreBoard;
            _currentPlayer = currentPlayer;

            player1Score.Text = scoreBoard.ElementAt(0).Value.ToString();
            player2Score.Text = scoreBoard.ElementAt(1).Value.ToString();
            DisplayWordOnScreen();

            Font font = new Font("Seque UI", 14, FontStyle.Bold);
            if (_currentPlayer == 1)
            {
                player1ScoreBoardLabel.Font = font;
            }
            else
            {
                player2ScoreBoardLabel.Font = font;
            }
            
            stickMan = new Stickman();
            var myScreen = Screen.FromControl(this);
            var mySecondScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(myScreen)) ?? myScreen;

            stickMan.Left = mySecondScreen.Bounds.Left;
            stickMan.Top = mySecondScreen.Bounds.Top;
            stickMan.Location = new Point(1050, 215);

            this.Location = new Point(10, 160);
            stickMan.Show();
        }
        
        public Game()
        {
            //get word from database of some kind
            InitializeComponent();
            twoPlayerMode = false;

        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Intro intro = new Intro();
            intro.Show();
            stickMan.Hide();
            this.Hide();
        }
        private void DisplayWordOnScreen()
        {
            partsOfWord = new List<string>();
            labels = new List<Label>();
            pictureBoxes = new List<PictureBox>();
            labels.Add(label1);
            pictureBoxes.Add(pictureBox1);
            partsOfWord = _word.Split(' ').ToList();

            //put labels and pictureBoxes on screen
            if (_word.Length > 3)
            {
                Label previousLabel = label1;
                PictureBox previousPictureBox = pictureBox1;
                int currentPartIndex = 0;
                bool timeForNewLine = false;
                for (int i = 1; i < _word.Length; i++)
                {
                    if (timeForNewLine)
                    {
                        timeForNewLine = false;
                    }
                    if (_word[i - 1] == ' ')
                    {
                        currentPartIndex++;
                        int sumPreviousPartsLength = 0;
                        for (int j = 0; j < currentPartIndex; j++)
                        {
                            sumPreviousPartsLength += partsOfWord[j].Length + 1;
                        }
                        if (partsOfWord[currentPartIndex].Length + sumPreviousPartsLength > 17)
                        {
                            timeForNewLine = true;
                        }
                    }
                    Label newLabel = new Label();
                    Controls.Add(newLabel);
                    panel1.Controls.Add(newLabel);
                    labels.Add(newLabel);
                    Font font = new("Segoe UI", 20);
                    newLabel.Font = font;
                    newLabel.Name = $"label{3 + i + 1}";
                    newLabel.Text = "A";
                    newLabel.AutoSize = true;
                    if (timeForNewLine)
                    {
                        newLabel.Location = new Point(16, 157);
                    }
                    else
                    {
                        int newLabel_X = previousLabel.Location.X + 54;
                        newLabel.Location = new Point(newLabel_X, previousLabel.Location.Y);

                    }
                    newLabel.Visible = true;
                    newLabel.BringToFront();

                    PictureBox newPictureBox = new PictureBox();
                    Controls.Add(newPictureBox);
                    panel1.Controls.Add(newPictureBox);
                    pictureBoxes.Add(newPictureBox);
                    newPictureBox.Image = previousPictureBox.Image;
                    newPictureBox.SizeMode = previousPictureBox.SizeMode;
                    newPictureBox.Size = new Size(previousPictureBox.Size.Width, previousPictureBox.Size.Height);
                    newPictureBox.Name = $"addedPictureBox{i + 1}";
                    if (timeForNewLine)
                    {
                        newPictureBox.Location = new Point(16, 174);
                    }
                    else
                    {
                        int newPictureBox_X = previousPictureBox.Location.X + 54;
                        newPictureBox.Location = new Point(newPictureBox_X, previousPictureBox.Location.Y);
                    }

                    newPictureBox.Visible = true;
                    newPictureBox.SendToBack();


                    previousLabel = newLabel;
                    previousPictureBox = newPictureBox;
                }
            }
            int currentPos = 0;
            //input letters
            for (int i = 0; i < partsOfWord.Count; i++)
            {          
                for(int j = 0; j < partsOfWord[i].Length; j++)
                {
                    if(j == 0 || partsOfWord[i][j] == partsOfWord[i][0] || j == partsOfWord[i].Length - 1)
                    {
                        labels[currentPos++].Text = partsOfWord[i][j].ToString();
                    }
                    else
                    {
                        labels[currentPos++].Text = "?";
                    }
                }
                if (i != partsOfWord.Count - 1)
                {
                    labels[currentPos].Visible = false;
                    pictureBoxes[currentPos++].Visible = false;
                }
            }
        }
        private void Guess(object sender, EventArgs e)
        {
            //todo: needs refactoring asap
            //method is too big, needs to be divided into two methods for win or lose
            try
            {
                char letter = char.Parse(textBox1.Text.ToString());

                if (_word.Contains(letter))
                {
                    for (int i = 0; i < _word.Length; i++)
                    {
                        if (letter == _word[i])
                        {
                            labels[i].Text = _word[i].ToString();
                        }

                        //todo: play some sound for guessing
                    }
                    textBox1.Text = "";
                }
                else
                {
                    bool playerLost = false;
                    //todo: draw one figure for incorrect guess
                    //do it in a separate window
                    if (!usedLetters.Contains(letter))
                    {
                        playerLost = stickMan.Penalize();
                    }
                    if (playerLost)
                    {
                        if (twoPlayerMode)
                        {
                            DialogResult dialog = new DialogResult();
                            if (_currentPlayer == 1)
                            {
                                dialog = MessageBox.Show("Играч 1, ти не позна думата! Продължаване на играта?", "Провал!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            }
                            else
                            {
                                dialog = MessageBox.Show("Играч 2, ти не позна думата! Продължаване на играта?", "Провал!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            }
                            if (dialog == DialogResult.Yes)
                            {
                                if (_currentPlayer == 1) { _currentPlayer = 2; _scoreBoard[2]++; }
                                else { _currentPlayer = 1; _scoreBoard[1]++; }
                                WordPrompt prompt = new WordPrompt(_currentPlayer, _scoreBoard);
                                stickMan.Hide();
                                Hide();
                                prompt.Show();
                            }
                            else
                            {
                                Intro intro = new Intro();
                                intro.Show();
                                stickMan.Hide();
                                this.Hide();
                            }
                        }
                        else
                        {
                            DialogResult dialog = MessageBox.Show("Ти не позна думата! Продължаване на играта?", "Провал!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialog == DialogResult.Yes)
                            {
                                Hide();
                                Game newGame = new Game();
                                newGame.Show();
                                stickMan.Hide();
                            }
                            else
                            {
                                Intro intro = new Intro();
                                intro.Show();
                                this.Hide();
                                stickMan.Hide();
                            }
                        }
                    }
                    else
                    {
                        if (!usedLetters.Contains(letter))
                        {
                            usedLetters.Add(letter);
                            usedLettersBox.Text = string.Join(", ", usedLetters);
                        }
                    }
                }
                if (labels.Where(l => l.Text.Equals("?")).ToList().Count == 0)
                {
                    if (twoPlayerMode)
                    {
                        DialogResult dialog = new DialogResult();
                        if (_currentPlayer == 1)
                        {
                            dialog = MessageBox.Show("Играч 1, ти позна думата! Продължаване на играта?", "Ти успя!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dialog = MessageBox.Show("Играч 2, ти позна думата! Продължаване на играта?", "Ти успя!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }
                        if (dialog == DialogResult.Yes)
                        {
                            if (_currentPlayer == 1) { _currentPlayer = 2; _scoreBoard[1]++; }
                            else { _currentPlayer = 1; _scoreBoard[2]++; }
                            WordPrompt prompt = new WordPrompt(_currentPlayer, _scoreBoard);
                            Hide();
                            stickMan.Hide();
                            prompt.Show();
                        }
                        else
                        {
                            Intro intro = new Intro();
                            intro.Show();
                            stickMan.Hide();
                            this.Hide();
                        }
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Ти позна думата! Продължаване на играта?", "Ти успя!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialog == DialogResult.Yes)                                                         
                        {
                            Hide();
                            Game newGame = new Game();
                            newGame.Show();
                        }
                        else
                        {
                            Intro intro = new Intro();
                            intro.Show();
                            this.Hide();
                        }
                    }
                }
                textBox1.Text = "";
            }
            catch(FormatException) //catch if nothing is entered
            {
                return; //do nothing
            }
            
        }
        private void EnterPress(object sender, KeyEventArgs e)
        
        {
            if(e.KeyData == Keys.Enter)
            {
                Guess(this, new EventArgs());
            }

        }

    }
}
