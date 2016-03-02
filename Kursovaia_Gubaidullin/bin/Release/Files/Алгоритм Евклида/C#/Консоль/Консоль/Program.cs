using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace CSharp_Evklid
{
    class Program
    {
        static void Main(string[] args)
        {
            long a, b, c;
            
            string[] s = Console.ReadLine().Split(new char[] { ' ' });
            int[] arr = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
                arr[i] = Convert.ToInt32(s[i]);

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
