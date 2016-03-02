using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace CSharp_Evklid
{
    class Program
    {
        static void Main(string[] args)
        {
            long a, b, c;

            int[] arr = Array.ConvertAll(File.ReadAllLines("C:\\input.txt"), Convert.ToInt32);
            a = arr[0];
            b = arr[1];
            while (b > a)
            {
                c = a % b;
                a = b;
                b = c;
            }
            Console.WriteLine(Convert.ToString(Math.Abs(a)));
        }
    }
}
