using System;
using System.Collections.Generic;
using lab1.Collections;
using lab1.Entities;

namespace lab1
{
    internal class Program
    {
        public static Hotel hotel = new Hotel();

        public static void Main(string[] args)
        {
            hotel.OnClientRegistered += () =>  Console.WriteLine("Пользователь зарегистрирован");

            while (true)
            {
                Console.WriteLine("1 - Заполнить информацию о номерах\n" +
                                  "2 - Регистрация посетителя\n" +
                                  "3 - Вывод списка свободных номеров\n" + 
                                  "4 - Вывод всех номеров\n" + 
                                  "5 - Узнать номер клиента\n" + 
                                  "6 - Выйти");
            
                int choise = Utility.IntParse("");
                
                switch (choise)
                {
                    case 1:
                        hotel.AddRooms();
                        break;
                    case 2:
                        hotel.RegisterClient();
                        break;
                    case 3:
                        hotel.ShowFreeRooms();
                        break;
                    case 4:
                        hotel.ShowAllRooms();
                        break;
                    case 5:
                        hotel.ClientRoom();
                        break;
                    case 6:
                        return;
                    default:
                        Console.Clear();
                        break;
                }

            }
        }
    }
}