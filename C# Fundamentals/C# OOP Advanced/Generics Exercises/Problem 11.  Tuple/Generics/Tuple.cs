namespace Problem_11.Tuple.Generics
{
    public class Tuple<K, V>
    {
        private readonly K key;
        private readonly V value;

        public Tuple(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
