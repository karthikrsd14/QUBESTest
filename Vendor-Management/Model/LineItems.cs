namespace Vendor_Management.Model
{
    public class LineItems
    {
        public int Id { get; set; }
        public int ItemsId { get; set; }
        public int UOM { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int GST { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public int RequestVendorId { get; set; }

    }
}
