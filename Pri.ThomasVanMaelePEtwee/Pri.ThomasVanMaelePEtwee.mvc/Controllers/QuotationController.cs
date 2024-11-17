using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pri.ThomasVanMaelePEtwee.core.Data;
using Pri.ThomasVanMaelePEtwee.core.Entities;
using Pri.ThomasVanMaelePEtwee.core.Services.Interfaces;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.Quotation;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.SwimmingPool;
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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var resultAdmin = await _quotationService.GetAllAsync();
            var resultCustomer = await _quotationService.GetAllQuotationsByUserIDAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!resultAdmin.IsSuccess || !resultCustomer.IsSuccess)
            {

                ViewBag.ErrorMessage = "Could not retrieve quotations. Please try again later.";
                return View("Error");
            }

            var viewModel = new QuotationIndexViewModel();

            var quotations = User.IsInRole("Admin") ? resultAdmin.Data : resultCustomer.Data;

            var quotationViewModels = quotations.Select(q => new QuotationDetailViewModel
            {
                Id = q.Id,
                Price = q.Price,
                UserName = User.IsInRole("Admin") ? q.User.UserName : User.Identity.Name, //checken
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
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateQuotation()
        {
            var vm = new CreateQuotationWithPoolViewModel
            {
                SwimmingPool = new SwimmingPoolCreateViewModel(),
                Quotation = new QuotationCreateViewModel()
            };
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuotation(CreateQuotationWithPoolViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var pool = new SwimmingPoolCreateRequestModel
            {
                Depth = vm.SwimmingPool.Depth,
                HasHeating = vm.SwimmingPool.HasHeating,
                Length = vm.SwimmingPool.Length,
                Name = vm.SwimmingPool.Name,
                Width = vm.SwimmingPool.Width,
            };
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var quotation = new QuotationCreateRequestModel
            {
                UserId = userId,
                CustomerComment = vm.Quotation.CustomerComment,

            };

            var result = await _quotationService.CreateAsyncQuotation(quotation, pool);

            if (!result.IsSuccess)
            {
                ViewBag.ErrorMessage = $"Could not add quotation: {result.Errors.FirstOrDefault()}";
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateQuotation(int quotationId)
        {
            var quotationResult = await _quotationService.GetQuotationbyIdAsync(quotationId);
            

            if (!quotationResult.IsSuccess)
            {
                ViewBag.ErrorMessage = $"Could not add quotation: {quotationResult.Errors.FirstOrDefault()}";
                return View();
            }

            var vm = new QuotationUpdateViewModel
            {
                Id = quotationId,
                AdminComment = quotationResult.Data.AdminComment,
                CustomerComment = quotationResult.Data.CustomerComment,
                Price = quotationResult.Data.Price,
                
            };

            return View(vm);

        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuotation(QuotationUpdateViewModel vm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            if (User.IsInRole("Admin"))
            {
                var quotationAdmin = new QuotationUpdateRequestModel
                {
                    AdminComment = vm.AdminComment,
                    Price = vm.Price,
                    UserId = userId,
                    Id = vm.Id
                };
                var resultAdmin = await _quotationService.UpdateAsyncQuotation(quotationAdmin);
                if (!resultAdmin.IsSuccess)
                {
                    ViewBag.ErrorMessage = $"Could not add quotation: {resultAdmin.Errors.FirstOrDefault()}";
                    return View(vm);
                }
            }
            else {
            var quotation = new QuotationUpdateRequestModel
            {
                UserId = userId,
                CustomerComment = vm.CustomerComment,
                Id = vm.Id
            };

            var result = await _quotationService.UpdateAsyncQuotation(quotation);
            if (!result.IsSuccess)
            {
                ViewBag.ErrorMessage = $"Could not add quotation: {result.Errors.FirstOrDefault()}";
                return View(vm);
            }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuotationConfirmed(int id)
        {
            var result = await _quotationService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                ViewBag.ErrorMessage = $"Could not delete quotation: {result.Errors.FirstOrDefault()}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
