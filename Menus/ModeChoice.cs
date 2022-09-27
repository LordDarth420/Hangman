using System;
using System.IO;
using System.Windows.Forms;

namespace Hangman
{
    public partial class ModeChoice : Form
    {
        private UserSettings settings;
        private Options options;
        public ModeChoice()
        {
            InitializeComponent();
            settings = new UserSettings();
            options = new Options();
        }
        private void startButton_Clicked(object sender, EventArgs e)
        {
            if (twoPlayers.Checked)
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Hide();
                }
                WordPrompt wordPrompt = new WordPrompt(1);
                wordPrompt.Show();
            }
            else if (onePlayer.Checked)
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Hide();
                }
                string filePath = settings.FilePath;

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Не мога да намеря файла, в който се съдържат думите.", "Файлът липсва", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Dispose();
                    new Intro().Show();
                }
                else if (IsTextFileEmpty(filePath))
                {
                    MessageBox.Show("Няма думи в посочения файл.", "Липсват думи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Dispose();
                    new Intro().Show();
                }
                else
                {
                    new Game().Show();
                }
                
            }
            else
            {
                MessageBox.Show("Изберете режим на игра.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private static bool IsTextFileEmpty(string fileName)
        {
            var info = new FileInfo(fileName);
            if (info.Length == 0)
                return true;

            if (info.Length < 6)
            {
                var content = File.ReadAllText(fileName);
                return content.Length == 0;
            }
            return false;
        }
    }
}
