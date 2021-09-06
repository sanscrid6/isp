namespace lab1.Entities
{
    public class Room
    {
        private static int count = 0;
        public int Number { get; private set; }
        public int Cost { get; private set; }

        public Client Client { get; set; }

        public Room(int cost)
        {
            Cost = cost;
            Number = count + 1;
            count++;
        }

        public override string ToString()
        {
            return $"Номер {Number}, цена {Cost}";
        }
    }
}