namespace Vendor_Management.Response
{
    public class CatalogueResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MeterialId { get; set; }
        public string Meterial { get; set; }
        public string UOM { get; set; }
        public int Rate { get; set; }
        public string Currency { get; set; }
    }
}
