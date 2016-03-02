using System;
using System.IO;
using System.Linq;
namespace Sample
{
    class Program
    {


        static void Prog()
        {
            StreamReader input = new StreamReader("input.txt");
            StreamWriter output = new StreamWriter("output.txt");

            int a;
            int[] mas = System.IO.File.ReadAllText("input.txt").Split(' ').Select(n => int.Parse(n)).ToArray();
            a = Sample.Program.gcd(mas[0], mas[1]);
            output.Write(a);
            input.Close();
            output.Close();
        }

        static void Main(string[] args)
        {
            StreamWriter timer = new StreamWriter("timer.txt");
            DateTime Start, Stoped; 
            TimeSpan Elapsed = new TimeSpan(); 
            Start = DateTime.Now;

            Sample.Program.Prog();
            Stoped = DateTime.Now; 
            Elapsed = Stoped.Subtract(Start);
            timer.Write(Elapsed.Seconds);
            
            timer.Close();
               
        }
        

        static int gcd(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }
    }
}
