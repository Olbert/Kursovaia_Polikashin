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
            public ProgramInfo Prog = new ProgramInfo();
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
