using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic.IBussinessLogic
{
    public interface ILineItemsBl
    {
        Task<string> Created(LineItemsUpdateRequestModel lineItemsUpdateRequestModel);
        Task<string> Update(LineItemsUpdateRequestModel lineItemsUpdateRequestModel);
        Task<List<LineItemsResponceModel>> GellAllLineItem();
      
    }
}
