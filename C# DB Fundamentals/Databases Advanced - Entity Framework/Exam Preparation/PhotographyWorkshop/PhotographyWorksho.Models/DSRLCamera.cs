using System.ComponentModel.DataAnnotations;

namespace PhotographyWorksho.Models
{
    public class DSRLCamera
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public bool? IsFullFrameOrNot { get; set; }
        [Required]
        [Range(100, int.MaxValue, ErrorMessage = "Min ISO Cannot be lower than 100!")]
        public int MinIso { get; set; }
        public int? MaxIso { get; set; }
        public int? MaxShutterSpeed { get; set; }
    }
}
