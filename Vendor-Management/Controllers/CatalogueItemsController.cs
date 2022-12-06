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
    public class CatalogueItemsController : ControllerBase
    {
        private readonly ICatalogueItemBl mCatalogueItemBl;
        public CatalogueItemsController(ICatalogueItemBl iCatalogueItemBl)
        {
            mCatalogueItemBl = iCatalogueItemBl;
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CatalogueItemUpdateRequestModel catalogueItemUpdateRequestModel)
        {
            var response = await mCatalogueItemBl.Update(catalogueItemUpdateRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Created([FromBody] CatalogueItemUpdateRequestModel catalogueItemUpdateRequestModel)
        {
            var response = await mCatalogueItemBl.Created(catalogueItemUpdateRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
        [HttpGet("getallCatalogueItem")]
        public async Task<IActionResult> GetAllCatalogueItem()
        {
            var response = await mCatalogueItemBl.GellAllCatalogueItem();
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}
