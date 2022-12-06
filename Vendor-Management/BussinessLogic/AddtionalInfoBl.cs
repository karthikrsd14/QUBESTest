using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;

namespace Vendor_Management.BussinessLogic
{
    public class AddtionalInfoBl : IAddtionalInfoBl
    {
        private readonly IAddtionalInfoBr mAddtionalInfoBr;
        public AddtionalInfoBl(IAddtionalInfoBr iAddtionalInfoBr)
        {
            mAddtionalInfoBr = iAddtionalInfoBr;    
        }
        public async Task<string> Create(AddtionalInfoUpdateModel addtionalInfoUpdateModel)
        {
          return  await  mAddtionalInfoBr.Create(addtionalInfoUpdateModel);
        }

        public async Task<string> Update(AddtionalInfoUpdateModel addtionalInfoUpdateModel)
        {
          return await mAddtionalInfoBr.Update(addtionalInfoUpdateModel);
        }
    }
}
