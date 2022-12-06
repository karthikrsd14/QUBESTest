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
        public async Task<string> Create(AddtionalInfoUpdateModel vendorRequestUpdateModel)
        {
            AddtionalInfo vendorRequest = new AddtionalInfo
            {
                AdditionalInfo = vendorRequestUpdateModel.AdditionalInfo,
                AlternativeApprover = vendorRequestUpdateModel.AlternativeApprover,
                CommentBox = vendorRequestUpdateModel.CommentBox,
                PrimaryApprover = vendorRequestUpdateModel.PrimaryApprover,
                RisedBy = vendorRequestUpdateModel.RisedBy,
                VendorId = vendorRequestUpdateModel.VendorId,
               
            };
         mERPDbContext.AddtionalInfo.Add(vendorRequest);
           await mERPDbContext.SaveChangesAsync();

            return $"Created -{vendorRequest.Id}";
        }

        public async Task<string> Update(AddtionalInfoUpdateModel vendorRequestUpdateModel)
        {
            AddtionalInfo vendorRequest = new AddtionalInfo
            {
                AdditionalInfo = vendorRequestUpdateModel.AdditionalInfo,
                AlternativeApprover = vendorRequestUpdateModel.AlternativeApprover,
                CommentBox = vendorRequestUpdateModel.CommentBox,
                PrimaryApprover = vendorRequestUpdateModel.PrimaryApprover,
                RisedBy = vendorRequestUpdateModel.RisedBy,
                VendorId = vendorRequestUpdateModel.VendorId,
            };
            mERPDbContext.AddtionalInfo.Update(vendorRequest);
            await mERPDbContext.SaveChangesAsync();

            return $"Update -{vendorRequest.Id}";
        }
    }
}
