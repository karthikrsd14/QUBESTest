using System.Threading.Tasks;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessLogic.IBussinessLogic
{
    public interface IVendorRequestBl
    {
        Task<string> Create(VendorRequestUpdateRequestModel vendorRequestUpdateRequestModel);
        Task<string> Update(VendorRequestUpdateRequestModel vendorRequestUpdateRequestModel);
    }
}
