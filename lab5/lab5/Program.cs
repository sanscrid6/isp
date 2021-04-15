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
        
        public void Move(uint distance)
        {
            if(distance*FuelUsage>FuelCapacity)
            {
                Console.WriteLine("This distance too big for your car");
                return;
            }
            if (distance*FuelUsage>CurrentFuel)
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
                string[] temp = new string[images.vehicleImage.Length];
                for (int i = 0; i < distance-k; i++)
                {
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j]+=images.roadTemplate[j];
                    }
                
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i]+=images.vehicleImage[i];
                  
                }
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i]+=images.roadTemplate[i];
                    }
                }
                for (int i = 0; i < temp.Length; i++)
                {
                 
                    Console.WriteLine(temp[i]);
                }
                Thread.Sleep(300);
                Console.Clear();
            }
            Console.WriteLine("You reach destination");
            CurrentFuel -= distance * FuelUsage;
            
        }
        
        public void Move(uint distance, uint speed)
        {
            if(distance*FuelUsage>FuelCapacity)
            {
                Console.WriteLine("This distance too big for your car");
                return;
            }
            if (distance*FuelUsage>CurrentFuel)
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
        
        public void Draw()
        {
            foreach (var str in images.vehicleImage)
            {
                Console.WriteLine(str);
            }
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
    }

    class OldCar : Car
    {
        protected override void InitImages()
        {
            images = new MoveStuff();
            images.vehicleImage = new string[12];
            images.vehicleImage[0] = "            __-------__";
            images.vehicleImage[1] = "          / _---------_ \\";
            images.vehicleImage[2] = "         / /           \\ \\";
            images.vehicleImage[3] = "         | |           | |";
            images.vehicleImage[4] = "         |_|___________|_|";
            images.vehicleImage[5] = "     /-\\|                 |/-\\";
            images.vehicleImage[6] = "    | _ |\\       0       /| _ |";
            images.vehicleImage[7] = "    |(_)| \\      !      / |(_)|";
            images.vehicleImage[8] = "    |___|__\\_____!_____/__|___|";
            images.vehicleImage[9] = "    [_________|MEIN1|_________]";
            images.vehicleImage[10] = "     ||||    ~~~~~~~~     ||||";
            images.vehicleImage[11] = "     `--'                 `--'";

        }
        
        public OldCar(uint weight, uint age, string brand)
        {
            Weight = weight;
            if (age > 130) age = 130;
            Age = age;
            Brand = brand;
            InitImages();
        }

        public override void Info()
        {
            Console.WriteLine($"This is old car of {2021-Age} year. It's age is {Age}. Brand is {Brand}");
        }
    }
    
    class FirstCar : Car
    {
        protected override void InitImages()
        {
            images = new MoveStuff();
            images.vehicleImage = new string[20];
            images.vehicleImage[0] = "                                                                 __......_";
            images.vehicleImage[1] = "                                  .---.       _________    _.---`.-----_.'|";
            images.vehicleImage[2] = "                                 ;     `.   (_   (_  _('\\.' .--``   _.'   |";
            images.vehicleImage[3] = "                                 `._//_.'    |   |   |   |.'     .-`     .'";
            images.vehicleImage[4] = "                       ,-. ,-.     //  (| _.' _.'_..-`   |..___.'        |";
            images.vehicleImage[5] = "        _             (O)_(O)_)_  //    ;(..(..(        .'     |        .'";
            images.vehicleImage[6] = "     ,-'\"'--------` -| |-.\\//     :|     |       /     '=|        |";
            images.vehicleImage[7] = "    ,'|`.            `---` \\\\      |/___ /_......'        '-.....-`/";
            images.vehicleImage[8] = "    |I|II\\________ .---.____|| __..'    /       |        /   ____  |";
            images.vehicleImage[9] = "  .'|I|II|        `----._`-.  `-..____.'        |____...`.-``    ```-..";
            images.vehicleImage[10] ="  / |I|II|   .-````````-.`-.`.                         .'' .-``````-. ``.";
            images.vehicleImage[11] =
                ".  /`.|II|  ' .-``````-. `  \\ `.                      / / / \\\\ || // \\ \\ \\";
            images.vehicleImage[12] =
                "' .---.`.| / / \\ || // \\ \\  \\  \\--------------------; : .   \\\\||//   . : \\";
            images.vehicleImage[13] = "; '   //  : .   \\||//   . :  \\  \\__________________:  | :----````----; ' |";
            images.vehicleImage[14] =
                "\\ './/   . :----````----; '   | |==================|  ; ;----.__,----: : \\";
            images.vehicleImage[15] =
                "  `. `-...' ;----.__,----: :`--|_| .-. \\ '.// || \\.'-.| '   //||\\\\   ' ;-`";
            images.vehicleImage[16] = "   `-....; '   //||\\   ' ;            `. `-....-` .'  \\ '.// || \\\\.' /";
            images.vehicleImage[17] = "          \\ '.// || \\.' /  .-.          `-......-' _.-.`. `-....-` .'";
            images.vehicleImage[18] = "     .-._ `. `-....-` .'                .-.              `-......-'  -.";
            images.vehicleImage[19] = " .-._       `-......-'    .-._                   _.-.        .-._\"";

        }
        
        public FirstCar()
        {
            Weight = 300;
            Age = 131;
            Brand = "Benz Truck";
            InitImages();
        }

        public override void Info()
        {
            Console.WriteLine($"This is first car. It's age is {Age}. Brand is {Brand}");
        }
        
    }

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