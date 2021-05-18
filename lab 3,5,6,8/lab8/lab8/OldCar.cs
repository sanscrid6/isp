using System;

namespace lab8
{
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
    
        public void Info()
        {
            Console.WriteLine($"This is old car of {2021-Age} year. It's age is {Age}. Brand is {Brand}");
        }
        
    }
}