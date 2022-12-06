using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic
{
    public class LineItemsBl : ILineItemsBl
    {
        private readonly ILineItemsBr mLineItemsBr;
        public LineItemsBl(ILineItemsBr iLineItemsBr)
        {
            mLineItemsBr = iLineItemsBr;
        }

        public async  Task<string> Created(LineItemsUpdateRequestModel lineItemsUpdateRequestModel)
        {
            return await mLineItemsBr.Created(lineItemsUpdateRequestModel);
        }

        public async Task<List<LineItemsResponceModel>> GellAllLineItem()
        {
            return await mLineItemsBr.GellAllLineItems();
        }

        public  async Task<string> Update(LineItemsUpdateRequestModel lineItemsUpdateRequestModel)
        {
           return await mLineItemsBr.Update(lineItemsUpdateRequestModel);   
        }
    }
}
