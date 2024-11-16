using Pri.ThomasVanMaelePEtwee.core.Entities;
using Pri.ThomasVanMaelePEtwee.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.Quotation
{
    public class QuotationCreateRequestModel
    {
        
        public decimal? Price { get; set; }
        public string UserId { get; set; }
        public IEnumerable<int>? PoolId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public QuotationStatus Status { get; set; }

        public string? CustomerComment { get; set; }
        public string? AdminComment { get; set; }
    }
}
