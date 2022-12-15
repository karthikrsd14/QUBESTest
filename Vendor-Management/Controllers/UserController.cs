using ERB.BusinessLogics.IBusinessLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.VendorManagementContext;
using Vendor_Management.BussinessRepository;
using System.Collections.Generic;
using System.Linq;
using Vendor_Management.BussinessLogic;

namespace ERB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBl mUserBl;
        private readonly IWebHostEnvironment mWebHostEnvironment;
        private readonly ERPDbContext mERPDbContext;
        public UserController(IUserBl iUserBl, IWebHostEnvironment iWebHostEnvironment, ERPDbContext iERPDbContext)
        {
            mUserBl = iUserBl;
            mWebHostEnvironment = iWebHostEnvironment;  
            mERPDbContext = iERPDbContext;  
        }
        [HttpPut("Update-User/{userId}")]
        public async Task<IActionResult> Update([FromBody] UserUpdateModel userUpdateModel, int userId)
        {
            var response = await mUserBl.UpdateById(userUpdateModel, userId);
            if (response != null)
            {
                return Ok(response);
            }
            return NoContent();
        }
        [HttpPost("Add-NewUser")]
        public async Task<IActionResult> Created([FromBody] UserRequestModel userRequestModel)
        {
            var response = await mUserBl.Create(userRequestModel);

          
            if (response != null)
            {

        
                return Created("Created",response);
            }
            return NoContent();
        }

        [HttpPost("PhotoUpload")]
        public async Task<string> PhotoUpload([FromForm]FileUpload fileUpload)
        {


            var fileEmpId = mERPDbContext.User.FirstOrDefault(x => x.EmpId == fileUpload.Id && x.Name.Equals(fileUpload.Name));



            if (fileUpload.Files.Length > 0 && (fileUpload.Files.FileName.ToString().EndsWith("png") || fileUpload.Files.FileName.ToString().EndsWith("jpg") || fileUpload.Files.FileName.ToString().EndsWith("jpeg"))
                        && (fileEmpId != null))
            {

                try
                {
                    if (!Directory.Exists(mWebHostEnvironment.WebRootPath + "\\Image\\"))
                    {
                        Directory.CreateDirectory(mWebHostEnvironment.WebRootPath + "\\Image\\");
                    }

                    await using (FileStream fileStream = System.IO.File.Create(mWebHostEnvironment.WebRootPath + "\\Image\\" + fileUpload.Name + ".png"))
                    {
                        fileUpload.Files.CopyTo(fileStream);
                        fileStream.Flush();
                        string Filelocation = "\\Image\\" + fileUpload.Files.FileName;

                        return Filelocation;
                    }



                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }

            else
            {
                return "File Upload Filed Formte is Wrong Or File Don't Have";




            }
            

        }


        [HttpGet("getUsers")]
        public async Task<IActionResult> GetAlluser()
        {
               var response = await mUserBl.GetAllUser();
            if (response != null )
            {
                return Ok(response);
            }
            
            return NoContent();
        }
        [HttpGet("getUser-Photo")]
        public async Task<IActionResult> GetuserPhoto(string filename)
        {
            string path = mWebHostEnvironment.WebRootPath + "\\Image\\";
            var filePath = path + filename + ".png";

            var response = await mUserBl.GetAllUser();
            if (response != null && System.IO.File.Exists(filePath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, "image/png");
               
            }


            return NoContent();
        }


    }
}
