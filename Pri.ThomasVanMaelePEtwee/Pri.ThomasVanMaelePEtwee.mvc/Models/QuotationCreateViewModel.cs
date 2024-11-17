using Pri.ThomasVanMaelePEtwee.core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pri.ThomasVanMaelePEtwee.mvc.Models
{
    public class QuotationCreateViewModel
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal? Price { get; set; }
        [MaxLength(500, ErrorMessage = "Customer comment cannot exceed 500 characters.")]
        public string? CustomerComment { get; set; }
        [MaxLength(500, ErrorMessage = "Customer comment cannot exceed 500 characters.")]
        public string? AdminComment { get; set; }
    }
}
