using System.Threading.Tasks;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessRepository.IBussinessRepository
{
    public interface IVendorRequestBr
    {
        Task<string> Create(VendorRequestUpdateModel vendorRequestUpdateModel);
        Task<string> Update(VendorRequestUpdateModel vendorRequestUpdateModel);
        
    }
}
