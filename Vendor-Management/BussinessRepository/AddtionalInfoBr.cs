using System.Threading.Tasks;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.VendorManagementContext;

namespace Vendor_Management.BussinessRepository
{
    public class AddtionalInfoBr : IAddtionalInfoBr
    {
        private readonly ERPDbContext mERPDbContext;

        public AddtionalInfoBr(ERPDbContext iERPDbContext)
        {
                mERPDbContext = iERPDbContext;
        }
        public async Task<string> Create(AddtionalInfoUpdateModel addtionalInfoUpdateModel)
        {
            AddtionalInfo addtionalInfoRequest = new AddtionalInfo
            {
                AdditionalInfo = addtionalInfoUpdateModel.AdditionalInfo,
                AlternativeApprover = addtionalInfoUpdateModel.AlternativeApprover,
                CommentBox = addtionalInfoUpdateModel.CommentBox,
                PrimaryApprover = addtionalInfoUpdateModel.PrimaryApprover,
                RisedBy = addtionalInfoUpdateModel.RisedBy,
                VendorId = addtionalInfoUpdateModel.VendorId,
               
            };
         mERPDbContext.AddtionalInfo.Add(addtionalInfoRequest);
           await mERPDbContext.SaveChangesAsync();

            return $"Created -{addtionalInfoRequest.Id}";
        }

        public async Task<string> Update(AddtionalInfoUpdateModel addtionalInfoUpdateModel)
        {
            AddtionalInfo addtionalInfoRequest = new AddtionalInfo
            {
                AdditionalInfo = addtionalInfoUpdateModel.AdditionalInfo,
                AlternativeApprover = addtionalInfoUpdateModel.AlternativeApprover,
                CommentBox = addtionalInfoUpdateModel.CommentBox,
                PrimaryApprover = addtionalInfoUpdateModel.PrimaryApprover,
                RisedBy = addtionalInfoUpdateModel.RisedBy,
                VendorId = addtionalInfoUpdateModel.VendorId,
            };
            mERPDbContext.AddtionalInfo.Update(addtionalInfoRequest);
            await mERPDbContext.SaveChangesAsync();

            return $"Update -{addtionalInfoRequest.Id}";
        }
    }
}
