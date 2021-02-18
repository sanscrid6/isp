using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba1
{
    class Program
    {
        static int[,] init(int size)
        {
            int[,] arr = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = size * (size - i) - j - 1;
                }
            }
            if (size % 2 == 0)
            {
                int temp = arr[size - 1, size - 2];
                arr[size - 1, size - 2] = arr[size - 1, size - 3];
                arr[size - 1, size - 3] = temp;
            }
            return arr;
        }
        
        static int[] moveBottom(int[,] arr, int emptyPlaceI, int emptyPlaceJ)
        {
            var size = Math.Sqrt(arr.Length);
            int[] emptyPlaceCoordinates = { emptyPlaceI, emptyPlaceJ};
            if (emptyPlaceI + 1 < size)
            {
                int temp = arr[emptyPlaceI, emptyPlaceJ];
                arr[emptyPlaceI, emptyPlaceJ] = arr[emptyPlaceI + 1, emptyPlaceJ];
                arr[emptyPlaceI + 1, emptyPlaceJ] = temp;
                emptyPlaceCoordinates[0]++;
            }
            return emptyPlaceCoordinates;

        }
        static int[] moveTop(int[,] arr, int emptyPlaceI, int emptyPlaceJ)
        {
            int[] emptyPlaceCoordinates = { emptyPlaceI, emptyPlaceJ };
            if (emptyPlaceI - 1 >= 0)
            {
                int temp = arr[emptyPlaceI, emptyPlaceJ];
                arr[emptyPlaceI, emptyPlaceJ] = arr[emptyPlaceI-1, emptyPlaceJ];
                arr[emptyPlaceI-1, emptyPlaceJ] = temp;
                emptyPlaceCoordinates[0]--;
            }
            return emptyPlaceCoordinates;
        }
        static int[] moveLeft(int[,] arr, int emptyPlaceI, int emptyPlaceJ)
        {
            int[] emptyPlaceCoordinates = { emptyPlaceI, emptyPlaceJ };
            if (emptyPlaceJ - 1 >= 0)
            {
                int temp = arr[emptyPlaceI, emptyPlaceJ];
                arr[emptyPlaceI, emptyPlaceJ] = arr[emptyPlaceI, emptyPlaceJ-1];
                arr[emptyPlaceI, emptyPlaceJ-1] = temp;
                emptyPlaceCoordinates[1]--;
            }
            return emptyPlaceCoordinates;

        }
        static int[] moveRight(int[,] arr, int emptyPlaceI, int emptyPlaceJ)
        {
            var size = Math.Sqrt(arr.Length);
            int[] emptyPlaceCoordinates = { emptyPlaceI, emptyPlaceJ };
            if (emptyPlaceJ + 1 < size)
            {
                int temp = arr[emptyPlaceI, emptyPlaceJ];
                arr[emptyPlaceI, emptyPlaceJ] = arr[emptyPlaceI, emptyPlaceJ+1];
                arr[emptyPlaceI, emptyPlaceJ+1] = temp;
                emptyPlaceCoordinates[1]++;
            }
            return emptyPlaceCoordinates;

        }
        static void draw(int[,] arr)
        {
            for (int i = 0; i < Math.Sqrt(arr.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(arr.Length); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        Console.Write("_\t");
                    }
                    else
                    {
                        Console.Write("{0}\t", arr[i,j]);
                    }
  
                }
                Console.Write('\n');
            }
        }
        static bool isWinner(int[,] arr)
        {
            for (int i = 0; i < Math.Sqrt(arr.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(arr.Length); j++)
                {
                    if(i == Math.Sqrt(arr.Length)-1 && j == Math.Sqrt(arr.Length)-1)
                    {
                        break;
                    }
                    if (arr[i, j] != i * Math.Sqrt(arr.Length) + j + 1)
                    {
                        return false;
                    }
                
                }

            }
            return true;
        }


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int size = 0;
            do
            {
                try
                {
                    Console.WriteLine("Введите размер поля(>2)");
                    size = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                }
                catch
                {
                    Console.Clear();
                    continue;
                }

            } while (size <= 2);
            var arr = init(size);
            draw(arr);
            int[] emptyPlaceCoordinates = { size - 1, size - 1 };
            while (isWinner(arr) == false)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    emptyPlaceCoordinates = moveBottom(arr, emptyPlaceCoordinates[0], emptyPlaceCoordinates[1]);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    emptyPlaceCoordinates = moveTop(arr, emptyPlaceCoordinates[0], emptyPlaceCoordinates[1]);
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    emptyPlaceCoordinates = moveLeft(arr, emptyPlaceCoordinates[0], emptyPlaceCoordinates[1]);
                }
                else if(key == ConsoleKey.RightArrow)
                {
                    emptyPlaceCoordinates = moveRight(arr, emptyPlaceCoordinates[0], emptyPlaceCoordinates[1]);
                }
                Console.Clear();
                draw(arr);
            }
            Console.WriteLine("Вы выиграли!!!");
            Console.ReadKey();

        }
    }
}
