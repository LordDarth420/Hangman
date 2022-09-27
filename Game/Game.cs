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
using System.IO;

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
        private GuessWord guessWindow;
        private UserSettings settings;
        //constructor used for twoPlayerMode
        public Game(int currentPlayer, string word, Dictionary<int, int> scoreBoard)
        {
            twoPlayerMode = true;
            InitializeComponent();
            _word = null;


            usedLetters = new List<char>();
            _word = word;
            _scoreBoard = scoreBoard;
            _currentPlayer = currentPlayer;

            player1Score.Text = scoreBoard.ElementAt(0).Value.ToString();
            player2Score.Text = scoreBoard.ElementAt(1).Value.ToString();
            DisplayWordOnScreen();
            guessWindow = new GuessWord();
            Font font = new Font("Seque UI", 14, FontStyle.Bold);
            if (_currentPlayer == 1)
            {
                player1ScoreBoardLabel.Font = font;
            }
            else
            {
                player2ScoreBoardLabel.Font = font;
            }

            StartHanging();
        }

        //constructor for singleplayer
        public Game()
        {
            //get word from database of some kind - text file

            InitializeComponent();
            _word = null;
            settings = new UserSettings();
            twoPlayerMode = false;
            usedLetters = new List<char>();
            stickMan = new Stickman();
            guessWindow = new GuessWord();
            scoreBoardPanel.Visible = false;
            string filePath = settings.FilePath;

            int lineCount = 0;
            using (var reader = File.OpenText(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            int randomLineNum = new Random(Guid.NewGuid().GetHashCode()).Next(1, lineCount - 1);
            _word = File.ReadLines(filePath).ElementAtOrDefault(randomLineNum).ToString();
            DisplayWordOnScreen();
            StartHanging();
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
            int currentPos = 0;
            //input letters
            for (int i = 0; i < partsOfWord.Count; i++)
            {
                for (int j = 0; j < partsOfWord[i].Length; j++)
                {
                    if (j == 0 || partsOfWord[i][j] == partsOfWord[i][0] || j == partsOfWord[i].Length - 1)
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
            char letter;
            try
            {
                letter = char.Parse(textBox1.Text.ToString().ToLower());
            }
            catch (FormatException)
            {
                return;
            }

            if (_word.Contains(letter))
            {
                for (int i = 0; i < _word.Length; i++)
                {
                    if (letter == _word[i])
                    {
                        labels[i].Text = _word[i].ToString();
                    }
                }
                textBox1.Text = "";

                bool guessedAllLetters = labels.Where(l => l.Text.Equals("?")).ToArray().Length == 0;
                if (guessedAllLetters)
                {
                    GuessedAllLetters();
                }
            }
            else
            {
                WrongLetter(letter);
            }
            textBox1.Text = "";
        }

        private void GuessedAllLetters()
        {
            if (twoPlayerMode)
            {
                StringBuilder sb = new StringBuilder();

                switch (_currentPlayer)
                {
                    case 1:
                        sb.Append("Играч 1, ");
                        break;
                    case 2:
                        sb.Append("Играч 2, ");
                        break;
                }
                sb.Append("ти позна думата! Продължаване на играта?");
                DialogResult dialog = MessageBox.Show(sb.ToString(), "Успех!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_currentPlayer == 1) { _currentPlayer = 2; _scoreBoard[1]++; }
                else { _currentPlayer = 1; _scoreBoard[2]++; }
                switch (dialog)
                {
                    case DialogResult.Yes:

                        WordPrompt prompt = new WordPrompt(_currentPlayer, _scoreBoard);
                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        prompt.Show();
                        break;
                    case DialogResult.No:
                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        ShowResults();
                        Intro intro = new Intro();
                        intro.Show();
                        break;
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Ти позна думата! Нова дума?", "Успех", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                switch (dialog)
                {
                    case DialogResult.Yes:
                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        Game newGame = new Game();
                        newGame.Show();

                        break;

                    case DialogResult.No:
                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        Intro intro = new Intro();
                        intro.Show();
                        break;
                }
            }
        }
        private void WrongLetter(char letter)
        {
            bool playerLost = stickMan.Penalize();
            if (playerLost)
            {
                PlayerLost();
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
        private void PlayerLost()
        {
            if (twoPlayerMode)
            {
                StringBuilder stringBuilder = new StringBuilder();

                switch (_currentPlayer)
                {
                    case 1:
                        stringBuilder.Append("Играч 1, ");
                        break;
                    case 2:
                        stringBuilder.Append("Играч 2, ");
                        break;
                }
                stringBuilder.Append("ти сгреши! Продължаване на играта?");
                DialogResult dialog = MessageBox.Show(stringBuilder.ToString(), "Провал!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (_currentPlayer == 1) { _currentPlayer = 2; _scoreBoard[1]++; }
                else { _currentPlayer = 1; _scoreBoard[2]++; }

                switch (dialog)
                {
                    case DialogResult.Yes:
                        if (_currentPlayer == 1) { _currentPlayer = 2; _scoreBoard[2]++; }
                        else { _currentPlayer = 1; _scoreBoard[1]++; }
                        WordPrompt prompt = new WordPrompt(_currentPlayer, _scoreBoard);
                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        prompt.Show();
                        break;
                    case DialogResult.No:
                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        ShowResults();
                        Intro intro = new Intro();
                        intro.Show();
                        break;
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Ти загуби! Нов опит?", "Провал", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                switch (dialog)
                {
                    case DialogResult.Yes:

                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        Game newGame = new Game();
                        newGame.Show();
                        break;
                    case DialogResult.No:
                        foreach (Form f in Application.OpenForms)
                        {
                            f.Hide();
                        }
                        this.Dispose();
                        Intro intro = new Intro();
                        intro.Show();
                        break;
                }
            }
        }
        private void OpenGuessWindow(object sender, EventArgs e)
        {
            guessWindow.ShowDialog();
            return;
        }
        public void GuessWholeWord()
        {
            string attempt = guessWindow.GuessedWord.ToLower();
            guessWindow.Hide();
            if (attempt.Equals(_word.ToLower()))
            {
                for (int i = 0; i < _word.Length; i++)
                {
                    labels[i].Text = _word[i].ToString();
                }
                GuessedAllLetters();
            }
            else
            {
                stickMan.HangImmediately();
                PlayerLost();
            }

        }
        private void ShowResults()
        {
            StringBuilder sb = new StringBuilder();
            if (_scoreBoard[1] > _scoreBoard[2])
            {
                sb.Append("Играч 1 печели!");
            }
            else if (_scoreBoard[1] == _scoreBoard[2])
            {
                sb.Append("Наравно сте!");
            }
            else
            {
                sb.Append("Играч 2 печели!");
            }

            MessageBox.Show(sb.ToString(), $"{_scoreBoard[1]}-{_scoreBoard[2]}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void StartHanging()
        {
            stickMan = new Stickman();
            var myScreen = Screen.FromControl(this);
            var mySecondScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(myScreen)) ?? myScreen;

            stickMan.Left = mySecondScreen.Bounds.Left;
            stickMan.Top = mySecondScreen.Bounds.Top;
            stickMan.Location = new Point(1050, 215);

            this.Location = new Point(10, 160);
            stickMan.Show();
        }
    }
}
