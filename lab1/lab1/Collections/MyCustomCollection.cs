using System;
using lab1.Interfaces;

namespace lab1.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        private Node<T> head;
        private int count;
        private Node<T> current;

        public void Reset() => current = head;

        public void Next()
        {
            current = current.next;
        }

        public T Current() => current.data;

        public int Count() => count;

        public void Add(T item)
        {
            if (head == null)
            {
                head = new Node<T>(item);
                current = head;
            }
            else
            {
                var node = new Node<T>(item);
                current.next = node;
            }

            count++;
        }

        public void Remove(T item)
        {
            var curNode = head;
            Node<T> prevNode = null;
            
            for (int i = 0; i < count; i++)
            {
                if (curNode.data.Equals(item))
                {
                    DeleteNode(curNode, prevNode);
                }

                prevNode = curNode;
                curNode = curNode.next;
            }

            //throw new MyException();
        }

        private void DeleteNode(Node<T> curNode, Node<T> prevNode)
        {
            if (curNode.next == null)
            {
                prevNode.next = null;
            }
            else if (prevNode == null)
            {
                if (curNode.next == null)
                {
                    head = null;
                }
                else
                {
                    head = head.next;
                }
            }
            else
            {
                prevNode.next = curNode.next;
            }
        }

        public T RemoveCurrent()
        {
            var item = current;
            Remove(current.data);
            current = null;
            return item.data;
        }


        public bool Find(Predicate<T> predicate, out T value)
        {
            Reset();
            value = default;
            for (int i = 0; i < Count(); i++)
            {
                var curr = Current();
                if (predicate(curr))
                {
                    value = curr;
                    return true;
                }
                Next();
            }

            return false;
        }

        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    //throw new MyException();
                }

                var node = head;
                for (int i = 0; i < index; i++)
                {
                    node = node.next;
                }

                return node.data;
            }
            set
            {
                if (index >= count || index < 0)
                {
                    //throw new MyException();
                }

                var node = head;
                for (int i = 0; i <= index; i++)
                {
                    node = node.next;
                }

                node.data = value;
            }
        }
    }
}