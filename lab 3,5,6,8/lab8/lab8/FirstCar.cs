using System;

namespace lab8
{
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

        public void Info()
        {
            Console.WriteLine($"This is first car. It's age is {Age}. Brand is {Brand}");
        }
        
    }
}