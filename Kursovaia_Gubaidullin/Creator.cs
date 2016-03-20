using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kursovaia_Gubaidullin
{

    public partial class Creator : Form
    {
        public int i = 0, k = 0;
        public bool NEW = true;
        public bool CanSimpleViewed = true;
        Form ParentForm;
        int PartsNUM = 0;
        int QuestionNUM = 0;
        int CurrentLine = 2;
        

        public Creator(Form f)
        {
            InitializeComponent();
            ParentForm = f;
            SourceBox.Text += '\n' + '\n';

        }

        private void SimpleView_Click(object sender, EventArgs e)//сделано
        {
            if (NEW)
            {
                SourceBox.Visible = false;
            }
            else
            {
                if (CanSimpleViewed)
                {
                    SourceBox.Visible = false;
                }
                else
                    MessageBox.Show("Данный сценарий не может быть представлен в простом виде");
            }
        }

        private void SourceView_Click(object sender, EventArgs e)//сделано
        {
            SourceBox.Visible = true;
        }

        private void NextPart_Click(object sender, EventArgs e)
        {

            PartsNUM++;
            SourceBox.Lines[0] = Convert.ToString(PartsNUM);
            SourceBox.Lines[CurrentLine - 1] = Convert.ToString(QuestionNUM);
            QuestionNUM = 0;

            SourceBox.Text += QuestionBox.Text + '\n';      // Вопрос
            CurrentLine++;
            SourceBox.Text += Convert.ToString(SourceGrid.RowCount) + '\n';   //Количество Всеможножных ответов
            CurrentLine++;
            for (int z = 0; z < SourceGrid.RowCount; z++)
            {
                SourceBox.Text += Convert.ToString(SourceGrid.Rows[z].Cells[0].Value) + '\n'; //Ответ
                CurrentLine++;
                SourceBox.Text += Convert.ToString(SourceGrid.Rows[z].Cells[0].Value) + '\n'; //Переход
                CurrentLine++;
                SourceBox.Text += "false" + '\n'; // Exist-ы кодов
                CurrentLine++;
                SourceBox.Text += "false" + '\n';
                CurrentLine++;
            }
            QuestionBox.Clear();
            SourceGrid.Rows.Clear();
        }


        private void NextQuestion_Click(object sender, EventArgs e)//сделано
        {

            QuestionNUM++;
            SourceBox.Text += QuestionBox.Text + '\n';      // Вопрос
            CurrentLine++;
            SourceBox.Text += Convert.ToString(SourceGrid.RowCount) + '\n';   //Количество Всеможножных ответов
            CurrentLine++;
            for (int z = 0; z < SourceGrid.RowCount; z++)
            {
                SourceBox.Text += Convert.ToString(SourceGrid.Rows[z].Cells[0].Value) + '\n'; //Ответ
                CurrentLine++;
                SourceBox.Text += Convert.ToString(SourceGrid.Rows[z].Cells[0].Value) + '\n'; //Переход
                CurrentLine++;
                SourceBox.Text += "false" + '\n'; // Exist-ы кодов
                CurrentLine++;
                SourceBox.Text += "false" + '\n';
                CurrentLine++;
            }
            QuestionBox.Clear();
            SourceGrid.Rows.Clear();
        }

        private void NewDialog_Click(object sender, EventArgs e)//сделано
        {
            SourceBox.Clear();
            QuestionBox.Clear();
            SourceGrid.Rows.Clear();
            NEW = true;
        }

        private void EditDialog_Click(object sender, EventArgs e)//сделано
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "KUR|*.kur";
                openFileDialog1.Title = "Select a kur File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = openFileDialog1.FileName;
                    System.IO.StreamReader file = new System.IO.StreamReader(path, Encoding.Default);
                    SourceBox.Text = file.ReadToEnd();
                    file.Close();
                    file = new System.IO.StreamReader(path, Encoding.Default);
                    string s = null;
                    for (int i = 0; i < 7; i++)
                        s = file.ReadLine();
                    CanSimpleViewed = Convert.ToBoolean(s);
                    file.Close();
                    NEW = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила заполнения см. в Документации к проекту");
        }

        private void OK_Click(object sender, EventArgs e)//сделано
        {
            
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "KUR|*.kur";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        StreamWriter w = new StreamWriter(myStream);
                        w.Write(SourceBox.Text);
                        myStream.Close();
                    }
                }
                ParentForm.Show();
                this.Close();
            }
        }

    }

}