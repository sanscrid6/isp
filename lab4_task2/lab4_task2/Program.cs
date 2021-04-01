using System.Runtime.InteropServices;
using System;


namespace lab4_task2
{
    class Program
    {
        [DllImport("libuntitled1.dll")]
        public static extern int abs(int x);
        
        [DllImport("libuntitled1.dll")]
        public static extern int sum(int x, int y);
        
        [DllImport("libuntitled1.dll")]
        public static extern int sub(int x, int y);
        
        [DllImport("libuntitled1.dll")]
        public static extern double sin(double x);
        
        [DllImport("libuntitled1.dll")]
        public static extern double cos(double x);
        
        [DllImport("libuntitled1.dll")]
        public static extern double exp(double x);
        
        [DllImport("libuntitled1.dll")]
        public static extern uint factorial(int x);
        
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Abs "+abs(-2));
            Console.WriteLine("Sum of 1 and 5 is " + sum(1,5));
            Console.WriteLine("Subtraction of 1 and 5 is " + sub(1,5));
            Console.WriteLine("Sin(10) is " + sin(10));
            Console.WriteLine("Cos(13) is "+ cos(13));
            Console.WriteLine("Factorial 5 is "+ factorial(5));
            Console.WriteLine("Exp(4) is "+ exp(4));
        }
    }
}