using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessLogic
{
    public class VendorRequestBl : IVendorRequestBl
    {
        private readonly IVendorRequestBr mAddtionalInfoBr;
        public VendorRequestBl(IVendorRequestBr iAddtionalInfoBr)
        {
            mAddtionalInfoBr = iAddtionalInfoBr;    
        }
        public async Task<string> Create(VendorRequestUpdateRequestModel addtionalInfoUpdateModel)
        {
          return  await  mAddtionalInfoBr.Create(addtionalInfoUpdateModel);
        }

        public async Task<string> Update(VendorRequestUpdateRequestModel addtionalInfoUpdateModel)
        {
          return await mAddtionalInfoBr.Update(addtionalInfoUpdateModel);
        }
    }
}
