using System.ComponentModel.DataAnnotations;

namespace PhotographyWorksho.Models
{
    public class MirrorlessCamera
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public bool? IsFullFrameOrNot { get; set; }
        [Required]
        [Range(100, int.MaxValue, ErrorMessage = "Min ISO cannot be lower than 100!")]
        public int MinIso { get; set; }
        public int? MaxIso { get; set; }
        public string MaxVideoResolution { get; set; }
        public int? MaxFrameRate { get; set; }
    }
}
