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
            LoadView();
        }
        static View View;
        void LoadView()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            View = new View();
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

        static public void GetModel(View V)
        {
            Model M = Memory.Load();
            StartDialog(M, V);
        }
        void SendQuestion() //раздеинть
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
                            if (System.Windows.Forms.View.Answer.Text.Contains(Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer))
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
        static public void StartDialog(Model M, View V)
        {


        }        
    }
}
