using Microsoft.AspNetCore.Mvc;
using Pri.ThomasVanMaelePEtwee.core.Entities;
using Pri.ThomasVanMaelePEtwee.core.Services.Interfaces;

namespace Pri.ThomasVanMaelePEtwee.mvc.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationService<Quotation> _quotationService;

        public QuotationController(IQuotationService<Quotation> quotationService)
        {
            _quotationService = quotationService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
