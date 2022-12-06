using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessLogic
{
    public class VendorRequestBl : IVendorRequestBl
    {
        private readonly IVendorRequestBr mvendorRequestBr;
        public VendorRequestBl(IVendorRequestBr ivendorRequestBr)
        {
            mvendorRequestBr = ivendorRequestBr;    
        }
        public async Task<string> Create(VendorRequestUpdateModel vendorRequestUpdateModel)
        {
          return  await  mvendorRequestBr.Create(vendorRequestUpdateModel);
        }

        public async Task<string> Update(VendorRequestUpdateModel vendorRequestUpdateModel)
        {
          return await mvendorRequestBr.Update(vendorRequestUpdateModel);
        }
    }
}
