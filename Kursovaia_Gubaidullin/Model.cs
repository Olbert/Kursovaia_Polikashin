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
}
