using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.SwimmingPool
{
    public class SwimmingPoolCreateRequestModel
    {
        public string Name { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
        public bool HasHeating { get; set; }
        public int? QuotationId { get; set; }
    }
}
