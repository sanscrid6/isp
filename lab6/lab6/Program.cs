using System.Threading;
using System;

namespace lab6
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
            uint weight = 0, age = 0, fuelCapacity = 0, currentFuel = 0, fuelUsage = 0, capacity = 0;
            string brand = "No brand", type = "No info";
            int sw;
            int choose = 0;
            try
            {
                Console.WriteLine("1 - Create Car\n2 - Create Bus\n3 - Create Old Car\n4 - Create First Car");
                choose = Convert.ToInt32(Console.ReadLine());
            }
            catch 
            {
                Console.WriteLine("Only 1 or 2 for input");
                return;
            }
            switch (choose)
            {
               case (int)Types.Car: 
                   Car car;
                   sw = 5;
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
                   car = new Car(weight, age, fuelCapacity, currentFuel, fuelUsage, brand);
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
                   }
                   break;
               case (int)Types.Bus:
                   Bus bus;
                   sw = 5;
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
                   bus = new Bus(weight, age, fuelCapacity, currentFuel, fuelUsage, brand, capacity);
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
                   break;
               case (int)Types.OldCar:
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
                   sw = 5;
                   var oldCar = new OldCar(weight, age, brand);
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
                   break;
               case (int)Types.FirstCar:
                   sw = 5;
                   var oldestCar = new FirstCar();
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
                   break;
               default:
                   Console.WriteLine("Unknown type");
                   break;
            }
        }
    }
}