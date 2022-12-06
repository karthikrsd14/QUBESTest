using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Response;
using Vendor_Management.VendorManagementContext;

namespace Vendor_Management.BussinessRepository
{
    public class MasterBr : IMasterBr
    {
        private readonly ERPDbContext mERPDbContext;
        public MasterBr(ERPDbContext iERPDbContext)
        {
            mERPDbContext = iERPDbContext;
        }

        public async Task<List<CategoryListResponseModel>> GetAllCategory()
        {
            List<CategoryListResponseModel> categoryLists = await (from category in mERPDbContext.Category
                                                                   select new CategoryListResponseModel
                                                                   { 
                                                                       Id = category.Id,
                                                                       Name = category.Name,
                                                                   }).ToListAsync();
            return categoryLists;
        }

        public async Task<List<CountryListResponseModel>> GetAllCountry()
        {
            List<CountryListResponseModel> countryList = await (from country in mERPDbContext.Country
                                                                select new CountryListResponseModel
                                                                { 
                                                                    Id = country.Id,
                                                                    Name = country.Name,
                                                                }).ToListAsync();
            return countryList;
        }

        public async Task<List<StateListResponseModel>> GetStatesById(int countryId)
        {
            List<StateListResponseModel> stateLists = await (from states in mERPDbContext.State
                                                             where states.CountryId == countryId
                                                             select new StateListResponseModel
                                                             {
                                                                 Id = states.Id,
                                                                 Name = states.Name,
                                                             }).ToListAsync();
            return stateLists;
        }
    }
}
