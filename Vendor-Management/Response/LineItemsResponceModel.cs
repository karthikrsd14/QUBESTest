namespace Vendor_Management.Response
{
    public class LineItemsResponceModel
    {
        public int Sno { get; set; }
        public string ItemsId { get; set; }
        public string UOM { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int GST { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public string PaymentTerms { get; set; }
        public int RequestId { get; set; }
        public string AdditionalInfo { get; set; }
        public string CommentBox { get; set; }
        public string RisedBy { get; set; }
        public int PrimaryApprover { get; set; }
        public int AlternativeApprover { get; set; }

    }

}

