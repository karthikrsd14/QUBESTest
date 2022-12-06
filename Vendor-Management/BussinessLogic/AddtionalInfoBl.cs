using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessLogic
{
    public class AddtionalInfoBl : IAddtionalInfoBl
    {
        private readonly IAddtionalInfoBr mvendorRequestBr;
        public AddtionalInfoBl(IAddtionalInfoBr ivendorRequestBr)
        {
            mvendorRequestBr = ivendorRequestBr;    
        }
        public async Task<string> Create(AddtionalInfoUpdateModel vendorRequestUpdateModel)
        {
          return  await  mvendorRequestBr.Create(vendorRequestUpdateModel);
        }

        public async Task<string> Update(AddtionalInfoUpdateModel vendorRequestUpdateModel)
        {
          return await mvendorRequestBr.Update(vendorRequestUpdateModel);
        }
    }
}
