using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessRepository.IBussinessRepository
{
    public interface IMasterBr
    {
        Task<List<CountryListResponseModel>> GetAllCountry();
        Task<List<StateListResponseModel>> GetStatesById(int countryId);
        Task<List<CategoryListResponseModel>> GetAllCategory();
    }
}
