namespace Vendor_Management.Model
{
    public class VendorRepDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string AlternativeEmail { get; set; }
        public string AlternativeContactNumber { get; set; }
        public string ReportingHeadName { get; set; }
        public string ManagerEmail { get; set; }
        public string Department { get; set; }
        public string ManagerContactNumber { get; set; }
        public int VendorId { get; set; }
    }
}
