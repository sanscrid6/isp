using System;
using System.Text.RegularExpressions;

namespace lab7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Rational r1 = new Rational(1,2);
            Rational r2 = new Rational(13,2);
            Console.WriteLine($"r1 is {r1}\nr2 is {r2}");
            Console.WriteLine("r1 + r2(in default mode) is "+(r1+r2).ToStr("default"));
            Console.WriteLine("r1 + r2(in text mode) is " + (r1+r2).ToStr("text"));
            Console.WriteLine($"r1 - r2 is {r1-r2}");
            Console.WriteLine($"r1 * r2 is {r1*r2}");
            Console.WriteLine($"r1 / r2 is {r1/r2}");
            Console.WriteLine($"r1 compare to r2 is {r1.CompareTo(r2)}");
            Rational r3 = Rational.FromStr("Numerator is -4, denominator is 5", "text");
            Rational r4 = Rational.FromStr("3/7", "default");
            Console.WriteLine($"From string: \"Numerator is -4, denominator is 5\" is {r3}");
            Console.WriteLine($"From string \"{r4}\"");
            Console.WriteLine($"r3 is {r3}");
            Console.WriteLine($"r4 is {r4}");
            Console.WriteLine($"r3 - r4 is {r3-r4}");
            Console.WriteLine($"r3 * r4 is {r3*r4}");
            Console.WriteLine($"r3 / r4 is {r3/r4}");
            r3 = (Rational) "-6/5";
            r4 = (Rational) "-15/2";
            Console.WriteLine($"{r3*r4}");
            Console.WriteLine((string)r3);
        }
    }
}