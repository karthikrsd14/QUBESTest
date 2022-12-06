using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.Request;

namespace Vendor_Management.Controllers
{
    [Route("api/v1/catalogue")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly ICatalogueBl mCatalogueBl;
        public CatalogueController(ICatalogueBl iCatalogueBl)
        {
            mCatalogueBl = iCatalogueBl;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CatalogueRequestModel catalogueRequestModel)
        {
            var response = await mCatalogueBl.Create(catalogueRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CatalogueRequestModel catalogueRequestModel)
        {
            var response = await mCatalogueBl.Update(catalogueRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetCatalougeByUserId(int userId)
        {
            var response = await mCatalogueBl.GetCatalougeByUserId(userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getbycriteria")]
        public async Task<IActionResult> GetCatalougeByCriteria(int userId, string? criteria)
        {
            var response = await mCatalogueBl.GetCatalougeByCriteria(userId,criteria);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}
