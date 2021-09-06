namespace lab1.Collections
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T data = default, Node<T> node = null)
        {
            this.data = data;
            this.next = node;
        }
    }
}