using ERB.BusinessLogics.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading.Tasks;

using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic
{
    public class UserBl : IUserBl
    {
        private readonly IUserBr mUserBr;
        public UserBl(IUserBr iUserBr)
        {
            mUserBr = iUserBr;
        }
        public async  Task<string> Create(UserRequestModel userRequestModel)
        {
            return await mUserBr.Create(userRequestModel);
        }

        //public async Task<IActionResult> GetAllFile(string name)
        //{
        //    return await mUserBr.GetAllFile(name);
        //}

        public async Task<List<UserResponceModel>> GetAllUser()
        {
            return await mUserBr.GetAllUser();    
        }

        public async Task<UserUpdateModel> UpdateById(UserUpdateModel userUpdateModel,int userId)
        {
            return await mUserBr.UpdateById(userUpdateModel,userId);   
        }

      
    }
}
