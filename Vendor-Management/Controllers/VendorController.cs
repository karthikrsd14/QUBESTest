using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.Model;
using Vendor_Management.Request;

namespace Vendor_Management.Controllers
{
    [Route("api/v1/vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorBl mVendorBl;
        public VendorController(IVendorBl iVendorBl)
        {
            mVendorBl = iVendorBl;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VendorRequestModel vendorRequestModel)
        {
            var response = await mVendorBl.Create(vendorRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await mVendorBl.GetAll();
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getbankdetail")]
        public async Task<IActionResult> GetBankDeteailsById(int userId)
        {
            var response = await mVendorBl.GetBankDeteailsById(userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet("getallbycriteria")]
        public async Task<IActionResult> GetAllByCriteria(string name)
        {
            var response = await mVendorBl.GetAllByCriteria(name);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VendorUpdateRequestModel vendorUpdateRequestModel)
        {
            var response = await mVendorBl.Update(vendorUpdateRequestModel);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
        //[HttpPost(nameof(UploadInvoice))]
        //public IActionResult UploadInvoice([Required] List<IFormFile> formFiles, [Required] string LeadID, [Required] string CreatedBy, [Required] string Dealercode, long invoiceId)
        //{
        //        mVendorBl.UploadInvoiceFiles(formFiles, LeadID, CreatedBy, Dealercode, invoiceId);

        //        return Ok(new { formFiles.Count });
            
        //}
    }
}
