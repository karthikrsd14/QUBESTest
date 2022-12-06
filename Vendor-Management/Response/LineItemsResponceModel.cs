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
        public int RequestVendorId { get; set; }
    }
}
