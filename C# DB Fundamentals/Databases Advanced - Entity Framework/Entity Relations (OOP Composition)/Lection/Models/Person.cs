namespace Lection.Models
{
    // Person & Town Multiple Relation
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Town PlaceOfBirth { get; set; }
        public virtual Town CurrentResidence { get; set; }
    }
}
