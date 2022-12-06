using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.Request;
using Vendor_Management.VendorManagementContext;

namespace Vendor_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemsController : ControllerBase
    {
        private readonly ILineItemsBl mLineItemsBl;
        public LineItemsController(ILineItemsBl iLineItemsBl)
        {
            mLineItemsBl = iLineItemsBl;
        }
        [HttpPut("Update-lineItems")]
        public async Task<IActionResult> Update([FromBody] LineItemsUpdateRequestModel lineItemsUpdateRequestModel)
        {
            var response = await mLineItemsBl.Update(lineItemsUpdateRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
        [HttpPost("Add-lineItems")]
        public async Task<IActionResult> Created([FromBody] LineItemsUpdateRequestModel lineItemsUpdateRequestModel)
        {
            var response = await mLineItemsBl.Created(lineItemsUpdateRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
        [HttpGet("getallLineItems")]
        public async Task<IActionResult> GetAllLineItem()
        {
            var response = await mLineItemsBl.GellAllLineItem();
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}
