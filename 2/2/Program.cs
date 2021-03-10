using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static int CountPower(ulong x)
        {
            int power = 0;
            while (Convert.ToBoolean(x))
            {
                x = x / 2;
                power += Convert.ToInt32(x);
            }
            return power;
        }
        static void Main(string[] args)
        {
            int switcher = 0;
           while (switcher!=4)
            {
                Console.WriteLine("1 - output date in 2 formats and count amount of digits\n" +
                                  "2 - reverse words in string\n" +
                                  "3 - count power of 2 in diaposon\n"+
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
                        Console.WriteLine("Enter a and b");
                        ulong b, a;
                        try
                        {
                            a = Convert.ToUInt64(Console.ReadLine());
                            b = Convert.ToUInt64(Console.ReadLine());
                            int power = CountPower(b) - CountPower(a-1);
                            Console.WriteLine($"Power of 2 is {power}");
                        }
                        catch
                        {
                            Console.WriteLine("Incorrect input");
                        }
                        break;
                    default:
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
