using System.Runtime.InteropServices;
using System;


namespace lab4_task2
{
    class Program
    {
        [DllImport("libuntitled1.dll")]
        public static extern int abs(int a);
        
        [DllImport("libuntitled1.dll")]
        public static extern int sum(int a, int b);
        
        [DllImport("libuntitled1.dll")]
        public static extern int sub(int a, int b);
        
        
        public static void Main(string[] args)
        {
            int a = 6;
            Console.WriteLine(abs(a));
            Console.WriteLine(abs(-2));
            Console.WriteLine(sum(1,5));
            Console.WriteLine(sub(1,5));
        }
    }
}