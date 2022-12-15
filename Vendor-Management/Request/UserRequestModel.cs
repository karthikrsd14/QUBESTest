using Microsoft.AspNetCore.Http;

namespace Vendor_Management.Request
{
    public class UserRequestModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ReEnterPassword { get; set; }
        public int UserType { get; set; }
    }
    public class UserUpdateModel
    {
       
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public string ReEnterPassword { get; set; }
        public int UserType { get; set; }
    }
    public class FileUpload
    {
        public int Id { get; set; }
        public IFormFile Files { get; set; }
        public string Name { get; set; }
    }
}
