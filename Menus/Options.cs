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
    public partial class Options : Form
    {
        private UserSettings settings;
        public Options()
        {
            InitializeComponent();
            settings = new UserSettings();
            filePathBox.Text = settings.FilePath;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
                openFileDialog.Filter = "txt файлове (*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                
                DialogResult dialogResult = openFileDialog.ShowDialog();

                if(dialogResult == DialogResult.OK)
                {
                    filePathBox.Text = openFileDialog.FileName;
                    settings.FilePath = filePathBox.Text;
                }
            }
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Save();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            settings.Save();
            this.Dispose();
        }
    }
}
