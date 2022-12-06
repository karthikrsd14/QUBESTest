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
        private readonly IAddtionalInfoBl mVendorRequestBl;
        public VendorRequestController(IAddtionalInfoBl iVendorRequestBl)
        {
            mVendorRequestBl = iVendorRequestBl;    
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddtionalInfoUpdateModel vendorRequestUpdateModel)
        {
            var response=await mVendorRequestBl.Create(vendorRequestUpdateModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();    
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AddtionalInfoUpdateModel vendorRequestUpdateModel)
        {
            var response = await mVendorRequestBl.Update(vendorRequestUpdateModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}

