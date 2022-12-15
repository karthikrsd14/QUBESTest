using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vendor_Management.Model
{
    public class User
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string  Name { get; set; }
        public string Designation { get; set; }
        public string EmailId  { get; set; }
        public string Password { get; set; }
        public string ReEnterPassword { get; set; }
        public int UserType { get; set; }
       
    }
    
   
    
}
