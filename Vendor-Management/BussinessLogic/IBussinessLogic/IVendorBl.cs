﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic.IBussinessLogic
{
    public interface IVendorBl
    {
        Task<string> Create(VendorRequestModel vendorRequestModel);
        Task<List<VendorResponseModel>> GetAll();
        Task<BankDetailsResponseModel> GetBankDeteailsById(int userId);
        Task<List<VendorResponseModel>> GetAllByCriteria(string? name);
        Task<string> Update(VendorUpdateRequestModel vendorUpdateRequestModel);
        public void UploadInvoiceFiles(List<IFormFile> files, string LeadID, string CreatedBy, string Dealercode, long invoiceId);

    }
}
