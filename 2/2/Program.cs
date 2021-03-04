using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2
{
    class Program
    {
        static bool IsDigit(char c)
        {
            if (c >= 48 && c < 58)
            {
                return true;
            }
            return false;
        }
        static void CountNums(string str)
        {
            int[] amount = new int[10] ;
            for (int i = 0; i < str.Length; i++)
            {
                if (IsDigit(str[i]))
                {
                    var t = Convert.ToInt32(str[i]-48);
                    amount[Convert.ToInt32(str[i])-48]++;
                }

            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} occurs {amount[i]} times");
            }

        }
        static string ReverseWords(string str)
        {
            var arr = str.Split(' ');
            var reversedArr = arr.Reverse();
            str = String.Join(" ", reversedArr);
            return str;
        }
        static void RandSymbols()
        {
            Random rand = new Random();
            string bigStr = "NqLyRDTNPiFLvCyaPPJhTwgmBbzROIrzYAsISOBWNAnaStpqIPQEWslBDzoulqjerzfDPnmqDgkZErFLglVNuWLzkgXlQKoNxvulKvjopQJdXmxOYjLqtkCEWXxcRimXuzmyBcwKeFGYAUnKZdDaNoZeWTKBeXYewCyWqgSagwBjEhKXcEEkcgVNmvTlRrHioDTGQBKTQWCBaRQsDVWmlgUDMuwTAlUasJoHSexnSNJZzNGCVzUIEjHXyKHzCfXi";
            for (int i = 0; i < 30; i++)
                Console.Write("{0} ", bigStr[rand.Next(256)]);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int switcher = 0;
           while (switcher!=4)
            {
                Console.WriteLine("1 - output date in 2 formats and count amount of digits\n" +
                                  "2 - reverse words in string\n" +
                                  "3 - output 30 random symbols from 256 symbol string\n"+
                                  "4 - exit");
                try
                {
                    switcher = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                    Console.Clear();
                }
                Console.Clear();
                switch (switcher)
                {
                    case 1:
                        DateTime dateTime = DateTime.Now;
                        string[] dateFormats = { DateTime.Now.ToLocalTime().ToString(), DateTime.Now.ToUniversalTime().ToString() };
                        for (int i = 0; i < dateFormats.Length; i++)
                        {
                            Console.WriteLine($"Date {i + 1} is {dateFormats[i]}");
                            CountNums(dateFormats[i]);
                        }
                        break;
                    case 2:
                        string str = Console.ReadLine();
                        Console.WriteLine(ReverseWords(str));
                        break;
                    case 3:
                        RandSymbols();
                        break;
                    default:
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
