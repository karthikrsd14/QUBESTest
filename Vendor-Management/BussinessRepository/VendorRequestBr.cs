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
        public async Task<string> Create(VendorRequestUpdateModel vendorRequestUpdateModel)
        {
            VendorRequest vendorRequest = new VendorRequest
            {
                AdditionalInfo = vendorRequestUpdateModel.AdditionalInfo,
                AlternativeApprover = vendorRequestUpdateModel.AlternativeApprover,
                CommentBox = vendorRequestUpdateModel.CommentBox,
                PrimaryApprover = vendorRequestUpdateModel.PrimaryApprover,
                RisedBy = vendorRequestUpdateModel.RisedBy,
                VendorId = vendorRequestUpdateModel.VendorId,
               
            };
         mERPDbContext.VendorRequest.Add(vendorRequest);
           await mERPDbContext.SaveChangesAsync();

            return $"Created -{vendorRequest.Id}";
        }

        public async Task<string> Update(VendorRequestUpdateModel vendorRequestUpdateModel)
        {
            VendorRequest vendorRequest = new VendorRequest
            {
                AdditionalInfo = vendorRequestUpdateModel.AdditionalInfo,
                AlternativeApprover = vendorRequestUpdateModel.AlternativeApprover,
                CommentBox = vendorRequestUpdateModel.CommentBox,
                PrimaryApprover = vendorRequestUpdateModel.PrimaryApprover,
                RisedBy = vendorRequestUpdateModel.RisedBy,
                VendorId = vendorRequestUpdateModel.VendorId,
            };
            mERPDbContext.VendorRequest.Update(vendorRequest);
            await mERPDbContext.SaveChangesAsync();

            return $"Update -{vendorRequest.Id}";
        }
    }
}
