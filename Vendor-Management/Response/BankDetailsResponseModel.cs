using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor_Management.Response
{
    public class BankDetailsResponseModel
    {
        public string BankName { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string BranchName { get; set; }
        public string UPIId { get; set; }
        public string  Type { get; set; }
        
    }
}
