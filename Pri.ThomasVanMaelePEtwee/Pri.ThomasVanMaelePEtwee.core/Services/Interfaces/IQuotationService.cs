using Pri.ThomasVanMaelePEtwee.core.Entities;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.Quotation;
using Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels.SwimmingPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.ThomasVanMaelePEtwee.core.Services.Interfaces
{
    public interface IQuotationService<T>
    {
        IQueryable<T> GetAll();
        Task<ResultModel<IEnumerable<T>>> GetAllAsync();
        Task<ResultModel<T>> GetQuotationbyIdAsync(int id);
        Task<BaseResultModel> CreateAsyncQuotation(QuotationCreateRequestModel quotationCreate, SwimmingPoolCreateRequestModel swimmingPoolCreate);
        Task<BaseResultModel> UpdateAsyncQuotation(QuotationUpdateRequestModel updateRequestModel);
        Task<ResultModel<IEnumerable<T>>> GetAllQuotationsByUserIDAsync(string userId);
        Task<BaseResultModel> DeleteAsync(int quotationId);
        Task<BaseResultModel> SaveChangesAsync();
    }
}
