namespace Vendor_Management.Request
{
    public class LineItemsUpdateRequestModel
    {
       
        public int ItemsId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int GST { get; set; }
        public int PaymentTerms { get; set; }

        public int RequestId { get; set; }

    }
}
