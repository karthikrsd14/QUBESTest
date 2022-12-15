



using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Model.Enum;
using Vendor_Management.Request;
using Vendor_Management.Response;
using Vendor_Management.VendorManagementContext;

namespace Vendor_Management.BussinessRepository
{
    public class UserBr : IUserBr
    {
        private readonly ERPDbContext mERPDbContext;
        private readonly IWebHostEnvironment mWebHostEnvironment;
       
        public UserBr(ERPDbContext iERPDbContext,IWebHostEnvironment iwebHostEnvironment)
        {
            mERPDbContext = iERPDbContext; 
            mWebHostEnvironment = iwebHostEnvironment;
            
        }

       
        public async Task<string> Create(UserRequestModel userRequestModel)
        {
            var empid = (from user in mERPDbContext.User
                        where user.EmpId == userRequestModel.EmpId || user.EmailId == userRequestModel.EmailId
                        select user).FirstOrDefault();

            

            if (userRequestModel.Password==userRequestModel.ReEnterPassword && empid==null)
                    
                
                   
                {
                    try
                    {



                        User user = new User
                        {

                            Name = userRequestModel.Name,
                            Designation = userRequestModel.Designation,
                            EmailId = userRequestModel.EmailId,
                            EmpId = userRequestModel.EmpId,
                            Password = userRequestModel.Password,
                            ReEnterPassword = userRequestModel.ReEnterPassword,
                            UserType = userRequestModel.UserType,

                        };

                        mERPDbContext.User.Add(user);
                        await mERPDbContext.SaveChangesAsync();
                        return $"Created -{user.Id}";
                    }
                    


                catch (Exception ex)
                    {

                       
                        return "Fail to Create";
                    }
                }
                else
                {
                    return "Can't be Create new User";
                }

            
         

        }

        public async Task<UserUpdateModel> UpdateById(UserUpdateModel userUpdateModel, int userId)
        {



            var userResponce = mERPDbContext.User.FirstOrDefault(x => x.EmpId == userId);
            if (userResponce != null && userUpdateModel.Password == userUpdateModel.ReEnterPassword)

            {
                userResponce.Designation = userUpdateModel.Designation;
                userResponce.Name = userUpdateModel.Name;
                userResponce.UserType = userUpdateModel.UserType;
                userResponce.Password = userUpdateModel.Password;
                userResponce.ReEnterPassword = userUpdateModel.ReEnterPassword;




                mERPDbContext.User.Update(userResponce);
                await mERPDbContext.SaveChangesAsync();
                return userUpdateModel;
            }
            else
            {
                return null;
            }
        }

       
       
       /* public Task<IActionResult> GetAllFile(string name)
        {
            string path = mWebHostEnvironment.WebRootPath + "\\Image\\";
            var FilePath = path + name + (".png");
           if (System.IO.File.Exists(FilePath))
           {

               byte[] file = System.IO.File.ReadAllBytes(FilePath);

               
               
            }
            return null;



        }*/

        public async  Task<List<UserResponceModel>> GetAllUser()
        {
            List<UserResponceModel> userResponceModels = await (from user in mERPDbContext.User
                                                                select new UserResponceModel
                                                                {
                                                                    Designation = user.Designation.Trim(),
                                                                    EmailId = user.EmailId.Trim(),
                                                                    EmpId = (user.EmpId).ToString().Trim(),
                                                                    Name = user.Name.Trim(),
                                                                    Password = user.Password.Trim(),
                                                                    ReEnterPassword = user.ReEnterPassword.Trim(),
                                                                    UserType = ((UserRoles)user.UserType).ToString().Trim(),


                                                                }
                                                                ).ToListAsync();
                                                                return userResponceModels;

        }

        
    }
}
