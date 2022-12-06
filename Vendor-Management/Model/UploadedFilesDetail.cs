using System;

namespace Vendor_Management.Model
{
    public class UploadedFilesDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Type { get; set; }
    }
}
