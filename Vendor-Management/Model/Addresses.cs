namespace Vendor_Management.Model
{
    public class Addresses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public int CustomerId { get; set; }
        public bool IsBillingAddress { get; set; }
        
    }
}
