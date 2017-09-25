namespace Student_System.Models
{
    public class License
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ResourseId { get; set; }

        public Resource Resource { get; set; }
    }
}
