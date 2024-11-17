using System.ComponentModel.DataAnnotations;

namespace Pri.ThomasVanMaelePEtwee.mvc.Models
{
    public class SwimmingPoolCreateViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Length is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Length must be a positive value.")]
        public float Length { get; set; }
        [Required(ErrorMessage = "Width is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Width must be a positive value.")]
        public float Width { get; set; }
        [Required(ErrorMessage = "Depth is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Depth must be a positive value.")]
        public float Depth { get; set; }
        public bool HasHeating { get; set; }
    }
}
