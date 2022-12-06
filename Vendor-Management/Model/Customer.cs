using Microsoft.VisualBasic;
using System;

namespace Vendor_Management.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrimaryEmail { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int PrimaryContactNumber { get; set; }
        public string AlternativeEmail{ get; set; }
        public int AlternativeContactNumber { get; set; }
        public int CreditLimit { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string WebSite { get; set; }
        public string RegisteredAddress { get; set; }
        public string CustomerContactName { get; set; }
        public bool IsBillingsameasShippingAddress { get; set; }



    }
}
