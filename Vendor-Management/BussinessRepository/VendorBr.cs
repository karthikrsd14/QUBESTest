using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Model.Enum;
using Vendor_Management.Request;
using Vendor_Management.Response;
using Vendor_Management.VendorManagementContext;
using Type = Vendor_Management.Model.Enum.Type;

namespace Vendor_Management.BussinessRepository
{
    public class VendorBr : IVendorBr
    {
        private readonly ERPDbContext mERPDbContext;
        public VendorBr(ERPDbContext iERPDbContext)
        {
            mERPDbContext = iERPDbContext;
        }
        public async Task<string> Create(VendorRequestModel vendorRequestModel)
        {
            using (IDbContextTransaction transaction = mERPDbContext.Database.BeginTransaction())
            {
                try
                {
                    Vendor vendor = new Vendor
                    {

                        CategoryId = vendorRequestModel.CategoryId,
                        Company = vendorRequestModel.Company,
                        CountryId = vendorRequestModel.CountryId,
                        StateId = vendorRequestModel.StateId,
                        City = vendorRequestModel.City,
                        PostalCode = vendorRequestModel.PostalCode,
                        WebSite = vendorRequestModel.WebSite,
                        RegisteredAddress = vendorRequestModel.RegisteredAddress,
                        EnrollmentDate = vendorRequestModel.EnrollmentDate,
                    };
                    mERPDbContext.Vendor.Add(vendor);
                    await mERPDbContext.SaveChangesAsync();

                    VendorRepDetails vendorRepDetails = new VendorRepDetails
                    {
                        Name = vendorRequestModel.Name,
                        Designation = vendorRequestModel.Designation,
                        Department = vendorRequestModel.Department,
                        PrimaryEmail = vendorRequestModel.PrimaryEmail,
                        PrimaryContactNumber = vendorRequestModel.PrimaryContactNumber,
                        AlternativeEmail = vendorRequestModel.AlternativeEmail,
                        AlternativeContactNumber = vendorRequestModel.AlternativeContactNumber,
                        ReportingHeadName = vendorRequestModel.ReportingHeadName,
                        ManagerEmail = vendorRequestModel.ManagerEmail,
                        ManagerContactNumber = vendorRequestModel.ManagerContactNumber,
                        VendorId = vendor.Id,
                    };
                    mERPDbContext.VendorRepDetails.Add(vendorRepDetails);
                    await mERPDbContext.SaveChangesAsync();


                    KYC kYC = new KYC
                    {
                        PanNumber = vendorRequestModel.PanNumber,
                        GSTRegistrationNumber = vendorRequestModel.GSTRegistrationNumber,
                        VAT = vendorRequestModel.VAT,
                        SSIRegistration = vendorRequestModel.SSIRegistration,
                        BankName = vendorRequestModel.BankName,
                        BranchName = vendorRequestModel.Branch,
                        AccountNumber = vendorRequestModel.AccountNumber,
                        Name = vendorRequestModel.UserName,
                        IFSCCode = vendorRequestModel.IFSCCode,
                        UPIId = vendorRequestModel.UPIId,
                        Reference = vendorRequestModel.Reference,
                        UserId = vendor.Id,
                        Type = vendorRequestModel.Type,
                    };
                    mERPDbContext.KYC.Add(kYC);
                    await mERPDbContext.SaveChangesAsync();
                    transaction.Commit();
                    return $"Created -{vendor.Id}";
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                  
                    return "Fail to Created";
                }
            }
        }
        public async Task<List<VendorResponseModel>> GetAll()
        {
            List<VendorResponseModel> vendorResponseModel = await (from vendor in mERPDbContext.Vendor
                                                                   join vedorRep in mERPDbContext.VendorRepDetails
                                                                    on vendor.Id equals vedorRep.VendorId

                                                                   join kyc in mERPDbContext.KYC
                                                                   on vendor.Id equals kyc.UserId

                                                                   where vendor.Id == kyc.UserId && kyc.Type == (int)Type.Vendor
                                                                   select new VendorResponseModel
                                                                   {
                                                                       VendorId = vendor.Id,
                                                                       Company = vendor.Company,
                                                                       EnrollmentDate = vendor.EnrollmentDate,
                                                                       City = vendor.City,
                                                                       Category = mERPDbContext.Category.Where(x => x.Id == vendor.CategoryId).Select(x => x.Name).FirstOrDefault(),
                                                                       Country = mERPDbContext.Country.Where(x => x.Id == vendor.CountryId).Select(x => x.Name).FirstOrDefault(),
                                                                       State = mERPDbContext.State.Where(x => x.Id == vendor.StateId).Select(x => x.Name).FirstOrDefault(),
                                                                       PostalCode = vendor.PostalCode,
                                                                       WebSite = vendor.WebSite == null ? string.Empty : vendor.WebSite,
                                                                       RegisteredAddress = vendor.RegisteredAddress,
                                                                       Name = vedorRep.Name,
                                                                       Designation = vedorRep.Designation,
                                                                       PrimaryEmail = vedorRep.PrimaryEmail,
                                                                       PrimaryContactNumber = vedorRep.PrimaryContactNumber,
                                                                       AlternativeEmail = vedorRep.AlternativeEmail,
                                                                       AlternativeContactNumber = vedorRep.AlternativeContactNumber,
                                                                       Department = vedorRep.Department,
                                                                       ReportingHeadName = vedorRep.ReportingHeadName,
                                                                       ManagerEmail = vedorRep.ManagerEmail,
                                                                       ManagerContactNumber = vedorRep.ManagerContactNumber,
                                                                       PanNumber = kyc.PanNumber,
                                                                       GSTRegistrationNumber = kyc.GSTRegistrationNumber,
                                                                       VAT = kyc.VAT,
                                                                       SSIRegistration = kyc.SSIRegistration,
                                                                       BankName = kyc.BankName,
                                                                       UserName = kyc.Name,
                                                                       AccountNumber = kyc.AccountNumber,
                                                                       IFSCCode = kyc.IFSCCode,
                                                                       Branch = kyc.BranchName,
                                                                       UPIId = kyc.UPIId,
                                                                       Reference = kyc.Reference,
                                                                       Type = ((Type)kyc.Type).ToString(),
                                                                   }).OrderBy(x => x.Company).ToListAsync();
            return vendorResponseModel;
        }

        public async Task<List<VendorResponseModel>> GetAllByCriteria(string? name)
        {
            List<VendorResponseModel> vendorResponseModel = await GetAll();
            if (name != null)
            {
                vendorResponseModel = vendorResponseModel.Select(x => x).Where(x => x.Company.Contains(name) || x.Category.Contains(name)).ToList();
            }
            return vendorResponseModel;
        }

        public async Task<BankDetailsResponseModel> GetBankDeteailsById(int userId)
        {
            BankDetailsResponseModel bankDetails = await (from kyc in mERPDbContext.KYC
                                                          where kyc.UserId == userId && kyc.Type == (int)Type.Vendor
                                                          select new BankDetailsResponseModel
                                                          {
                                                              AccountNumber = kyc.AccountNumber,
                                                              BankName = kyc.BankName,
                                                              BranchName = kyc.BranchName,
                                                              IFSCCode = kyc.IFSCCode,
                                                              Name = kyc.Name,
                                                              UPIId = kyc.UPIId,
                                                              Type = ((Type)kyc.Type).ToString(),
                                                          }).FirstOrDefaultAsync();
            return bankDetails;
        }

        public async Task<string> Update(VendorUpdateRequestModel vendorUpdateRequestModel)
        {
            using (IDbContextTransaction transaction = mERPDbContext.Database.BeginTransaction())
            {
                try
                {
                    var vendorid = mERPDbContext.Vendor.FirstOrDefault(x => x.Id == vendorUpdateRequestModel.VendorId);
                    if (vendorid != null)
                    {

                        Vendor vendor = mERPDbContext.Vendor.Where(x => x.Id == vendorUpdateRequestModel.VendorId).FirstOrDefault();
                        {

                            vendor.CategoryId = vendorUpdateRequestModel.CategoryId;
                            vendor.Company = vendorUpdateRequestModel.Company;
                            vendor.CountryId = vendorUpdateRequestModel.CountryId;
                            vendor.StateId = vendorUpdateRequestModel.StateId;
                            vendor.City = vendorUpdateRequestModel.City;
                            vendor.PostalCode = vendorUpdateRequestModel.PostalCode;
                            vendor.WebSite = vendorUpdateRequestModel.WebSite;
                            vendor.RegisteredAddress = vendorUpdateRequestModel.RegisteredAddress;
                            vendor.EnrollmentDate = vendorUpdateRequestModel.EnrollmentDate;
                        };
                        mERPDbContext.Vendor.Update(vendor);
                        await mERPDbContext.SaveChangesAsync();

                        VendorRepDetails vendorRepDetails = mERPDbContext.VendorRepDetails.Where(x => x.VendorId == vendorUpdateRequestModel.VendorId).FirstOrDefault();
                        {
                          
                            vendorRepDetails.Name = vendorUpdateRequestModel.Name;
                            vendorRepDetails.Designation = vendorUpdateRequestModel.Designation;
                            vendorRepDetails.Department = vendorUpdateRequestModel.Department;
                            vendorRepDetails.PrimaryEmail = vendorUpdateRequestModel.PrimaryEmail;
                            vendorRepDetails.PrimaryContactNumber = vendorUpdateRequestModel.PrimaryContactNumber;
                            vendorRepDetails.AlternativeEmail = vendorUpdateRequestModel.AlternativeEmail;
                            vendorRepDetails.AlternativeContactNumber = vendorUpdateRequestModel.AlternativeContactNumber;
                            vendorRepDetails.ReportingHeadName = vendorUpdateRequestModel.ReportingHeadName;
                            vendorRepDetails.ManagerEmail = vendorUpdateRequestModel.ManagerEmail;
                            vendorRepDetails.ManagerContactNumber = vendorUpdateRequestModel.ManagerContactNumber;
                        };
                        mERPDbContext.VendorRepDetails.Update(vendorRepDetails);
                        await mERPDbContext.SaveChangesAsync();

                        KYC kYC = mERPDbContext.KYC.Where(x => x.UserId == vendorUpdateRequestModel.VendorId).FirstOrDefault();
                        {
                            kYC.UserId = vendorUpdateRequestModel.VendorId;
                            kYC.PanNumber = vendorUpdateRequestModel.PanNumber;
                            kYC.GSTRegistrationNumber = vendorUpdateRequestModel.GSTRegistrationNumber;
                            kYC.VAT = vendorUpdateRequestModel.VAT;
                            kYC.SSIRegistration = vendorUpdateRequestModel.SSIRegistration;
                            kYC.BankName = vendorUpdateRequestModel.BankName;
                            kYC.BranchName = vendorUpdateRequestModel.Branch;
                            kYC.AccountNumber = vendorUpdateRequestModel.AccountNumber;
                            kYC.Name = vendorUpdateRequestModel.UserName;
                            kYC.IFSCCode = vendorUpdateRequestModel.IFSCCode;
                            kYC.UPIId = vendorUpdateRequestModel.UPIId;
                            kYC.Reference = vendorUpdateRequestModel.Reference;
                            kYC.Type = vendorUpdateRequestModel.Type;
                        };
                        mERPDbContext.KYC.Update(kYC);
                        await mERPDbContext.SaveChangesAsync();
                        transaction.Commit();
                        return $"Updated-{vendor.Id}";
                    }
                    else
                    {
                        return "Can't be Update the Vendor";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Fail to Update";
                }

            }

        }
    }
}

    //public void UploadInvoiceFiles(List<IFormFile> files, string LeadID, string CreatedBy, string Dealercode, long invoiceId)
    //{
    //    try
    //    {
    //        MemoryStream memorystream;
    //        //var target = _hostingEnvironment.ContentRootPath + "Invoice\\";
    //        // var target = _hostingEnvironment.WebRootPath + "Invoice\\";
    //        var target = Path.Combine("C:\test");
    //        Directory.CreateDirectory(target);
    //        files.ForEach(async file =>
    //        {
    //            var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
    //            var filePath = Path.Combine(target, filename);
    //            var invoicedetails = new Vendor()
    //            {

    //            };
    //            _context.Invoice.Add(invoicedetails);
    //            _context.SaveChanges();
    //            var stream = new FileStream(filePath, FileMode.Create);
    //            using (var stream1 = new MemoryStream())
    //            {
    //                file.CopyTo(stream);
    //                memorystream = new MemoryStream(stream1.ToArray());
    //            }
    //            byte[] bytes = memorystream.ToArray();
    //            target = Convert.ToBase64String(bytes);
    //            //target.ProfileID = ImageUpload.ProfileID;
    //            //image.Status = true;
    //            //upImages.Add(imageAdded);



    //        });
    //    }
    //    catch (Exception ex)
    //    {



    //    throw new CustomExpection(Convert.ToString(string.IsNullOrEmpty(ex.Message) ? ex.InnerException.Message : ex.Message), ex.StackTrace, assemblyName, ApplicationLogId.LMS_DocumentControllerId);
    //}}

