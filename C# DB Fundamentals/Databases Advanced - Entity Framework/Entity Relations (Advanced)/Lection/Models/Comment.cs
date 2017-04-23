namespace Lection.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ChirpRefId { get; set; }
        public virtual Chirp Chirp { get; set; }
    }
}
