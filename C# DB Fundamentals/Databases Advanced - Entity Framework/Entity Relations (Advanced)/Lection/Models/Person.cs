namespace Lection.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PlaceOfBirthId { get; set; }
        public int? CurrentResidenceId { get; set; }

        public virtual Town PlaceOfBirth { get; set; }
        public virtual Town CurrentResidence { get; set; }
    }
}
