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
    //собирает воедино код
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
}

