using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.Request;
using Vendor_Management.Response;

namespace Vendor_Management.BussinessLogic.IBussinessLogic
{
    public interface ICustomerBl
    {
        Task<string>Create(CustomerRequestModel customerRequestModel);
        Task<string>Update(CustomerUpdateRequestModel customerUpdateRequestModel);
        Task<List<CustomerResponceModel>> GetAllCustomer();
        Task<List <CustomerResponceModel>> GetCustomerCriteria(string? customername);
        Task<BankDetailsResponseModel> GetBankDetailUsingId(int customerId);
    }
}
