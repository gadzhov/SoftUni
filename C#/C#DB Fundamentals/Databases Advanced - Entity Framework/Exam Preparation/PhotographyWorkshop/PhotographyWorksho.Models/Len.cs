namespace PhotographyWorksho.Models
{
    public class Len
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public int FocalLenght { get; set; }
        public double MaxAperture { get; set; }
        public string CompatibleWith { get; set; }
        public int OwnerId { get; set; }
        public virtual Photographer Owner { get; set; }
    }
}
