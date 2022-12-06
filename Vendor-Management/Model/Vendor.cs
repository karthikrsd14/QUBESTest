using System;

namespace Vendor_Management.Model
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string WebSite { get; set; }
        public  string RegisteredAddress { get; set; }
    }
}
