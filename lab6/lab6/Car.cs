using System;
using System.Threading;

namespace lab6
{
    class Car : IVehicle, ICloneable, IComparable
        {
            protected uint Weight { get; set; }
            protected uint Age { get; set; }
            protected uint FuelCapacity { get; set;}
            protected uint CurrentFuel { get; set; }
            protected uint FuelUsage { get; set; }
            protected string Brand { get; set; }
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
            
            public void Info()
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

            public object Clone()
            {
                return new Car(Weight, Age, FuelCapacity, CurrentFuel, FuelUsage, Brand);
            }

            public int CompareTo(object o)
            {
                Car car = (Car)o;
                if (car != null)
                {
                    return Age.CompareTo(car.Age);
                }
                throw new Exception("Cannot compare two cars");
            }
        }
}