using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaia_Gubaidullin
{
    public partial class Settings : Form
    {
        Questions ParentForm = null;
        public string CompilerPath = null;
        public Settings(Questions f)
        {
            InitializeComponent();
            ParentForm = f;
        }

        private void BrowseSharp_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "EXE|*.exe";
                openFileDialog1.Title = "Select a exe File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   ParentForm.SCompilerPath = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
        private void BrowseCpp_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "EXE|*.exe";
                openFileDialog1.Title = "Select a exe File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ParentForm.CCompilerPath = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void Back_Click(object sender, EventArgs e)
        {
            string game = "0";
            if (GameTheory.Checked)
                game = "1";

            if (SCompiler.Text.Length != 0)
            {
                string[] lines = { CCompiler.Text, SCompiler.Text, game };
                System.IO.File.WriteAllLines("Kursovaia.Info", lines);
            }
            ParentForm.Show();
            this.Close();
        }


    }
}
