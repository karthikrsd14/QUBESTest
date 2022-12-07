namespace Vendor_Management.Request
{
    public class VendorRequestUpdateRequestModel
    {
        public string AdditionalInfo { get; set; }
        public string CommentBox { get; set; }
        public string RisedBy { get; set; }
        public int PrimaryApprover { get; set; }
        public int AlternativeApprover { get; set; }
        public int VendorId { get; set; }
    }
}
