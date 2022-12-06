using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic
{
    public class MasterBl : IMasterBl
    {
        private readonly IMasterBr masterBr;
        public MasterBl(IMasterBr iMasterBr)
        {
            masterBr = iMasterBr;
        }

        public async Task<List<CategoryListResponseModel>> GetAllCategory()
        {
            return await masterBr.GetAllCategory();
        }

        public async Task<List<CountryListResponseModel>> GetAllCountry()
        {
            return await masterBr.GetAllCountry();
        }

        public async Task<List<StateListResponseModel>> GetStatesById(int countryId)
        {
            return await masterBr.GetStatesById(countryId);
        }
    }
}
