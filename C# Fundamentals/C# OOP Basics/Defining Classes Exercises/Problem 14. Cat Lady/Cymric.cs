namespace Problem_14.Cat_Lady
{
    public class Cymric : Cat
    {
        public double FurLenght { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.FurLenght:f2}";
        }
    }
}
