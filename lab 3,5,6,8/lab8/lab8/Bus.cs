using System;

namespace lab8
{
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
        
        public Bus(uint weight, uint age, uint fuelCapacity, uint currentFuel,uint fuelUsage, string brand, 
            uint capacity, ReachDestinationHandler destHandler)
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
            ReachDestination += destHandler;
        }
        
        public void Info()
        {
            Console.WriteLine($"Id is {id}. Type is {type}. Brand is {Brand}. Weight is {Weight}." +
                              $" Age is {Age}. Fuel capacity is {FuelCapacity}. Current fuel level is " +
                              $"{(float)CurrentFuel/FuelCapacity*100}%.");
        }
    }
}