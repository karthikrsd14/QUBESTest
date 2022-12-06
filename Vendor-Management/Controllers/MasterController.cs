using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;

namespace Vendor_Management.Controllers
{
    [Route("api/v1/master")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterBl masterBl;
        public MasterController(IMasterBl iMasterBl)
        {
            masterBl = iMasterBl;
        }

        [HttpGet("country/getall")]
        public async Task<IActionResult> GetAllCountry()
        {
            var response = await masterBl.GetAllCountry();
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("state/getbyId")]
        public async Task<IActionResult> GetStatesById(int countryId)
        {
            var response = await masterBl.GetStatesById(countryId);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("category/getall")]
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await masterBl.GetAllCategory();
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}
