using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.Request;

namespace Vendor_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorRequestController : ControllerBase
    {
        private readonly IVendorRequestBl mAddtionalInfoBl;
        public VendorRequestController(IVendorRequestBl iAddtionalInfoBl)
        {
            mAddtionalInfoBl = iAddtionalInfoBl;    
        }
        [HttpPost("create-addinfo")]
        public async Task<IActionResult> Create([FromBody] VendorRequestUpdateRequestModel vendorRequestUpdateModel)
        {
            var response=await mAddtionalInfoBl.Create(vendorRequestUpdateModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();    
        }
        [HttpPut("Update-AdditionalInfo")]
        public async Task<IActionResult> Update([FromBody] VendorRequestUpdateRequestModel vendorRequestUpdateModel)
        {
            var response = await mAddtionalInfoBl.Update(vendorRequestUpdateModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}

