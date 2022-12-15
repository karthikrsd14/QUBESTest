using System.Threading.Tasks;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.VendorManagementContext;

namespace Vendor_Management.BussinessRepository
{
    public class VendorRequestBr : IVendorRequestBr
    {
        private readonly ERPDbContext mERPDbContext;

        public VendorRequestBr(ERPDbContext iERPDbContext)
        {
                mERPDbContext = iERPDbContext;
        }
        public async Task<string> Create(VendorRequestUpdateRequestModel vendorRequestUpdateRequestModel)
        {
            VendorRequest vendorRequest = new VendorRequest
            {
                AdditionalInfo = vendorRequestUpdateRequestModel.AdditionalInfo,
                AlternativeApprover = vendorRequestUpdateRequestModel.AlternativeApprover,
                CommentBox = vendorRequestUpdateRequestModel.CommentBox,
                PrimaryApprover = vendorRequestUpdateRequestModel.PrimaryApprover,
                RisedBy = vendorRequestUpdateRequestModel.RisedBy,
                VendorId = vendorRequestUpdateRequestModel.VendorId,
               
            };
         mERPDbContext.VendorRequest.Add(vendorRequest);
           await mERPDbContext.SaveChangesAsync();

            return $"Created -{vendorRequest.Id}";
        }

        public async Task<string> Update(VendorRequestUpdateRequestModel vendorRequestUpdateRequestModel)
        {
            VendorRequest vendorRequest = new VendorRequest
            {
                AdditionalInfo = vendorRequestUpdateRequestModel.AdditionalInfo,
                AlternativeApprover = vendorRequestUpdateRequestModel.AlternativeApprover,
                CommentBox = vendorRequestUpdateRequestModel.CommentBox,
                PrimaryApprover = vendorRequestUpdateRequestModel.PrimaryApprover,
                RisedBy = vendorRequestUpdateRequestModel.RisedBy,
                VendorId = vendorRequestUpdateRequestModel.VendorId,
            };
            mERPDbContext.VendorRequest.Update(vendorRequest);
            await mERPDbContext.SaveChangesAsync();

            return $"Update -{vendorRequest.Id}";
        }
    }
}
