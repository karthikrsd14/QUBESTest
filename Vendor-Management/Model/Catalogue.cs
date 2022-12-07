namespace Vendor_Management.Model
{
    public class Catalogue
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MeterialId { get; set; }
        public string Meterial { get; set; }
        public int UOM { get; set; }
        public int Rate { get; set; }
        public string Currency { get; set; }
        public int GST { get; set; }
        public int VendorId { get; set; }
    }
}
