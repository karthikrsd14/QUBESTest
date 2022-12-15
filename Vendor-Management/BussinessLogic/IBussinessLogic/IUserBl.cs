using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace ERB.BusinessLogics.IBusinessLogic
{
    public interface IUserBl
    {
        Task<string> Create(UserRequestModel userRequestModel);
        Task<List<UserResponceModel>> GetAllUser();
        Task<UserUpdateModel> UpdateById(UserUpdateModel userUpdateModel,int userId);
        //Task<string> UploadFile(FileUpload fileUpload);
        //public Task<IActionResult> GetAllFile(string name);
    }
}
