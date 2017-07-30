namespace Problem_9.Linked_List_Traversal.Generics
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }

        public LinkedListNode<T> Next { get; set; }

        public T Value { get; private set; }
    }
}
