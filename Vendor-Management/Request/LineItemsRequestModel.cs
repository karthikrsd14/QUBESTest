namespace Vendor_Management.Request
{
    public class LineItemsUpdateRequestModel
    {
        public int Id { get; set; }
        public int ItemsId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int GST { get; set; }
        public int PaymentTerms { get; set; }
        public int RequestId { get; set; }
        public string AdditionalInfo { get; set; }
        public string CommentBox { get; set; }
        public string RisedBy { get; set; }
        public int PrimaryApprover { get; set; }
        public int AlternativeApprover { get; set; }
        public int VendorId { get; set; }

    }
}
