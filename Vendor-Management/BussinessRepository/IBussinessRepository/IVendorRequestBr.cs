using System.Threading.Tasks;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessRepository.IBussinessRepository
{
    public interface IVendorRequestBr
    {
        Task<string> Create(VendorRequestUpdateRequestModel vendorRequestUpdateRequestModel);
        Task<string> Update(VendorRequestUpdateRequestModel vendorRequestUpdateRequestModel);
        
    }
}
