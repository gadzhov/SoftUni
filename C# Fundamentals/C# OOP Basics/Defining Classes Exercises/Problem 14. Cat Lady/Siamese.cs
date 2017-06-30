namespace Problem_14.Cat_Lady
{
    public class Siamese : Cat
    {
        public int EarSize { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.EarSize}";
        }
    }
}
