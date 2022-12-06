using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

            return $"Created -{vendor.Id}";
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
                                                                       VendorRepId = vedorRep.Id,
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
                                                                       KYCId = kyc.Id,
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
                                                          }).FirstOrDefaultAsync();
            return bankDetails;
        }

        public async Task<string> Update(VendorUpdateRequestModel vendorUpdateRequestModel)
        {
            Vendor vendor = new Vendor
            {
                Id = vendorUpdateRequestModel.VendorId,
                CategoryId = vendorUpdateRequestModel.CategoryId,
                Company = vendorUpdateRequestModel.Company,
                CountryId = vendorUpdateRequestModel.CountryId,
                StateId = vendorUpdateRequestModel.StateId,
                City = vendorUpdateRequestModel.City,
                PostalCode = vendorUpdateRequestModel.PostalCode,
                WebSite = vendorUpdateRequestModel.WebSite,
                RegisteredAddress = vendorUpdateRequestModel.RegisteredAddress,
                EnrollmentDate = vendorUpdateRequestModel.EnrollmentDate,
            };
            mERPDbContext.Vendor.Update(vendor);
            await mERPDbContext.SaveChangesAsync();

            VendorRepDetails vendorRepDetails = new VendorRepDetails
            {
                VendorId = vendorUpdateRequestModel.VendorId,
                Name = vendorUpdateRequestModel.Name,
                Designation = vendorUpdateRequestModel.Designation,
                Department = vendorUpdateRequestModel.Department,
                PrimaryEmail = vendorUpdateRequestModel.PrimaryEmail,
                PrimaryContactNumber = vendorUpdateRequestModel.PrimaryContactNumber,
                AlternativeEmail = vendorUpdateRequestModel.AlternativeEmail,
                AlternativeContactNumber = vendorUpdateRequestModel.AlternativeContactNumber,
                ReportingHeadName = vendorUpdateRequestModel.ReportingHeadName,
                ManagerEmail = vendorUpdateRequestModel.ManagerEmail,
                ManagerContactNumber = vendorUpdateRequestModel.ManagerContactNumber,
            };
            mERPDbContext.VendorRepDetails.Update(vendorRepDetails);
            await mERPDbContext.SaveChangesAsync();

            KYC kYC = new KYC
            {
                UserId = vendorUpdateRequestModel.VendorId,
                PanNumber = vendorUpdateRequestModel.PanNumber,
                GSTRegistrationNumber = vendorUpdateRequestModel.GSTRegistrationNumber,
                VAT = vendorUpdateRequestModel.VAT,
                SSIRegistration = vendorUpdateRequestModel.SSIRegistration,
                BankName = vendorUpdateRequestModel.BankName,
                BranchName = vendorUpdateRequestModel.Branch,
                AccountNumber = vendorUpdateRequestModel.AccountNumber,
                Name = vendorUpdateRequestModel.UserName,
                IFSCCode = vendorUpdateRequestModel.IFSCCode,
                UPIId = vendorUpdateRequestModel.UPIId,
                Reference = vendorUpdateRequestModel.Reference,
                Type = vendorUpdateRequestModel.Type,
            };
            mERPDbContext.KYC.Update(kYC);
            await mERPDbContext.SaveChangesAsync();

            return $"Updated -{vendor.Id}";
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
}
