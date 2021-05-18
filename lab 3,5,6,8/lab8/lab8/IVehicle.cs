namespace lab8
{
    interface IVehicle
    {
        void Move(uint distanse);
        void Move(uint distance, uint speed);
        void Info();
    }
}