namespace Vendor_Management.Request
{
    public class LineItemsUpdateRequestModel
    {
       
        public int ItemsId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int RequestVendorId { get; set; }
        public int GST { get; set; }

    }
}
