using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.Request;

namespace Vendor_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBl mCustomerBl;
        public CustomerController(ICustomerBl iCustomerBl)
        {
            mCustomerBl = iCustomerBl;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequestModel customerRequestModel)
        {
            var response = await mCustomerBl.Create(customerRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await mCustomerBl.GetAllCustomer();
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getbankdetail")]
        public async Task<IActionResult> GetBankDeteailsById(int userId)
        {
            var response = await mCustomerBl.GetBankDetailUsingId(userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getallbycriteria")]
        public async Task<IActionResult> GetAllByCriteria(string name)
        {
            var response = await mCustomerBl.GetCustomerCriteria(name);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerUpdateRequestModel CustomerUpdateRequestModel)
        {
            var response = await mCustomerBl.Update(CustomerUpdateRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}
