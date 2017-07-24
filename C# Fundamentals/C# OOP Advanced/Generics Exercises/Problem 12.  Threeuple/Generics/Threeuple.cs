namespace Problem_12.Threeuple.Generics
{
    public class Threeuple<I1, I2, I3>
    {
        public Threeuple(I1 item1, I2 item2, I3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        private I1 Item1 { get; }

        private I2 Item2 { get; }

        private I3 Item3 { get; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}