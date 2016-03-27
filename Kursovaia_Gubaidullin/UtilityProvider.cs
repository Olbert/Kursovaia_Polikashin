using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaia_Gubaidullin
{
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
    public class Message
    {
        public int AnswersNUM = 0;
        public string V; //вопрос диалога
        public string D; //D = (d1, d2,…, dn) -справочная информация, позволяющая пользователю в соответствующем пункте диалога получить справку о состоянии диалога, о хар-ках текущего пункта, возможные варианты ответов, значения по умолчанию. 
        public Answer[] R;//R = (sh1, sh2, …, shn) – диапазон допустимых ответов пользователя, который определяется использованием синтаксиса семантического шаблона(код)
    }
    public class Answer //– диапазон допустимых ответов пользователя
    {
        public String Text; 
        public int Next;
        public Command[] Source;
        
    }
    public class Command
    {
        public bool Exist;
        public String Language;
        public String Type;
        public int[] Length = new int[2];
        public String[] Text = new String[2];
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
}