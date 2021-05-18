using System;

namespace lab8
{
    class Program
    {
        enum Types
        {
            Car = 1,
            Bus,
            OldCar,
            FirstCar
        }
        
        public static void Main(string[] args)
        {
            Car[] cars = new Car[4];
            uint weight = 0, age = 0, fuelCapacity = 0, currentFuel = 0, fuelUsage = 0, capacity = 0;
            string brand = "No brand", type = "No info";
            int choose = 0;
            do
            {
                try
                {
                    Console.WriteLine("1 - Create Car\n2 - Create Bus\n3 - Create Old Car\n4 - Create First Car\n" +
                                      "5 - Exit");
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
                switch (choose)
                { 
                    case (int)Types.Car:
                        if (cars[0] == null)
                        {
                            Car car;
                            try
                            {
                                Console.WriteLine("Enter weight");
                                weight = Convert.ToUInt32(Console.ReadLine());
                                Console.WriteLine("Enter age");
                                age = Convert.ToUInt32(Console.ReadLine());
                                Console.WriteLine("Enter fuel capacity");
                                fuelCapacity = Convert.ToUInt32(Console.ReadLine());
                                Console.WriteLine("Enter current fuel");
                                currentFuel = Convert.ToUInt32(Console.ReadLine());
                                Console.WriteLine("Enter fuel usage");
                                fuelUsage = Convert.ToUInt32(Console.ReadLine());
                                Console.WriteLine("Enter brand");
                                brand = Console.ReadLine();
                            }
                            catch
                            {
                                Console.WriteLine("You typed smth incorrect");
                                return;
                            }
                            car = new Car(weight, age, fuelCapacity, currentFuel, fuelUsage, brand, PrintMessage);
                            cars[0] = car;
                            DispalyCar(cars[0]);
                        }
                        else
                        {
                            Console.WriteLine("You already have car");
                            DispalyCar(cars[0]);
                        }
                        break;
               case (int)Types.Bus:
                   if (cars[1] == null)
                   {
                       Bus bus;
                       try
                       {
                           Console.WriteLine("Enter weight");
                           weight = Convert.ToUInt32(Console.ReadLine());
                           Console.WriteLine("Enter age");
                           age = Convert.ToUInt32(Console.ReadLine());
                           Console.WriteLine("Enter fuel capacity");
                           fuelCapacity = Convert.ToUInt32(Console.ReadLine());
                           Console.WriteLine("Enter current fuel");
                           currentFuel = Convert.ToUInt32(Console.ReadLine());
                           Console.WriteLine("Enter fuel usage");
                           fuelUsage = Convert.ToUInt32(Console.ReadLine());
                           Console.WriteLine("Enter brand");
                           brand = Console.ReadLine();
                           Console.WriteLine("Enter max amount of people");
                           capacity = Convert.ToUInt32(Console.ReadLine());
                       }
                       catch
                       {
                           Console.WriteLine("You typed smth incorrect");
                           return;
                       }
                       bus = new Bus(weight, age, fuelCapacity, currentFuel, fuelUsage, brand, capacity, PrintMessage);
                       cars[1] = bus;
                       DisplayBus((Bus)cars[1]);
                   }
                   else
                   {
                       Console.WriteLine("You already have bus");
                       DisplayBus((Bus)cars[1]);
                   }
                   break;
               case (int)Types.OldCar:
                   if (cars[2] == null)
                   {
                       try
                       {
                           Console.WriteLine("Enter weight");
                           weight = Convert.ToUInt32(Console.ReadLine());
                           Console.WriteLine("Enter age");
                           age = Convert.ToUInt32(Console.ReadLine());
                           Console.WriteLine("Enter brand");
                           brand = Console.ReadLine();
                       }
                       catch
                       {
                           Console.WriteLine("Incorrect input");
                           return;
                       }
                       var oldCar = new OldCar(weight, age, brand);
                       cars[2] = oldCar;
                       DisplayOldCar((OldCar)cars[2]);
                   }
                   else
                   {
                       Console.WriteLine("You already have old car");
                       DisplayOldCar((OldCar)cars[2]);
                   }
                   break;
               case(int)Types.FirstCar:
                   if (cars[3] == null)
                   {
                       FirstCar firstCar = new FirstCar();
                       cars[3] = firstCar;
                       DisplayFirstCar((FirstCar)cars[3]);    
                   }
                   else
                   {
                       Console.WriteLine("You already have first car");
                       DisplayFirstCar((FirstCar)cars[3]);
                   }
                   break;
               default:
                   Console.Clear();
                   break;
            } 
            } while (choose != 5);
        }
        
         public static void DispalyCar(Car car)
        {
            int sw = 5;
            do
            { 
                Console.WriteLine("1 - Get info\n2 - Travel to somewhere\n3 - Exit"); 
                try 
                { 
                    sw = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                { 
                    Console.Clear();
                } 
                switch (sw) 
                { 
                    case 1: 
                        car.Info(); 
                        break;
                    case 2: 
                        Console.WriteLine("Enter distance you want to travel and if you want enter speed"); 
                        var input = Console.ReadLine().Split(' '); 
                        if (input.Length > 2) 
                        { 
                            Console.WriteLine("It seems to be not correct");
                        }
                        else 
                        { 
                            try 
                            { 
                                uint distance = Convert.ToUInt32(input[0]); 
                                if (input.Length == 1) car.Move(distance);
                                else 
                                { 
                                    uint speed = Convert.ToUInt32(input[1]); 
                                    car.Move(distance, speed);                                
                                }
                            }
                            catch 
                            { 
                                Console.WriteLine("Your input was incorrect");
                            }
                        } 
                        break; 
                    default: 
                        Console.Clear(); 
                        break;
                } 
            } while (sw != 3);
        }

        public static void DisplayBus(Bus bus)
        {
            int sw = 5;
            while (sw!=3) 
            {
                Console.WriteLine("1 - Get info\n2 - Travel to somewhere\n3 - Exit"); 
                try
                {
                    sw = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                }
                switch (sw)
                {
                    case 1:
                        bus.Info();
                        break;
                    case 2:
                        try
                        { 
                            Console.WriteLine("Enter distance you want to travel");
                            var input = Convert.ToInt32(Console.ReadLine());
                            uint distance = Convert.ToUInt32(input); 
                            bus.Move(distance);
                        }
                        catch 
                        { 
                            Console.WriteLine("Your input was incorrect");
                        }
                        break; 
                    default:
                        Console.Clear();
                        break;
                }
            }   
        }

        public static void DisplayOldCar(OldCar oldCar)
        {
            int sw = 5;
            while (sw != 3)
            {
                Console.WriteLine("1 - Get info\n2 - Draw car\n3 - Exit");
                try
                {
                    sw = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                }
                switch (sw)
                {
                    case 1:
                        oldCar.Info();
                        break;
                    case 2:
                        oldCar.Draw();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
            
        }

        public static void DisplayFirstCar(FirstCar oldestCar)
        {
            int sw = 5;
            while (sw != 3)
            {
                Console.WriteLine("1 - Get info\n2 - Draw car\n3 - Exit");
                try
                {
                    sw = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                }
                switch (sw)
                {
                    case 1:
                        oldestCar.Info();
                        break;
                    case 2:
                        oldestCar.Draw();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } 
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}