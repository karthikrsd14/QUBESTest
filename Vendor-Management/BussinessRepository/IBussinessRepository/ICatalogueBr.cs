using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessRepository.IBussinessRepository
{
    public interface ICatalogueBr
    {
        Task<string> Create(CatalogueRequestModel catalogueRequestModel);
        Task<string> Update(CatalogueRequestModel catalogueRequestModel);
        Task<List<CatalogueResponseModel>> GetCatalougeByUserId(int userId);
        Task<List<CatalogueResponseModel>> GetCatalougeByCriteria(int userId, string? criteria);
        Task<bool> DeleteCatalouge(int Id);
    }
}
