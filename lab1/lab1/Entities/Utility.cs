using System;

namespace lab1.Entities
{
    public static class Utility
    {
        public static int IntParse(string msg)
        {
            do
            {
                Console.WriteLine(msg);
                var parsed = int.TryParse(Console.ReadLine(), out int number);
                        
                if (!parsed)
                {
                    Console.WriteLine("Не корректный ввод");
                }
                else
                {
                    return number;
                }
                        
            } while (true);
        }        
    }
}