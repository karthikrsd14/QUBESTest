using System.Threading.Tasks;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessRepository.IBussinessRepository
{
    public interface IAddtionalInfoBr
    {
        Task<string> Create(AddtionalInfoUpdateModel vendorRequestUpdateModel);
        Task<string> Update(AddtionalInfoUpdateModel vendorRequestUpdateModel);
        
    }
}
