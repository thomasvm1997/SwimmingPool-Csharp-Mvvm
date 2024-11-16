using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.ThomasVanMaelePEtwee.core.Data;
using Pri.ThomasVanMaelePEtwee.core.Entities;
using Pri.ThomasVanMaelePEtwee.core.Enums;
using Pri.ThomasVanMaelePEtwee.core.Services.Interfaces;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.Quotation;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.SwimmingPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Pri.ThomasVanMaelePEtwee.core.Services
{
    public class EfQuotationService : IQuotationService<Quotation>
    {
        private readonly PoolDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public EfQuotationService(PoolDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IQueryable<Quotation> GetAll()
        {
            return _dbContext.Quotations.AsQueryable();
        }

        public async Task<ResultModel<IEnumerable<Quotation>>> GetAllAsync()
        {
            var quotations = await GetAll().Include(c => c.Pools).ToListAsync();

            if (quotations.Count == 0)
            {
                return new ResultModel<IEnumerable<Quotation>>
                {
                    IsSuccess = false,
                    Errors = new List<string> { "No results found" }
                };
            }
            return new ResultModel<IEnumerable<Quotation>>
            {
                IsSuccess = true,
                Data = quotations
            };
        }

        public async Task<ResultModel<Quotation>> GetQuotationbyIdAsync(int id)
        {
            var quotation = await GetAll().Where(c => c.Id == id).FirstOrDefaultAsync();

            if (quotation == null)
            {
                return new ResultModel<Quotation>
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"Quotations with id:{id} not found" }
                };
            }
            else
            {
                return new ResultModel<Quotation>
                {
                    Data = quotation,
                    IsSuccess = true
                };
            }
        }
        public async Task<BaseResultModel> CreateAsyncQuotation(QuotationCreateRequestModel quotationCreate, SwimmingPoolCreateRequestModel swimmingPoolCreate)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == quotationCreate.UserId);
            
            foreach(var quotations in user.Quotations ) 
            {
                if (quotations.Status == QuotationStatus.Pending)
                {
                    return new BaseResultModel
                    {
                    IsSuccess = false,
                    Errors = new List<string> { "You still have a pending quotation" }
                    };
                }
            }
            

            var quotation = new Quotation
            {
                Status = QuotationStatus.Pending,
                RequestDate = DateTime.Now,
                UserId = quotationCreate.UserId,
                CustomerComment = quotationCreate.CustomerComment
            };

            _dbContext.Add(quotation);
            await SaveChangesAsync();

            var addedQuotations = await _dbContext.Quotations.LastOrDefaultAsync();

            var pool = new SwimmingPool
            {
                Width = swimmingPoolCreate.Width,
                Depth = swimmingPoolCreate.Depth,
                Length = swimmingPoolCreate.Length,
                HasHeating = swimmingPoolCreate.HasHeating,
                Name = swimmingPoolCreate.Name,
                QuotationId = addedQuotations.Id
            };


            addedQuotations.Pools.Add(pool);
            _dbContext.Add(pool);
            await SaveChangesAsync();

            return new BaseResultModel
            {
                IsSuccess = true,
            };

        }
        public async Task<BaseResultModel> UpdateAsyncQuotation(QuotationUpdateRequestModel updateRequestModel)
        {
            if (updateRequestModel == null)
            {
                return new BaseResultModel
                {
                    IsSuccess = false,
                    Errors = new List<string> { "No requestmodel found" }
                };
            }
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == updateRequestModel.UserId);

            if (user == null)
            {
                return new BaseResultModel
                {
                    IsSuccess = false,
                    Errors = new List<string> { "User not found" }
                };
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var quotationData = GetQuotationbyIdAsync(updateRequestModel.Id);
            var quotation = quotationData.Result.Data;

            if (userRoles.Contains("Admin"))
            {
                quotation.Status = updateRequestModel.Status;
                quotation.ResponseDate = DateTime.Now;
                quotation.Price = updateRequestModel.Price;
                quotation.AdminComment = updateRequestModel.AdminComment;
                await SaveChangesAsync();

                return new BaseResultModel
                {
                    IsSuccess = true
                };
            }

            else
            {
                quotation.CustomerComment = updateRequestModel.CustomerComment;
                await SaveChangesAsync();
                return new BaseResultModel
                {
                    IsSuccess = true
                };
            }
        }

        public async Task<BaseResultModel> DeleteAsync(int quotationId)
        {
            var quotationData = await GetQuotationbyIdAsync(quotationId);
            var quotation = quotationData.Data;
            if (quotation != null)
            {
                _dbContext.Remove(quotation);
                return await SaveChangesAsync();
            }
            return new BaseResultModel
            {
                IsSuccess = false,
                Errors = new List<string> { $"Quotation with {quotationId} not found" }
            };
        }


        public async Task<BaseResultModel> SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return new BaseResultModel { IsSuccess = true };
            }
            catch(DbUpdateException exceptions)
            {
                Console.WriteLine(exceptions.Message);
                return new BaseResultModel
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"Could not save changes. Error message {exceptions.Message}" }
                };
            }
        }

        public async Task<ResultModel<IEnumerable<Quotation>>> GetAllQuotationsByUserIDAsync(string userId)
        {
            var quotation = await GetAll().Where(c => c.UserId == userId).ToListAsync();

            if (quotation == null)
            {
                return new ResultModel<IEnumerable<Quotation>>
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"Quotations with id:{userId} not found" }
                };
            }
            else
            {
                return new ResultModel<IEnumerable<Quotation>>
                {
                    Data = quotation,
                    IsSuccess = true
                };
            }
        }
    }
}
