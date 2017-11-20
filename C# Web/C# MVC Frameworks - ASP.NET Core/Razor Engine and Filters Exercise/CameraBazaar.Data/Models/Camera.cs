namespace CameraBazaar.Data.Models
{
    using CameraBazaar.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Camera
    {
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required]
        [RegularExpression("^[A-Z-0-9]+$", ErrorMessage = "The {0} can contain only uppercase letters, digits and dash ('-'). Cannot be empty")]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "The {0} must be in range {1}-{2}.")]
        public int Quantity { get; set; }

        [Display(Name = "Minimum Shutter Speed")]
        [Range(1, 30, ErrorMessage = "The {0} must be in range {1}-{2}.")]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Maximum Shutter Speed")]
        [Range(2000, 8000, ErrorMessage = "The {0} must be in range {1}-{2}.")]
        public int MaxShutterSpeed { get; set; }

        public MinIso MinIso { get; set; }

        [Range(200, 409600, ErrorMessage = "The {0} must be in range {1}-{2}.")]
        [RegularExpression("\\d+00$", ErrorMessage = "The {0} must be dividable by 100.")]
        public int MaxIso { get; set; }

        public bool IsFullFrame { get; set; }

        [StringLength(15, ErrorMessage = "The {0} must be no longer than {1} symbols.")]
        public string VideoResolution { get; set; }

        [Required]
        [RegularExpression("(Spot|CenterWeighted|Evaluative)", ErrorMessage = "This is required.")]
        public LightMetering LightMetering { get; set; }

        [StringLength(6000, ErrorMessage = "The {0} must be no longer than {1} symbols.")]
        public string Description { get; set; }

        [RegularExpression(@"^(http:\/\/|https:\/\/).+", ErrorMessage = "The {0} must start with 'http://' or 'https://'.")]
        public string ImageUrl { get; set; }
    }
}
