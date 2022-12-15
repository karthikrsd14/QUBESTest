using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic
{
    public class CatalogueBl : ICatalogueBl
    {
        private readonly ICatalogueBr mCatalogueBr;
        public CatalogueBl(ICatalogueBr iCatalogueBr)
        {
            mCatalogueBr = iCatalogueBr;
        }

        public async Task<string> Create(CatalogueRequestModel catalogueRequestModel)
        {
            return await mCatalogueBr.Create(catalogueRequestModel);
        }

        public async Task<List<CatalogueResponseModel>> GetCatalougeByCriteria(int userId, string criteria)
        {
            return await mCatalogueBr.GetCatalougeByCriteria(userId, criteria);
        }

        public async Task<List<CatalogueResponseModel>> GetCatalougeByUserId(int userId)
        {
            return await mCatalogueBr.GetCatalougeByUserId(userId);
        }

        public async Task<string> Update(CatalogueRequestModel catalogueRequestModel)
        {
            return await mCatalogueBr.Update(catalogueRequestModel);
        }
        public async Task<bool> DeleteCatalouge(int Id)
        {
            return await mCatalogueBr.DeleteCatalouge(Id);
        }
    }
}
