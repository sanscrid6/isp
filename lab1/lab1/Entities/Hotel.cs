using System;
using lab1.Collections;

namespace lab1.Entities
{
    public class Hotel
    {
        private MyCustomCollection<Room> rooms = new MyCustomCollection<Room>();
        private MyCustomCollection<Client> clients = new MyCustomCollection<Client>();

        public void AddRooms()
        {
            var cost = Utility.IntParse("Введите стоимость");
            var room = new Room(cost);
            rooms.Add(room);
            Console.WriteLine("Комната создана");
        }

        public void RegisterClient()
        {
            Console.WriteLine("Введите фамилию");
            var name = Console.ReadLine();
            var client = new Client(name);
            var number = Utility.IntParse("Введите номер комнаты");
            
            if (!rooms.Find(curRoom => curRoom.Number == number, out Room room))
            {
                Console.WriteLine("Нет такой комнаты");
                return;
            }
            
            if (room.Client != null)
            {
                Console.WriteLine("У этой комнаты уже есть посетитель");
            }
            else
            {
                room.Client = client;
                client.Room = room;
                clients.Add(client);
                Console.WriteLine("Пользователь зарегистрирован");
            }
        }

        public void ShowFreeRooms()
        {
            rooms.Reset();
            for (int i = 0; i < rooms.Count(); i++)
            {
                var curr = rooms.Current();
                
                if (curr.Client == null)
                {
                    Console.WriteLine(curr);
                }

                rooms.Next();
            }
        }
        
        public void ShowAllRooms()
        {
            rooms.Reset();
            for (int i = 0; i < rooms.Count(); i++)
            {
                var curr = rooms.Current();
                Console.WriteLine(curr);
                rooms.Next();
            }
        }
        
        public void ClientRoom()
        {
            clients.Reset();
            Console.WriteLine("Введите фамилию клиента");
            var name = Console.ReadLine();
            
            if (!clients.Find(currClient => currClient.SourName == name, out var client))
            {
               Console.WriteLine("Такого клиента нет"); 
               return;
            }
            Console.WriteLine(client);
        }
    }
}