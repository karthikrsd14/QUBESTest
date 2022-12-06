using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic
{
    public class VendorBl : IVendorBl
    {
        private readonly IVendorBr mVendorBr;
        public VendorBl(IVendorBr iVendorBr)
        {
            mVendorBr = iVendorBr;
        }
        public async Task<string> Create(VendorRequestModel vendorRequestModel)
        {
            return await mVendorBr.Create(vendorRequestModel);
        }

        public async Task<List<VendorResponseModel>> GetAll()
        {
            return await mVendorBr.GetAll();
        }

        public async Task<List<VendorResponseModel>> GetAllByCriteria(string? name)
        {
            return await mVendorBr.GetAllByCriteria(name);
        }

        public async Task<BankDetailsResponseModel> GetBankDeteailsById(int userId)
        {
            return await mVendorBr.GetBankDeteailsById(userId);
        }

        public async Task<string> Update(VendorUpdateRequestModel vendorUpdateRequestModel)
        {
            return await mVendorBr.Update(vendorUpdateRequestModel);
        }
    }
}
