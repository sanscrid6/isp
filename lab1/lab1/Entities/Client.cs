namespace lab1.Entities
{
    public class Client
    {
        public string SourName { get; private set; }

        public Room Room { get; set; }

        public Client(string name)
        {
            SourName = name;
        }

        public override string ToString()
        {
            return Room.ToString();
        }
    }
}