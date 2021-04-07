using System;
using System.Threading;

namespace lab5
{
    abstract class Vehicle
    {
        protected uint Weight { get; set; }
        protected uint Age { get; set; }
        protected uint FuelCapacity { get; set;}
        protected uint CurrentFuel { get; set; }
        protected uint FuelUsage { get; set; }
        protected string Brand { get; set; }
        public abstract void Info();
    }

    class Car : Vehicle
    {
        static protected uint amount;
        protected readonly uint id;
        protected struct MoveStuff
        {
            public string[] vehicleImage;
            public string[] roadTemplate;
        }

        protected MoveStuff images;

        protected virtual void InitImages()
        {
            images = new MoveStuff();
            images.roadTemplate = new string[7];
            images.vehicleImage = new string[7];
            images.roadTemplate[0] = " ";
            images.roadTemplate[1] = " ";
            images.roadTemplate[2] = " ";
            images.roadTemplate[3] = "-";
            images.roadTemplate[4] = " ";
            images.roadTemplate[5] = " ";
            images.roadTemplate[6] = "-";
            images.vehicleImage[0] = "              ________      ";
            images.vehicleImage[1] = "             /  |     \\      ";
            images.vehicleImage[2] = " ___________/___|______\\_______";
            images.vehicleImage[3] = "/        ____  ~|    ____     /";
            images.vehicleImage[4] = "[0=##=0[ /  \\|______|/  \\|___/";
            images.vehicleImage[5] = "  \\\\_/  \\\\__/       \\\\__/";
            images.vehicleImage[6] = "-----------------------------";   
        }

        public Car()
        {
            id = amount + 1;
            amount++;
        }

        public Car(uint weight, uint age, uint fuelCapacity, uint currentFuel,uint fuelUsage, string brand)
        {
            id = amount + 1;
            amount++;
            Weight = weight;
            Age = age;
            FuelCapacity = fuelCapacity;
            if (currentFuel > fuelCapacity)
            {
                Console.WriteLine("Your max level of fuel is smaller. We fully tank up your vehicle.");
                CurrentFuel = fuelCapacity;
            }
            else
            {
                CurrentFuel = currentFuel;
            }
            FuelUsage = fuelUsage;
            Brand = brand;
            InitImages();
        }
        public override void Info()
        {
            Console.WriteLine($"Id is {id}. Type is default car. Brand is {Brand}. Weight is {Weight}." +
                              $" Age is {Age}. Fuel capacity is {FuelCapacity}. Current fuel level is " +
                              $"{(float)CurrentFuel/FuelCapacity*100}%.");
        }
        
        public virtual void Move(uint distance)
        {
            if(distance*FuelUsage>FuelCapacity)
            {
                Console.WriteLine("This distance too big for your car");
                return;
            }
            else if (distance*FuelUsage>CurrentFuel)
            {
                Console.WriteLine(
                    "Too big distance, not enought fuel. Go to gas station. Type yes to go to gas station");
                var key = Console.ReadLine().ToLower();
                if ( key == "yes" || key == "y")
                {
                    CurrentFuel = FuelCapacity;
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
                        temp[j]+=images.roadTemplate[j];
                    }
                
                }
                for (int i = 0; i < 7; i++)
                {
                    temp[i]+=images.vehicleImage[i];
                  
                }
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        temp[i]+=images.roadTemplate[i];
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
            CurrentFuel -= distance * FuelUsage;
            
        }
        public virtual void Move(uint distance, uint speed)
        {
            if(distance*FuelUsage>FuelCapacity)
            {
                Console.WriteLine("This distance too big for your car");
                return;
            }
            else if (distance*FuelUsage>CurrentFuel)
            {
                Console.WriteLine(
                    "Too big distance, not enought fuel. Go to gas station. Type yes to go to gas station");
                var key = Console.ReadLine().ToLower();
                if (key == "yes" || key == "y")
                {
                    CurrentFuel = FuelCapacity;
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
                        temp[j]+=images.roadTemplate[j];
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    temp[i]+=images.vehicleImage[i];
                }
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        temp[i]+=images.roadTemplate[i];
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
            CurrentFuel -= distance * FuelUsage;
            
        }
    }

    class Bus : Car
    {
        enum Capacity: uint
        {
            Shuttlebus = 20,
            OneFloorBus = 40,
            TwoFloorBus = 70
        }

        private readonly Capacity type;
        protected override void InitImages()
        {
            images = new MoveStuff();
            images.roadTemplate = new string[10];
            images.vehicleImage = new string[10];
            images.vehicleImage[0] = "   ---------------------------.";
            images.vehicleImage[1] = " `/\"\"\"\"/\"\"\"\"/|\"\"|'|\"\"||\"\"|   ' \\.";
            images.vehicleImage[2] = " /    /    / |__| |__||__|      |";
            images.vehicleImage[3] = "/----------=====================|";
            images.vehicleImage[4] = "| \\  /V\\  /    _.               |";
            images.vehicleImage[5] = "|()\\ \\W/ /()   _            _   |";
            images.vehicleImage[6] = "|   \\   /     / \\          / \\__/";
            images.vehicleImage[7] = "=C========C==_| ) |--------| ) ";
            images.vehicleImage[8] = "\\_\\_/      \\_\\_/  \\_\\_/ \\_\\_/";
            images.vehicleImage[9] = "--------------------------------";
            images.roadTemplate[0] = " ";
            images.roadTemplate[1] = " ";
            images.roadTemplate[2] = " ";
            images.roadTemplate[3] = " ";
            images.roadTemplate[4] = "-";
            images.roadTemplate[5] = " ";
            images.roadTemplate[6] = "-";
            images.roadTemplate[7] = " ";
            images.roadTemplate[8] = " ";
            images.roadTemplate[9] = "-";
        }
        public Bus(uint weight, uint age, uint fuelCapacity, uint currentFuel,uint fuelUsage, string brand, uint capacity)
        {
            if (capacity <= (uint) Capacity.Shuttlebus) type = Capacity.Shuttlebus;
            else if (capacity <= (uint) Capacity.OneFloorBus) type = Capacity.OneFloorBus;
            else type = Capacity.TwoFloorBus;
            Weight = weight;
            Age = age;
            FuelCapacity = fuelCapacity;
            if (currentFuel > fuelCapacity)
            {
                Console.WriteLine("Your max level of fuel is smaller. We fully tank up your vehicle.");
                CurrentFuel = fuelCapacity;
            }
            else
            {
                CurrentFuel = currentFuel;
            }
            FuelUsage = fuelUsage;
            Brand = brand;
            InitImages();
        }
        public override void Info()
        {
            Console.WriteLine($"Id is {id}. Type is {type}. Brand is {Brand}. Weight is {Weight}." +
                              $" Age is {Age}. Fuel capacity is {FuelCapacity}. Current fuel level is " +
                              $"{(float)CurrentFuel/FuelCapacity*100}%.");
        }
        
        public override void Move(uint distance)
        {
            if(distance*FuelUsage>FuelCapacity)
            {
                Console.WriteLine("This distance too big for your car");
                return;
            }
            else if (distance*FuelUsage>CurrentFuel)
            {
                Console.WriteLine(
                    "Too big distance, not enought fuel. Go to gas station. Type yes to go to gas station");
                var key = Console.ReadLine().ToLower();
                if ( key == "yes" || key == "y")
                {
                    CurrentFuel = FuelCapacity;
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
                string[] temp = new string[10];
                for (int i = 0; i < distance-k; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp[j]+=images.roadTemplate[j];
                    }
                
                }
                for (int i = 0; i <10; i++)
                {
                    temp[i]+=images.vehicleImage[i];
                  
                }
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        temp[i]+=images.roadTemplate[i];
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                 
                    Console.WriteLine(temp[i]);
                }
                Thread.Sleep(300);
                Console.Clear();
            }
            Console.WriteLine("You reach destination");
            CurrentFuel -= distance * FuelUsage;
        }
    }
    class Program
    {
        enum Types
        {
            Car = 1,
            Bus
        }

        public static void Main(string[] args)
        {
            uint weight = 0, age = 0, fuelCapacity = 0, currentFuel = 0, fuelUsage = 0, capacity = 0;
            string brand = "No brand", type = "No info";
            int choose = 0;
            try
            {
                Console.WriteLine("1 - Create car\n2 - Create bus");
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
                   int sw = 5;
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
                   int switcher = 5;
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
                   while (switcher!=3) 
                   {
                        Console.WriteLine("1 - Get info\n2 - Travel to somewhere\n3 - Exit"); 
                        try
                        {
                            switcher = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                        }
                        switch (switcher)
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
               default:
                   Console.WriteLine("Unknown type");
                   break;
            }
        }
    }
}