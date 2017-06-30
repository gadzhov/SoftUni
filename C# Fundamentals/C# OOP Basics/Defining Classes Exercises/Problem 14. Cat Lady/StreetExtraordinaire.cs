namespace Problem_14.Cat_Lady
{
    public class StreetExtraordinaire : Cat
    {
        public int DecibelsOfMeows { get; set; }

        public override string ToString()
        {
            return $"{this.Type} {this.Name} {this.DecibelsOfMeows}";
        }
    }
}
