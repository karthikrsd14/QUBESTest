using System;
using Vendor_Management.Model;

namespace Vendor_Management.Request
{
    public class VendorRequestModel
    {
       
        public string Company { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string WebSite { get; set; }
        public string RegisteredAddress { get; set; }        
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
        public string PanNumber { get; set; }
        public string GSTRegistrationNumber { get; set; }
        public string VAT { get; set; }
        public string SSIRegistration { get; set; }
        public string BankName { get; set; }
        public string UserName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string Branch { get; set; }
        public string UPIId { get; set; }
        public string Reference { get; set; }
        public int Type { get; set; }        
    }
}
