using Microsoft.VisualBasic;
using System;

namespace Vendor_Management.Request
{
    public class CustomerRequestModel
    {
        //--------Customer details-------//
        public string CustomerName { get; set; }
        public string PrimaryEmailID { get; set; }
        public DateTime EnrollMentDate { get; set; }
        public int PrimaryContactNumber { get; set; }
        public string AlternativeEmailID { get; set; }
        public int AlternativeContactNumber { get; set; }
        public int CreditLimit { get; set; }
        public int CustomerCountryId { get; set; }
        public int CustomerStateId { get; set; }
        public string CustomerCity { get; set; }
        public int PostalCode { get; set; }
        public string WebUrl { get; set; }
        public string RegisteredAddress { get; set; }
        public string ContactName { get; set; }
        //-----Billing Address-------//
    
    public string BillingCustomerName { get; set; }
        public string Billingaddress { get; set; }
        public int BillingStateId { get; set; }
        public int BilllingCountryId { get; set; }
        public string BillingCity { get; set; }
        public int BillingPostalCode { get; set; }
        public int BillingPhoneNumber { get; set; }
        public int BillingCustomerId { get; set; }
          //-----Shpping Address--------//
        public string ShippingCustomerName { get; set; }
        public string Shippingaddress { get; set; }
        public int ShippingStateId { get; set; }
        public int ShippingCountryId { get; set; }
        public string ShippingCity { get; set; }
        public int ShippingPostalCode { get; set; }
        public int ShippingPhoneNumber { get; set; }
        public int ShippingCustomerId { get; set; }
          //---Kyc details---//
        public string PanNumber { get; set; }
        public string GSTRegistrationNumber { get; set; }
        public string VAT { get; set; }
        public string SSIRegistration { get; set; }
        public string BankName { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public string UPIId { get; set; }
        public string Reference { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        
    }
}
