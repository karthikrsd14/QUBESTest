namespace Vendor_Management.Request
{
    public class CatalogueItemUpdateRequestModel
    {
       
        public int ItemsId { get; set; }
        public int UOM { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public string GST { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public int RequestVendorId { get; set; }

    }
}
