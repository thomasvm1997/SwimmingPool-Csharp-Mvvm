using Pri.ThomasVanMaelePEtwee.core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pri.ThomasVanMaelePEtwee.core.Entities
{
    public class Quotation
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<SwimmingPool> Pools { get; set; } = new List<SwimmingPool>();
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public QuotationStatus Status { get; set; }
    }
}
