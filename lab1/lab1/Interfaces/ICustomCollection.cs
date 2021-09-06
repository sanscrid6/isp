namespace lab1.Interfaces
{
    public interface ICustomCollection<T>
    {
        void Reset();

        void Next();

        T this[int index] { get; set; }

        T Current();

        int Count();

        void Add(T item);

        void Remove(T item);

        T RemoveCurrent();
    }
}