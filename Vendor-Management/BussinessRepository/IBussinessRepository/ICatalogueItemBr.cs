using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessRepository.IBussinessRepository
{
    public interface ICatalogueItemBr
    {
        Task<string> Created(CatalogueItemUpdateRequestModel catalogueItemupdateRequestModel);
        Task<string> Update(CatalogueItemUpdateRequestModel catalogueItemupdateRequestModel);
        Task<List<CatalogueItemResponceModel>> GellAllCatalogueItem();
    }
}
