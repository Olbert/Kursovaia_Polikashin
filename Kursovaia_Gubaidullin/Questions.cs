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

    public partial class Questions : Form
    {
        Model Model;
        string path = Directory.GetCurrentDirectory();
        string Dirpath = Directory.GetCurrentDirectory();
        string DialogPath;
        public string CCompilerPath = null, SCompilerPath = null, PCompilerPath = null;
        public bool GameTheory;
        int CurQuestion = 0, CurPart = 0, CurAnswer = 0;
        int[][] History;
        public Questions()
        {
            InitializeComponent();
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader("Kursovaia.Info");
                CCompilerPath = file.ReadLine();
                SCompilerPath = file.ReadLine();
                //PCompilerPath = file.ReadLine();
                GameTheory = Convert.ToBoolean(file.ReadLine());
                file.Close();
            }
            catch (Exception ex) { }
        }
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
                            if (Answer.Text.Contains(Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer))
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
            Model = Memory.Loader(DialogPath);

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
    }

    public class Model
    {
        public int PartsNUM = 0;
        public Element[] S;// S = (s1,s2,…,sn) si – элемент сценария.
        public class Element // s = (M, P, N, T, R, S’)
        {
            public int QuestionsNUM = 0;
            public Message[] M; //M = (Mk, V, D) – описание сообщения, которым обменивается юзер с ДС.
            public Procedures P; //P определяет запускаемые прикладные процедуры пользователя.
            public ProgramInfo Prog = new ProgramInfo();
            public Scheme T;// T  - схемы выбора последующих шагов диалога.
            public class Message
            {
                public int AnswersNUM = 0;
                public Format Mk; //Mk = (mk1, mk2,…,mkn) – макета(кадры) экрана, определяющие внешний формат сообщения.mki – формат сообщения заданный в текущий момент заданного интерактивного взаимодействия.
                public string V; //V = (v1,v2,…,vn) – вопросы диалога.vi – вопрос, заданный пользователю в текущий момент хода ДВ.
                public string D; //D = (d1, d2,…, dn) -справочная информация, позволяющая пользователю в соответствующем пункте диалога получить справку о состоянии диалога, о хар-ках текущего пункта, возможные варианты ответов, значения по умолчанию. 
                public Answers[] R;//R = (sh1, sh2, …, shn) – диапазон допустимых ответов пользователя, который определяется использованием синтаксиса семантического шаблона(код) АЙЧ

                public class Format
                {

                }
                public class Answers
                {
                    public String Answer;//R = (sh1, sh2, …, shn) – диапазон допустимых ответов пользователя, который определяется использованием синтаксиса семантического шаблона(код) АЙЧ
                    public int Next; //Next = (n1, n2,…, nm) – список положительных чисел mi, определяющий последующий шаг диалога.
                    public Command[] Source;
                    public class Command
                    {
                        public bool Exist;
                        public String Language;
                        public String Type;
                        public int[] Length = new int[2];
                        public String[] Text = new String[2];
                    }
                }

            }
            public class Procedures
            {
            }
            public class Scheme
            {
            }
        }

        public class ProgramInfo
        {
            public static int LanguageNUM;
            public Pair Language;
            public int Dir;
            public Pair Name;
            public Pair IN;
            public Pair OUT;
            // public string[] Utility = new string[5];
            public Pair Task;
        }

        public Model()
        {

        }
        public void IN(int i, int k, int z, int j, StreamReader input)
        {
            S[i].M[k].R[z].Source[j].Length = new int[4];  //Console1,Console2, File1,File2
            S[i].M[k].R[z].Source[j].Text = new string[4];
            for (int t = 0; t < 4; t++)
            {
                S[i].M[k].R[z].Source[j].Length[t] = Convert.ToInt32(input.ReadLine());
                for (int s = 0; s < S[i].M[k].R[z].Source[j].Length[t]; s++)
                    S[i].M[k].R[z].Source[j].Text[t] += input.ReadLine() + '\n';
            }
        }
        public bool OK(int CurPart, int CurQuestion, int CurAnser, string answer)
        {
            if (CurAnser != 12)
            {
                for (int i = 1; i < S[CurPart].M[CurQuestion].R[CurAnser].Answer.Length; i++)
                    if (S[CurPart].M[CurQuestion].R[CurAnser].Answer == answer)
                        return true;
                return false;
            }
            else
            {
                DirectoryInfo d = new DirectoryInfo(answer);
                if (d.Exists)
                    return true;
                else
                    return false;
            }
        }
    }
    public class Pair
    {
        internal int x { get; }
        internal int y { get; }
        public Pair(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }
    public class Trio
    {
        internal int x { get; }
        internal int y { get; }
        internal int z { get; }
        public Trio(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
    public class Memory
    {
        public void Saver(Model m)
        {

        }
        public static Model Loader(string path)
        {
            Model m = new Model();
            try
            {
                StreamReader input = new StreamReader(path, Encoding.Default);
                m.PartsNUM = Convert.ToInt32(input.ReadLine()); //Количество Частей диалога
                m.S = new Model.Element[m.PartsNUM];
                for (int i = 0; i < m.PartsNUM; i++)
                {
                    m.S[i] = new Model.Element();
                    m.S[i].QuestionsNUM = Convert.ToInt32(input.ReadLine());   //Количество вопросов
                    m.S[i].M = new Model.Element.Message[m.S[i].QuestionsNUM];

                    for (int k = 0; k < m.S[i].QuestionsNUM - 1; k++)
                    {
                        m.S[i].M[k] = new Model.Element.Message();

                        m.S[i].M[k].V = input.ReadLine();

                        m.S[i].M[k].AnswersNUM = Convert.ToInt32(input.ReadLine()); //Количество Всеможножных ответов
                        m.S[i].M[k].R = new Model.Element.Message.Answers[m.S[i].M[k].AnswersNUM];
                        for (int z = 0; z < m.S[i].M[k].AnswersNUM; z++)
                        {
                            m.S[i].M[k].R[z] = new Model.Element.Message.Answers();

                            m.S[i].M[k].R[z].Answer = input.ReadLine();
                            m.S[i].M[k].R[z].Next = Convert.ToInt32(input.ReadLine());
                            m.S[i].M[k].R[z].Source = new Model.Element.Message.Answers.Command[2];
                            for (int j = 0; j < 2; j++)                                                     // 2 фиксированных языка
                            {
                                m.S[i].M[k].R[z].Source[j] = new Model.Element.Message.Answers.Command();

                                string sss = input.ReadLine();
                                m.S[i].M[k].R[z].Source[j].Exist = Convert.ToBoolean(sss);
                                if (m.S[i].M[k].R[z].Source[j].Exist)
                                {
                                    m.S[i].M[k].R[z].Source[j].Type = input.ReadLine();
                                    switch (m.S[i].M[k].R[z].Source[j].Type)
                                    {
                                        case "Task":
                                            {
                                                m.S[i].M[k].R[z].Source[j].Length = new int[2];
                                                m.S[i].M[k].R[z].Source[j].Text = new string[2];
                                                m.S[i].Prog.Task = new Pair(k, z);
                                                m.S[i].M[k].R[z].Source[j].Language = input.ReadLine();
                                                m.S[i].M[k].R[z].Source[j].Length[0] = Convert.ToInt32(input.ReadLine());
                                                for (int s = 0; s < m.S[i].M[k].R[z].Source[j].Length[0]; s++)
                                                    m.S[i].M[k].R[z].Source[j].Text[0] += input.ReadLine() + '\n';
                                            }
                                            break;
                                        case "IN":
                                            {
                                                m.IN(i, k, z, j, input);
                                                m.S[i].Prog.IN = new Pair(k, z);
                                            }
                                            break;
                                        case "OUT":
                                            {

                                                m.IN(i, k, z, j, input);
                                                m.S[i].Prog.OUT = new Pair(k, z);
                                            }
                                            break;
                                        case "Language":
                                            {
                                                m.S[i].M[k].R[z].Source[j].Length = new int[2];
                                                m.S[i].M[k].R[z].Source[j].Text = new string[2];
                                                m.S[i].Prog.Language = new Pair(k, z);
                                                m.S[i].M[k].R[z].Source[j].Text[0] += input.ReadLine() + '\n';
                                            }
                                            break;
                                        case "DIR":
                                            {
                                                m.S[i].Prog.Dir = k;
                                            }
                                            break;
                                    }
                                }
                            }

                        }
                    }
                    int ks = m.S[i].QuestionsNUM - 1;
                    m.S[i].M[ks] = new Model.Element.Message();
                    m.S[i].M[ks].V = input.ReadLine();
                    m.S[i].M[ks].R = new Model.Element.Message.Answers[1];
                    m.S[i].M[ks].R[0] = new Model.Element.Message.Answers();
                    m.S[i].M[ks].R[0].Source = new Model.Element.Message.Answers.Command[2];
                    m.S[i].M[ks].R[0].Source[0] = new Model.Element.Message.Answers.Command();
                    m.S[i].M[ks].R[0].Source[0].Text = new string[2];
                    m.S[i].M[ks].R[0].Source[0].Text[0] = input.ReadLine();
                    m.S[i].Prog.Dir = ks;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия файла" + ex, "Ошибка!");
            }

            return m;
        }
    }
    public class Controller
    {

    }
}
