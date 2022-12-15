namespace Vendor_Management.Request
{
    public class CatalogueRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MeterialId { get; set; }
        public string Meterial { get; set; }
        public int UOM { get; set; }
        public int Rate { get; set; }
        public string Currency { get; set; }
        public int GST { get; set; }
    }
}
