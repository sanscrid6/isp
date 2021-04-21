using System;
using System.Text.RegularExpressions;

namespace lab7
{
    class Rational: ICloneable, IComparable
    {
        private int n { get; set; }
        private uint m;
        private uint M {
            get
            {
                return m;
            }
            set
            {
                if (value != 0)
                {
                    m = value;
                }
                else
                {
                    throw new Exception("Can't divide on zero");
                }
            } 
        }
    

        private static uint GCD(uint n, uint m)
        {
            while (n != 0 && m != 0)
            {
                if (m >= n) m %= n;
                else n %= m;
            }
            return m != 0? m : n;
        }

        public Rational()
        {
            n = 0;
            m = 0;
        }

        public Rational(int n, uint m)
        {
            this.n = n;
            this.m = m;
        }

        public static Rational Abs(Rational r)
        {
            return new Rational(Math.Abs(r.n), (uint)Math.Abs(r.m));
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            if (r1.n > 0 && r2.n > 0)
            {
                uint LCM = r1.m * r2.m / GCD(r1.m, r2.m);
                r.n = Convert.ToInt32(r1.n*LCM / r1.m + r2.n*LCM / r2.m);
                r.m = LCM;
                if (GCD((uint)r.n, r.m) != 1)
                {
                    uint gcd = GCD((uint)r.n, r.m);
                    r.n /=(int)gcd;
                    r.m /= gcd;
                }
                
            }
            else if (r1.n < 0 && r2.n < 0)
            {
                Rational AbsR1 = Abs(r1);
                Rational AbsR2 = Abs(r2);
                uint LCM = AbsR1.m * AbsR2.m / GCD(AbsR1.m, AbsR2.m);
                r.n = Convert.ToInt32(AbsR1.n*LCM / AbsR1.m + AbsR2.n*LCM / AbsR2.m);
                r.m = LCM;
                if (GCD((uint)r.n, r.m) != 1)
                {
                    uint gcd = GCD((uint)r.n, r.m);
                    r.n /=(int)gcd;
                    r.m /= gcd;
                }
                r.n *= -1;
            }
            else if(r2.n < 0)
            {
                return r1 - Abs(r2);
            }
            else
            {
                return r2 - Abs(r1);
            }
            return r;
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            if (r1.n > 0 && r2.n > 0)
            {
                uint LCM = r1.m * r2.m / GCD(r1.m, r2.m);
                r.n = Convert.ToInt32(r1.n*LCM / r1.m - r2.n*LCM / r2.m);
                r.m = LCM;
                if (GCD((uint)r.n, r.m) != 1)
                {
                    uint gcd = GCD((uint)r.n, r.m);
                    r.n /=(int)gcd;
                    r.m /= gcd;
                }
                
            }
            else if (r1.n < 0 && r2.n < 0)
            {
                return r2 - Abs(r1);
            }
            else if (r2.n < 0)
            {
                return Abs(r2) + r1;
            }
            else
            {
                Rational temp = new Rational(-1 * r2.n, r2.m);
                return r1 + temp;
            }
            return r;
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            if (r1.n < 0 && r2.n < 0)
            {
                r.n = r1.n * r2.n;
                r.m = r1.m * r2.m;
                if (GCD((uint)r.n, r.m) != 1)
                {
                    uint gcd = GCD((uint)r.n, r.m);
                    r.n /=(int)gcd;
                    r.m /= gcd;
                }
            }
            else
            {
                r.n = r1.n * r2.n;
                r.m = r1.m * r2.m;
                if (GCD((uint)Math.Abs(r.n), (uint)Math.Abs(r.m)) != 1)
                {
                    uint gcd = GCD((uint) Math.Abs(r.n), (uint)Math.Abs(r.m));
                    r.n /=(int)gcd;
                    r.m /= gcd;
                }
            }
            return r;
        }
        
        public static Rational operator /(Rational r1, Rational r2)
        {
            Rational temp = new Rational(r2.n < 0 ? (int) (-1 * r2.m ): (int)r2.m, (uint)Math.Abs(r2.n));
            return r1 * temp;
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            Double r = (double)r1 - (double)r2;
            if (r < 0) return true;
            return false;
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            return !(r1 < r2);
        }
        
        public static explicit operator double(Rational r)
        {
            return (double)r.n / r.m;
        }

        public static explicit operator int(Rational r)
        {
            return (int)(r.n / r.m);
        }

        public static explicit operator Rational(string str)
        {
            Rational r = new Rational();
            bool slash = false;
            int index = 0;
            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '/')
                    {
                        slash = true;
                        r.n = Convert.ToInt32(str.Substring(0, i));
                        index = i;
                    }
                }
                if (slash)
                {
                    r.m = Convert.ToUInt32(str.Substring(index + 1, str.Length-index-1));
                }

                return r;

            }
            catch (Exception e)
            {
                throw new Exception("Incorrect string");
            }
        }

        public string ToStr(string flag)
        {
            if (flag == "default") return ToString();
            if (flag == "text") return $"Numerator is {n}, denominator is {m}";
            throw new Exception("Incorrect flag");
        }

        public static Rational FromStr(string str, string flag)
        {
            if (flag == "default") return (Rational) str;
            if (flag == "text")
            {
                Rational r = new Rational();
                Regex regex = new Regex(@"^Numerator is (-?\d+), denominator is (\d+)$");
                var match = regex.Match(str);
                var result = match.Groups;
                try
                {
                    r.n = Convert.ToInt32(Convert.ToString(result[1]));
                    r.m = Convert.ToUInt32(Convert.ToString(result[2]));
                }
                catch (Exception e)
                {
                    throw new Exception("Incorrect string");
                }
                return r;
            }
            throw new Exception("Incorrect flag");
        }

        public override bool Equals(object obj)
        {
            Rational r = (Rational) obj;
            if (n == r?.n && m == r.m) return true;
            else return false;
        }

        public override string ToString()
        {
            return $"{n}/{m}";
        }
        

        public object Clone()
        {
            return new Rational(this.n, this.m);
        }

        public int CompareTo(object obj)
        {
            if (this < (Rational) obj) return - 1;
            else if (this > (Rational) obj) return 1;
            else return 0;
        }
    }

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
            Console.WriteLine($"Class object from string \"Numerator is -4, denominator is 5\" is {r3}");
            Console.WriteLine($"Class object from string \"3\\7\"");
            Console.WriteLine($"r3 - r4 is {r3-r4}");
            Console.WriteLine($"r3 * r4 is {r3*r4}");
            Console.WriteLine($"r3 / r4 is {r3/r4}");
        }
    }
}