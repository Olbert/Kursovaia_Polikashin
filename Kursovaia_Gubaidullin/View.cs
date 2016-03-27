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
using System.Threading;
namespace Kursovaia_Gubaidullin
{

    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader("Kursovaia.Info");
                CppCompilerPath = file.ReadLine();
                SharpCompilerPath = file.ReadLine();
                //PascalCompilerPath = file.ReadLine();
                GameTheory = Convert.ToBoolean(file.ReadLine());
                file.Close();
            }
            catch (Exception ex) { }
        }
        private void OK_Click(object sender, EventArgs e)
        {

            
        }
        void Prepare ()
        {
            Answer.Clear();
            Question.Text = Model.S[CurPart].M[CurQuestion].V;
            string[] str = new string[Model.S[CurPart].M[CurQuestion].R.Length];
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Model.S[CurPart].M[CurQuestion].R[i].Answer;
            }
            AvaliableAnswers.Items.AddRange(str);
            
        }
        void RandomSelected(int k)
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            int a = rnd.Next(0, 2);
            switch (a)
            {
                case 0:
                    {
                        if (k < Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer.Length - 1)
                            Question.Text = "Быть может лучше выбрать " + Model.S[CurPart].M[CurQuestion].R[CurAnswer + 1].Answer + "?";
                        else
                            Question.Text = "Быть может лучше выбрать" + Model.S[CurPart].M[CurQuestion].R[CurAnswer - 1].Answer + "?";
                    }
                    break;
                case 1:
                    {
                        if (k < Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer.Length - 1)
                            Question.Text = "Лучше выбрать вариант: " + Model.S[CurPart].M[CurQuestion].R[CurAnswer + 1].Answer;
                        else
                            Question.Text = "Лучше выбрать вариант: " + Model.S[CurPart].M[CurQuestion].R[CurAnswer - 1].Answer;
                    }
                    break;
                case 2:
                    {
                        if (k < Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer.Length - 1)
                            Question.Text = "Система советует выбрать" + Model.S[CurPart].M[CurQuestion].R[CurAnswer + 1].Answer;
                        else
                            Question.Text = "Система советует выбрать" + Model.S[CurPart].M[CurQuestion].R[CurAnswer - 1].Answer;
                    }
                    break;
            }
            Answer.Text = "Введите ответ еще раз";

        }//А надо?
        
        private void CreateDialog_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Creator(this);
            f.Show();
        }

        private void OpenDialog_Click(object sender, EventArgs e)
        {
            Controller.GetModel(this);;
        }

        private void AvaliableAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Answer.Text = AvaliableAnswers.SelectedItem.ToString();
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Курсовая работа \n ст. 09 - 411 \n Губайдуллина Альберта\n Модель: Теория игр ", "О программе");
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Settings(this);
            f.Show();
        }

        void ShowNextQuestion()
        {
            try
            {
                Protokol.Text += "ДС: " + Question.Text + '\n' + "Пользователь: " + Answer.Text + '\n';

                int n = Convert.ToInt32(QuestionNum.Text);
                n++;
                QuestionNum.Text = Convert.ToString(n);

                Answer.Clear();
                AvaliableAnswers.Items.Clear();

                CurQuestion = Model.S[CurPart].M[CurQuestion].R[CurAnswer].Next;
                Question.Text = Model.S[CurPart].M[CurQuestion].V;
                string[] str = new string[Model.S[CurPart].M[CurQuestion].R.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = Model.S[CurPart].M[CurQuestion].R[i].Answer;
                }
                AvaliableAnswers.Items.AddRange(str);
            }
            catch (Exception ex)
            { }
        }
        public static Answer SetQuestion(Message Q)
        {
            

    }

}

}
