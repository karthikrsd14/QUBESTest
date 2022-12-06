using System.Threading.Tasks;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessLogic.IBussinessLogic
{
    public interface IAddtionalInfoBl
    {
        Task<string> Create(AddtionalInfoUpdateModel vendorRequestUpdateModel);
        Task<string> Update(AddtionalInfoUpdateModel vendorRequestUpdateModel);
    }
}
