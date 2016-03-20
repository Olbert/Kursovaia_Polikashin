using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
namespace Kursovaia_Gubaidullin
{
    class Controller
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        void Main()
        {
            Model m = new Model();
            m = Memory.Load(??);
            ConectToView(m);
        }
        static Questions View;
        void ConectToView(Model m)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            View = new Questions(m);
            Application.Run(View);
        }
        Model Model;
        string path = Directory.GetCurrentDirectory();
        string Dirpath = Directory.GetCurrentDirectory();
        string DialogPath;
        public string CCompilerPath = null, SCompilerPath = null, PCompilerPath = null;
        public bool GameTheory;
        int CurQuestion = 0, CurPart = 0, CurAnswer = 0;
        int[][] History;
       
        private void OK_Click(object sender, EventArgs e)
        {

            bool b = false;
            if (CurPart < Model.PartsNUM)
            {
                if (CurQuestion < Model.S[CurPart].QuestionsNUM)
                {
                    if (CurQuestion != Model.S[CurPart].Prog.Dir)
                    {
                        int k = 0;
                        while (k < Model.S[CurPart].M[CurQuestion].AnswersNUM && !b)
                        {
                            if (View.Answer.Text.Contains(Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer))
                            {
                                b = true;
                                History[CurPart][CurQuestion] = k;
                            }
                            k++;
                        }
                        if (GameTheory)
                        {
                            Random rnd = new Random(DateTime.Now.Millisecond);
                            int a = rnd.Next(0, 8);
                            if (a == 2)
                                RandomSelected(k - 1);
                        }
                        if (b == false)
                            MessageBox.Show("Такой ответ не поддерживается, загляните в справку");
                        else
                        {
                            ShowNextQuestion();
                        }
                    }
                    else
                    {
                        Protokol.Text += "ДС: " + Question.Text + '\n' + "Пользователь: " + Answer.Text + '\n';
                        Model.S[CurPart].M[CurQuestion].R = new Model.Element.Message.Answers[1];
                        Model.S[CurPart].M[CurQuestion].R[0] = new Model.Element.Message.Answers();
                        Model.S[CurPart].M[CurQuestion].R[0].Answer = Answer.Text;
                        CurQuestion++;
                        MessageBox.Show("Диалог окончен, идет построение системы...");
                        Program Prog = new Program(Model, CurPart);
                        Prog.MakeProgram(Dirpath);
                        MessageBox.Show("Система построена");
                        CurPart++;
                    }
                }
            }
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
        public class Program
        {

            public string Language;
            public string Name;
            public string Start;
            public string End;
            public string Dir;
            public string[] IN = new string[2];
            public string[] OUT = new string[2];
            // public string[] Utility = new string[5];
            public string[] Task;

            public Program(Model Model, int CurPart)
            {
                int j = 0;
                int k = Model.S[CurPart].Prog.Language.x;
                int z = Model.S[CurPart].Prog.Language.y;
                Language = Model.S[CurPart].M[k].R[z].Answer;
                k = Model.S[CurPart].Prog.Dir;
                Dir = Model.S[CurPart].M[k].R[0].Answer;
                k = Model.S[CurPart].Prog.IN.x;
                z = Model.S[CurPart].Prog.IN.y;
                if (Model.S[CurPart].M[k].R[z].Answer == "Файл")
                {
                    IN[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[2];
                    IN[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[3];
                }
                else
                {
                    IN[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[0];
                    IN[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[1];
                }
                k = Model.S[CurPart].Prog.OUT.x;
                z = Model.S[CurPart].Prog.OUT.y;
                if (Model.S[CurPart].M[k].R[z].Answer == "Файл")
                {
                    OUT[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[2];
                    OUT[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[3];
                }
                else
                {
                    OUT[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[0];
                    OUT[0] = Model.S[CurPart].M[k].R[z].Source[j].Text[1];
                }
                k = Model.S[CurPart].Prog.Task.x;
                z = Model.S[CurPart].Prog.Task.y;
                Name = Model.S[CurPart].M[k].R[z].Answer;
                switch (Language)
                {
                    case ("C++"):
                        {
                            j = 0;
                            Task = Model.S[CurPart].M[k].R[z].Source[j].Text;
                            Start = "#include <fstream> \n #include <iostream>";
                            End = "\n }";
                        }
                        break;
                    case ("C#"):
                        {
                            j = 1;
                            Task = Model.S[CurPart].M[k].R[z].Source[j].Text;
                            Start = "using System;\n using System.IO;\n using System.Linq; \n namespace Sample \n { \n class Program \n { \n static void Main(string[] args) \n { \n";
                            End = "\n }\n }\n }";
                        }
                        break;
                };

            }

            public void MakeProgram(string DirPath)
            {
                string code = null;
                code += Start + '\n';
                code += IN[0] + '\n';
                code += OUT[0] + '\n';
                code += Task;
                code += IN[0] + '\n';
                code += OUT[0] + '\n';
                code += End + '\n';

                switch (this.Language)
                {
                    case "C++":
                        {
                            if (!Directory.Exists(DirPath + "\\" + this.Dir))
                            {
                                Directory.CreateDirectory(DirPath + "\\" + this.Dir);
                                if (!File.Exists(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp"))
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp", code);
                                else
                                {
                                    File.Delete(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp");
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp", code);
                                }

                            }
                            else
                            {
                                Directory.CreateDirectory(DirPath + "\\" + this.Dir);
                                if (!File.Exists(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp"))
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp", code);
                                else
                                {
                                    File.Delete(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp");
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cpp", code);
                                }
                            }
                        }
                        break;
                    case "C#":
                        {
                            if (!Directory.Exists(DirPath + "\\" + this.Dir))
                            {
                                Directory.CreateDirectory(DirPath + "\\" + this.Dir);
                                if (!File.Exists(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs"))
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs", code);
                                else
                                {
                                    File.Delete(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs");
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs", code);
                                }
                            }
                            else
                            {
                                Directory.CreateDirectory(DirPath + "\\" + this.Dir);
                                if (!File.Exists(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs"))
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs", code);
                                else
                                {
                                    File.Delete(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs");
                                    File.WriteAllText(DirPath + "\\" + this.Dir + "\\" + this.Name + ".cs", code);
                                }
                            }
                        }
                        break;
                }

            }
        }
        private void CreateDialog_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Creator(this);
            f.Show();
        }

        private void OpenDialog_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "KUR|*.kur";
                openFileDialog1.Title = "Select a kur File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DialogPath = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            Model = new Model();
            Model = Memory.Load(DialogPath);

            Answer.Clear();
            Question.Text = Model.S[CurPart].M[CurQuestion].V;
            string[] str = new string[Model.S[CurPart].M[CurQuestion].R.Length];
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Model.S[CurPart].M[CurQuestion].R[i].Answer;
            }
            AvaliableAnswers.Items.AddRange(str);
            History = new int[Model.PartsNUM][];
            for (int i = 0; i < Model.PartsNUM; i++)
                History[i] = new int[Model.S[i].QuestionsNUM];


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

    }
}
