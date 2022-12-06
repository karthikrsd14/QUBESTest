using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic
{
    public class CustomerBl : ICustomerBl
    {
        private readonly ICustomerBr mCustomerBr;
        public CustomerBl(ICustomerBr iCustomerBr)
        {
            mCustomerBr = iCustomerBr;
        }
        public async Task<string> Create(CustomerRequestModel customerRequestModel)
        {
           return await mCustomerBr.Created(customerRequestModel);
        }

        public async Task<List<CustomerResponceModel>> GetAllCustomer()
        {
            return await mCustomerBr.GetAllCustomer();
        }

        public async Task<BankDetailsResponseModel> GetBankDetailUsingId(int customerId)
        {
            return await mCustomerBr.GetBankDetailUsingId(customerId);    
        }

        public async Task<List<CustomerResponceModel>> GetCustomerCriteria(string customername)
        {
            return await mCustomerBr.GetCustomerCriteria(customername);
        }

        public async Task<string> Update(CustomerUpdateRequestModel customerUpdateRequestModel)
        {
           return await mCustomerBr.Update(customerUpdateRequestModel);
        }
    }
}
