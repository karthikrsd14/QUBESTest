using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic.IBussinessLogic
{
    public interface IMasterBl
    {
        Task<List<CountryListResponseModel>> GetAllCountry();
        Task<List<StateListResponseModel>> GetStatesById(int countryId);
        Task<List<CategoryListResponseModel>> GetAllCategory();
    }
}
