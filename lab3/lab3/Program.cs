using System;
using System.Collections.Generic;
using System.Threading;



namespace lab3
{
    class Vehicle
    {
        static protected uint amount;
        protected readonly uint id;
        protected uint weight;
        protected uint age;
        protected uint fuelCapacity;
        protected uint currentFuel;
        protected uint fuelUsage;
        protected string brand;
        protected string type;
        protected string[] road;
        protected string[] car;

        public Vehicle(uint weight = 0, uint age = 0, uint fuelCapacity = 0,
            uint currentFuel = 0,uint fuelUsage = 0, string brand = "No brand", string type = "No type")
        {
            id = amount + 1;
            this.weight = weight;
            this.age = age;
            this.fuelCapacity = fuelCapacity;
            if (currentFuel > fuelCapacity)
            {
                Console.WriteLine("Your max level of fuel is smaller. We fully tank up your vehicle.");
                this.currentFuel = fuelCapacity;
            }
            else
            {
                this.currentFuel = currentFuel;
            }
            this.fuelUsage = fuelUsage;
            this.brand = brand;
            this.type = type;
            road = new string[7];
            road[0] = " ";
            road[1] = " ";
            road[2] = " ";
            road[3] = "-";
            road[4] = " ";
            road[5] = " ";
            road[6] = "-";
            car = new string[7];
            car[0] = "              ________      ";
            car[1] = "             /  |     \\      ";
            car[2] = " ___________/___|______\\_______";
            car[3] = "/        ____  ~|    ____     /";
            car[4] = "[0=##=0[ /  \\|______|/  \\|___/";
            car[5] = "  \\\\_/  \\\\__/       \\\\__/";
            car[6] = "-----------------------------";
        }

        public uint FuelUsage
        {
            get => fuelUsage;
            set => fuelUsage = value;
        }

        public Vehicle()
        {
            id = amount + 1;
        }

        public uint Id
        {
            get => id;
        }

        public uint Weight
        {
            get => weight;
            set => weight = value;
        }

        public uint Age
        {
            get => age;
            set => age = value;
        }

        public uint FuelCapacity
        {
            get => fuelCapacity;
            set => fuelCapacity = value ;
        }

        public uint CurrentFuel
        {
            get => currentFuel;
            set => currentFuel = value;
        }

        public string Brand
        {
            get => brand;
            set => brand = value;
        }

        public void Info()
        {
            Console.WriteLine($"Id is {id}. Type of this vehicle is {type}. Brand is {brand}. Weight is {weight}." +
                              $" Age is {age}. Fuel capacity is {fuelCapacity}. Current fuel level is " +
                              $"{(float)currentFuel/fuelCapacity*100}%.");
        }

        public void Move(uint distance)
        {
            if(distance*fuelUsage>fuelCapacity)
            {
                Console.WriteLine("This distance too big for your car");
                return;
            }
            else if (distance*fuelUsage>currentFuel)
            {
                Console.WriteLine(
                    "Too big distance, not enought fuel. Go to gas station. Type yes to go to gas station");
                var key = Console.ReadLine().ToLower();
                if ( key == "yes" || key == "y")
                {
                    currentFuel = fuelCapacity;
                }
                else
                {
                    Console.WriteLine("Without enought fuel vehicle can't reach your destination");
                    return;
                }
            }
            else if (distance > 145)
            {
                Console.WriteLine("Distance too big for console");
                return;
            }
            for (int k = 0; k < distance; k++)
            {
                string[] temp = new string[7];
                for (int i = 0; i < distance-k; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        temp[j]+=road[j];
                    }
                
                }
                for (int i = 0; i < 7; i++)
                {
                    temp[i]+=car[i];
                  
                }
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        temp[i]+=road[i];
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                 
                    Console.WriteLine(temp[i]);
                }
                Thread.Sleep(300);
                Console.Clear();
            }
            Console.WriteLine("You reach destination");
            currentFuel -= distance * fuelUsage;
            
        }
        public void Move(uint distance, uint speed)
        {
            if(distance*fuelUsage>fuelCapacity)
            {
                Console.WriteLine("This distance too big for your car");
                return;
            }
            else if (distance*fuelUsage>currentFuel)
            {
                Console.WriteLine(
                    "Too big distance, not enought fuel. Go to gas station. Type yes to go to gas station");
                var key = Console.ReadLine().ToLower();
                if (key == "yes" || key == "y")
                {
                    currentFuel = fuelCapacity;
                }
                else
                {
                    Console.WriteLine("Without enought fuel vehicle can't reach your destination");
                    return;
                }
            }
            else if (speed>95)
            {
                Console.WriteLine("Speed is too big!");
                return;
            }
            else if (distance > 145)
            {
                Console.WriteLine("Distance too big for console");
                return;
            }
            for (int k = 0; k < distance; k++)
            {
                string[] temp = new string[7];
                for (int i = 0; i < distance-k; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        temp[j]+=road[j];
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    temp[i]+=car[i];
                }
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        temp[i]+=road[i];
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine(temp[i]);
                }
                Thread.Sleep(Convert.ToInt32(1000 - 10 * speed));
                Console.Clear();
            }
            Console.WriteLine("You reach destination");
            Console.WriteLine($"You spend {(float)distance/speed} hours");
            currentFuel -= distance * fuelUsage;
            
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            //List<Vehicle> vehicles = new List<Vehicle>();
            Vehicle v;
            /*string gasStation = " ____ _   _ _    ____ \n" +
                                "/    | | | | |  |  __|\n" +
                                "| |  | | | | |__| _|  \n" +
                                "\\____|\\___/|___|_|";
            Console.WriteLine(gasStation);*/
            int sw = 5;
            uint weight = 0, age = 0, fuelCapacity = 0, currentFuel = 0, fuelUsage = 0;
            string brand = "No brand", type = "No info";
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
                Console.WriteLine("Enter type");
                type = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("You typed smth incorrect");
                return;
            }
            v = new Vehicle(weight, age, fuelCapacity, currentFuel, fuelUsage, brand, type);
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
                        v.Info();
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
                                if (input.Length == 1)
                                {
                                    v.Move(distance);
                                }
                                else
                                {
                                    uint speed = Convert.ToUInt32(input[1]);
                                    v.Move(distance, speed);                                
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
        }
    }
}