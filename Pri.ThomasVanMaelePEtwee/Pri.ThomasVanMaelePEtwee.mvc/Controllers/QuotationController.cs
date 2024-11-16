using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Pri.ThomasVanMaelePEtwee.core.Data;
using Pri.ThomasVanMaelePEtwee.core.Entities;
using Pri.ThomasVanMaelePEtwee.core.Services.Interfaces;
using Pri.ThomasVanMaelePEtwee.mvc.Models;
using System.Security.Claims;

namespace Pri.ThomasVanMaelePEtwee.mvc.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationService<Quotation> _quotationService;
        private readonly PoolDbContext _poolContext;
        public QuotationController(IQuotationService<Quotation> quotationService, PoolDbContext poolDbContext)
        {
            _quotationService = quotationService;
            _poolContext = poolDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var resultAdmin = await _quotationService.GetAllAsync();
            var resultCustomer = await _quotationService.GetbyIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!resultAdmin.IsSuccess || !resultCustomer.IsSuccess)
            {

                ViewBag.ErrorMessage = "Could not retrieve quotations. Please try again later.";
                return View("Error");
            }
            var viewModel = new QuotationIndexViewModel();

            if (User.IsInRole("Admin"))
            {
                var quotationViewModels = resultAdmin.Data.Select(q => new QuotationDetailViewModel
                {
                    Id = q.Id,
                    Price = q.Price,
                    UserName = q.User?.UserName,
                    SwimmingpoolNames = q.Pools.Select(p => p.Name).ToList(),
                    RequestDate = q.RequestDate,
                    ResponseDate = q.ResponseDate,
                    Status = q.Status,
                    CustomerComment = q.CustomerComment,
                    AdminComment = q.AdminComment
                }).ToList();
               
                viewModel.Quotations = quotationViewModels;
                return View(viewModel);
            }

            else 
            {
                var quotationViewModels = resultCustomer.Data.Select(q => new QuotationDetailViewModel
                {
                    Id = q.Id,
                    Price = q.Price,
                    UserName = q.User?.UserName,
                    SwimmingpoolNames = q.Pools.Select(p => p.Name).ToList(),
                    RequestDate = q.RequestDate,
                    ResponseDate = q.ResponseDate,
                    Status = q.Status,
                    CustomerComment = q.CustomerComment,
                    AdminComment = q.AdminComment
                }).ToList();

                viewModel.Quotations = quotationViewModels;
                return View(viewModel);
            }
            var vm = result.Data.Select(c => new CarInfoViewModel
            {
                Id = c.Id,
                ModelName = c.Model,
                Brand = c.Brand,
                TopSpeed = c.TopSpeed,
                Description = c.Description,
                CategoryName = c.Category.Name,
            }).ToList();

            return View(vm);
        }
    }
}
