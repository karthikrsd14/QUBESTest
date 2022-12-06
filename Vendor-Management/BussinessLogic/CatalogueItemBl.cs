using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic
{
    public class CatalogueItemBl : ICatalogueItemBl
    {
        private readonly ICatalogueItemBr mcatalogueItemBr;
        public CatalogueItemBl(ICatalogueItemBr icatalogueItemBr)
        {
            mcatalogueItemBr = icatalogueItemBr;
        }

        public async  Task<string> Created(CatalogueItemUpdateRequestModel catalogueItemupdateRequestModel)
        {
            return await mcatalogueItemBr.Created(catalogueItemupdateRequestModel);
        }

        public async Task<List<CatalogueItemResponceModel>> GellAllCatalogueItem()
        {
            return await mcatalogueItemBr.GellAllCatalogueItem();
        }

        public  async Task<string> Update(CatalogueItemUpdateRequestModel catalogueItemupdateRequestModel)
        {
           return await mcatalogueItemBr.Update(catalogueItemupdateRequestModel);   
        }
    }
}
