using System.Threading.Tasks;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessLogic.IBussinessLogic
{
    public interface IVendorRequestBl
    {
        Task<string> Create(VendorRequestUpdateModel vendorRequestUpdateModel);
        Task<string> Update(VendorRequestUpdateModel vendorRequestUpdateModel);
    }
}
