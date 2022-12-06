using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Vendor_Management.Model.Enum
{
    public enum PaymentTreams
    {
        COD=1,
        [Display(Name = "Credit / Debit Card")]
        CreditDebitcard =2,
        UPI=3,
    }
}
