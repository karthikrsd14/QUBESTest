using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.Response;
using Vendor_Management.VendorManagementContext;
using Vendor_Management.Model.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Vendor_Management.BussinessRepository
{
    public class CustomerBr : ICustomerBr
    {
        private readonly ERPDbContext mERPDbContext;

        public  CustomerBr(ERPDbContext iERPDbContext)
        {
            mERPDbContext = iERPDbContext;
        }

        public async Task<string> Created(CustomerRequestModel customerRequestModel)
        {
            using (IDbContextTransaction transaction = mERPDbContext.Database.BeginTransaction())
            {
                try
                {

                    Customer customerDetails = new Customer
                    {

                        Name = customerRequestModel.CustomerName,
                        AlternativeContactNumber = customerRequestModel.AlternativeContactNumber,
                        AlternativeEmail = customerRequestModel.AlternativeEmailID,
                        City = customerRequestModel.CustomerCity,
                        CustomerContactName = customerRequestModel.ContactName,
                        CountryId = customerRequestModel.CustomerCountryId,
                        CreditLimit = customerRequestModel.CreditLimit,
                        PostalCode = customerRequestModel.PostalCode,
                        PrimaryContactNumber = customerRequestModel.PrimaryContactNumber,
                        EnrollmentDate = customerRequestModel.EnrollMentDate,
                        PrimaryEmail = customerRequestModel.PrimaryEmailID,
                        RegisteredAddress = customerRequestModel.RegisteredAddress,
                        StateId = customerRequestModel.CustomerStateId,
                        WebSite = customerRequestModel.WebUrl,
                        IsBillingsameasShippingAddress = true,

                    };
                    mERPDbContext.Customer.Add(customerDetails);
                    await mERPDbContext.SaveChangesAsync();

                    Addresses billingaddress = new Addresses
                    {

                        Address = customerRequestModel.Billingaddress,
                        City = customerRequestModel.BillingCity,
                        Country = customerRequestModel.BilllingCountryId,
                        Name = customerRequestModel.BillingCustomerName,
                        CustomerId = customerDetails.Id,
                        PhoneNumber = customerRequestModel.BillingPhoneNumber,
                        PostalCode = customerRequestModel.BillingPostalCode,
                        State = customerRequestModel.BillingStateId,
                        IsBillingAddress = true,
                    };
                    mERPDbContext.Addresses.Add(billingaddress);
                    await mERPDbContext.SaveChangesAsync();


                    Addresses shippingAddress = new Addresses
                    {

                        Address = customerRequestModel.Shippingaddress,
                        City = customerRequestModel.ShippingCity,
                        Country = customerRequestModel.ShippingCountryId,
                        Name = customerRequestModel.ShippingCustomerName,
                        CustomerId = customerDetails.Id,
                        PhoneNumber = customerRequestModel.ShippingPhoneNumber,
                        PostalCode = customerRequestModel.ShippingPostalCode,
                        State = customerRequestModel.ShippingStateId,
                        IsBillingAddress = true,
                    };
                    mERPDbContext.Addresses.Add(shippingAddress);
                    await mERPDbContext.SaveChangesAsync();
                    KYC Kyc = new KYC
                    {
                        AccountNumber = customerRequestModel.AccountNumber,
                        BankName = customerRequestModel.BankName,
                        BranchName = customerRequestModel.BranchName,
                        GSTRegistrationNumber = customerRequestModel.GSTRegistrationNumber,
                        IFSCCode = customerRequestModel.IFSCCode,
                        Name = customerRequestModel.Name,
                        PanNumber = customerRequestModel.PanNumber,
                        SSIRegistration = customerRequestModel.SSIRegistration,
                        Reference = customerRequestModel.Reference,
                        UPIId = customerRequestModel.UPIId,
                        VAT = customerRequestModel.VAT,
                        Type = customerRequestModel.Type,
                        UserId = customerDetails.Id,
                    };
                    mERPDbContext.KYC.Add(Kyc);
                    await mERPDbContext.SaveChangesAsync();
                    transaction.Commit();
                    return $"Created -{customerDetails.Id}";
                }

                catch (System.Exception ex)
                {
                    
                    transaction.Rollback();
                    return "Fail to Update";
                }
            }
        }

        public async Task<List<CustomerResponceModel>> GetAllCustomer()
        {
            List<CustomerResponceModel> customerResponceModel = await (from customer in mERPDbContext.Customer
                                                                       join address in mERPDbContext.Addresses
                                                                       on customer.Id equals address.CustomerId

                                                                       join kyc in mERPDbContext.KYC
                                                                       on customer.Id equals kyc.UserId

                                                                       join state in mERPDbContext.State
                                                                       on customer.StateId equals state.Id
                                                                      

                                                                       join country in mERPDbContext.Country
                                                                       on customer.CountryId equals country.Id

                                                                       

                                                                      where customer.Id == kyc.UserId && kyc.Type == (int)Type.Customer
                                                                       select new CustomerResponceModel
                                                                       {
                                                                           CustomerId = customer.Id,
                                                                           CustomerStateId = mERPDbContext.State.Where(x => x.Id == customer.StateId).Select(x => x.Name).FirstOrDefault(),
                                                                           CustomerCountryId = mERPDbContext.Country.Where(n => n.Id == customer.CountryId).Select(n => n.Name).FirstOrDefault(),
                                                                           AccountNumber = kyc.AccountNumber,
                                                                           Billingaddress = address.Address,
                                                                           AlternativeContactNumber = customer.AlternativeContactNumber,
                                                                           AlternativeEmailID = customer.AlternativeEmail,
                                                                           BankName = kyc.BankName,
                                                                           BranchName = kyc.BranchName,
                                                                           BillingCity = address.City,
                                                                           ContactName = customer.CustomerContactName,
                                                                           CreditLimit = customer.CreditLimit,
                                                                           CustomerName = customer.Name,
                                                                           EnrollMentDate = customer.EnrollmentDate,
                                                                           GSTRegistrationNumber = kyc.GSTRegistrationNumber,
                                                                           IFSCCode = kyc.IFSCCode,
                                                                           PanNumber = kyc.PanNumber,
                                                                           BillingPhoneNumber = address.PhoneNumber,
                                                                           PostalCode = address.PostalCode,
                                                                           PrimaryContactNumber = customer.PrimaryContactNumber,
                                                                           PrimaryEmailID = customer.PrimaryEmail,
                                                                           Reference = kyc.Reference,
                                                                           RegisteredAddress = customer.RegisteredAddress,
                                                                           SSIRegistration = kyc.SSIRegistration,
                                                                           Name = kyc.Name,
                                                                           UPIId = kyc.UPIId,
                                                                           VAT = kyc.VAT,
                                                                           BillingCustomerName=address.Name,
                                                                           BillingCustomerId=customer.Id,
                                                                           BillingPostalCode=address.PostalCode,
                                                                           BillingStateId=mERPDbContext.State.Where(x => x.Id == address.State).Select(x => x.Name).FirstOrDefault(),
                                                                           BilllingCountryId =mERPDbContext.Country.Where(n => n.Id == address.Country).Select(n => n.Name).FirstOrDefault(),
                                                                           CustomerCity=address.City,   
                                                                           Shippingaddress=address.Address,
                                                                           ShippingCity=address.City,
                                                                           ShippingStateId = mERPDbContext.State.Where(x => x.Id == address.State).Select(x => x.Name).FirstOrDefault(),
                                                                           ShippingCountryId = mERPDbContext.Country.Where(n => n.Id == address.Country).Select(n => n.Name).FirstOrDefault(),
                                                                           ShippingCustomerId=customer.Id, 
                                                                           ShippingCustomerName=address.Name,
                                                                           ShippingPostalCode=address.PostalCode,   
                                                                           ShippingPhoneNumber=address.PhoneNumber,
                                                                           UserId=customer.Id, 
                                                                           WebUrl = customer.WebSite,
                                                                           Type = ((Type)kyc.Type).ToString(),
                                                                       }).OrderBy(x => x.CustomerName).ToListAsync();
            return customerResponceModel;
                     
             }

        public async Task<BankDetailsResponseModel> GetBankDetailUsingId(int customerId)
        {
           BankDetailsResponseModel responseModel = await( from kyc in mERPDbContext.KYC
                                                    where kyc.UserId==customerId && kyc.Type==(int)Type.Customer
                                                    select new BankDetailsResponseModel
                                                    {
                                                        AccountNumber = kyc.AccountNumber,
                                                        BankName=kyc.BankName,
                                                        BranchName=kyc.BranchName,
                                                        IFSCCode=kyc.IFSCCode,
                                                        Name=kyc.Name,
                                                        UPIId=kyc.UPIId,
                                                        Type = ((Type)kyc.Type).ToString(),

                                                    }).FirstAsync();
            return responseModel;


        }

        public async Task<List<CustomerResponceModel>> GetCustomerCriteria(string customername)
        {
            List<CustomerResponceModel> responseModel = await GetAllCustomer();
            if (customername!= null)
            {
                responseModel = responseModel.Select(x => x).Where(x => x.CustomerName.Contains(customername)).ToList();
                            }
            return responseModel;
        }

        public async Task<string> Update(CustomerUpdateRequestModel customerUpdateRequestModel)
        {
            using (IDbContextTransaction transaction = mERPDbContext.Database.BeginTransaction())
            {
                try
                {

                    Customer customerDetails = mERPDbContext.Customer.Where(x => x.Id == customerUpdateRequestModel.CustomerId).FirstOrDefault();
                    {
                        customerDetails.Name = customerUpdateRequestModel.CustomerName;
                        customerDetails.AlternativeContactNumber = customerUpdateRequestModel.AlternativeContactNumber;
                customerDetails.AlternativeEmail = customerUpdateRequestModel.AlternativeEmailID;
                customerDetails.City = customerUpdateRequestModel.CustomerCity;
                customerDetails.CustomerContactName = customerUpdateRequestModel.ContactName;
                customerDetails.CountryId = customerUpdateRequestModel.CustomerCountryId;
                customerDetails.CreditLimit = customerUpdateRequestModel.CreditLimit;
                customerDetails.PostalCode = customerUpdateRequestModel.PostalCode;
                customerDetails.PrimaryContactNumber = customerUpdateRequestModel.PrimaryContactNumber;
                customerDetails.EnrollmentDate = customerUpdateRequestModel.EnrollMentDate;
                customerDetails.PrimaryEmail = customerUpdateRequestModel.PrimaryEmailID;
                customerDetails.RegisteredAddress = customerUpdateRequestModel.RegisteredAddress;
                customerDetails.StateId = customerUpdateRequestModel.CustomerStateId;
                customerDetails.WebSite = customerUpdateRequestModel.WebUrl;
                

            };
                    mERPDbContext.Customer.Update(customerDetails);
                    await mERPDbContext.SaveChangesAsync();

                    Addresses billingaddress = mERPDbContext.Addresses.Where(x => x.CustomerId == customerUpdateRequestModel.CustomerId).FirstOrDefault();
                    {
                        billingaddress.Address = customerUpdateRequestModel.Billingaddress;
                        billingaddress.City = customerUpdateRequestModel.BillingCity;
                        billingaddress.Country = customerUpdateRequestModel.BilllingCountryId;
                        billingaddress.Name = customerUpdateRequestModel.BillingCustomerName;
                        billingaddress.CustomerId = customerUpdateRequestModel.CustomerId;
                        billingaddress.PhoneNumber = customerUpdateRequestModel.BillingPhoneNumber;
                        billingaddress.PostalCode = customerUpdateRequestModel.PostalCode;
                        billingaddress.State = customerUpdateRequestModel.BillingStateId;
                        billingaddress.IsBillingAddress = true;

                    };
                    mERPDbContext.Addresses.Update(billingaddress);
                     await mERPDbContext.SaveChangesAsync();


                    Addresses shippingAddress = mERPDbContext.Addresses.Where(x => x.CustomerId == customerUpdateRequestModel.CustomerId).FirstOrDefault();
                    {
                        shippingAddress.Address = customerUpdateRequestModel.Shippingaddress;
                        shippingAddress.City = customerUpdateRequestModel.ShippingCity;
                        shippingAddress.Country = customerUpdateRequestModel.ShippingCountryId;
                        shippingAddress.Name = customerUpdateRequestModel.ShippingCustomerName;
                        shippingAddress.CustomerId = customerUpdateRequestModel.CustomerId;
                        shippingAddress.PhoneNumber = customerUpdateRequestModel.ShippingPhoneNumber;
                        shippingAddress.PostalCode = customerUpdateRequestModel.PostalCode;
                        shippingAddress.State = customerUpdateRequestModel.ShippingStateId;
                        shippingAddress.IsBillingAddress = true;
                    };
                    mERPDbContext.Addresses.Update(shippingAddress);
                    await mERPDbContext.SaveChangesAsync();
                    KYC Kyc = new KYC
                    {
                        AccountNumber = customerUpdateRequestModel.AccountNumber,
                        BankName = customerUpdateRequestModel.BankName,
                        BranchName = customerUpdateRequestModel.BranchName,
                        GSTRegistrationNumber = customerUpdateRequestModel.GSTRegistrationNumber,
                        IFSCCode = customerUpdateRequestModel.IFSCCode,
                        Name = customerUpdateRequestModel.Name,
                        PanNumber = customerUpdateRequestModel.PanNumber,
                        SSIRegistration = customerUpdateRequestModel.SSIRegistration,
                        Reference = customerUpdateRequestModel.Reference,
                        UPIId = customerUpdateRequestModel.UPIId,
                        VAT = customerUpdateRequestModel.VAT,
                        Type = customerUpdateRequestModel.Type,

                    };
                    mERPDbContext.KYC.Update(Kyc);
                    await mERPDbContext.SaveChangesAsync();
                    transaction.Commit();
                    return $"Update -{customerDetails.Id}";
                }

                catch (System.Exception ex)
                {


                    transaction.Rollback();
                    return "Fail to Update";
                }


            } }
    }
}
