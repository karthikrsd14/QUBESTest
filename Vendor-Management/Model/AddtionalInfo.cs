using System.Security.Permissions;

namespace Vendor_Management.Model
{
    public class AddtionalInfo
    {
        public int Id { get; set; }
        public string AdditionalInfo { get; set; }
        public string CommentBox { get; set; }
        public string RisedBy { get; set; }
        public int PrimaryApprover { get; set; }
        public int AlternativeApprover { get; set; }
        public int VendorId { get; set; }
        //public HttpPostedFileBas  MyProperty { get; set; }
    }
}
