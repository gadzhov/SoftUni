namespace Lection.Models
{
    public class ChImg
    {
        public byte[] Image { get; set; }
        public int ChirpId { get; set; }

        public virtual Chirp Chirp { get; set; }
    }
}
