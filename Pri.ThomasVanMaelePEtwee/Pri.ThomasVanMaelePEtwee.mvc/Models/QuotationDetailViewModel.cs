using Pri.ThomasVanMaelePEtwee.core.Entities;
using Pri.ThomasVanMaelePEtwee.core.Enums;

namespace Pri.ThomasVanMaelePEtwee.mvc.Models
{
    public class QuotationDetailViewModel
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public string UserName { get; set; }
        public ICollection<string> SwimmingpoolNames { get; set; } = new List<string>();
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public QuotationStatus Status { get; set; }
        public string? CustomerComment { get; set; }
        public string? AdminComment { get; set; }
    }
}
