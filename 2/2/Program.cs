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
                Console.WriteLine($"{i} встречается {amount[i]} раз");
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
                Console.WriteLine("1 - вывод даты в 2 форматах и подсчет цифр в них\n" +
                                  "2 - обмен порядка слов на обратный\n" +
                                  "3 - вывод 30 рандомных символов из строки 256 символов\n"+
                                  "4 - выход из программмы");
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
                        Console.WriteLine(str);
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
