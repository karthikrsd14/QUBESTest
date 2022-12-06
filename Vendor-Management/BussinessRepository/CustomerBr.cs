﻿using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.Response;
using Vendor_Management.VendorManagementContext;
using Vendor_Management.Model.Enum;
using Microsoft.EntityFrameworkCore;

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
                    CustomerId = customerRequestModel.BillingCustomerId,
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
                    CustomerId = customerRequestModel.ShippingCustomerId,
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
                    UserId = customerRequestModel.UserId,   
                };
                mERPDbContext.KYC.Add(Kyc);
                await mERPDbContext.SaveChangesAsync();

                return $"Created -{customerDetails.Id}";
            }
            catch (System.Exception ex)
            {

                throw;
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
                                                                           CustomerCountryId = mERPDbContext.Country.Where(n => n.Id == customer.CountryId).Select(x => x.Name).FirstOrDefault(),
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
                                                                           BilllingCountryId =mERPDbContext.Country.Where(n => n.Id == address.Country).Select(x => x.Name).FirstOrDefault(),
                                                                           CustomerCity=address.City,   
                                                                           Shippingaddress=address.Address,
                                                                           ShippingCity=address.City,
                                                                           ShippingStateId = mERPDbContext.State.Where(x => x.Id == address.State).Select(x => x.Name).FirstOrDefault(),
                                                                           ShippingCountryId = mERPDbContext.Country.Where(n => n.Id == address.Country).Select(x => x.Name).FirstOrDefault(),
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
            Customer customerDetails = new Customer
            {
                Name = customerUpdateRequestModel.CustomerName,
                AlternativeContactNumber = customerUpdateRequestModel.AlternativeContactNumber,
                AlternativeEmail = customerUpdateRequestModel.AlternativeEmailID,
                City = customerUpdateRequestModel.CustomerCity,
                CustomerContactName = customerUpdateRequestModel.ContactName,
                CountryId = customerUpdateRequestModel.CustomerCountryId,
                CreditLimit = customerUpdateRequestModel.CreditLimit,
                PostalCode = customerUpdateRequestModel.PostalCode,
                PrimaryContactNumber = customerUpdateRequestModel.PrimaryContactNumber,
                EnrollmentDate = customerUpdateRequestModel.EnrollMentDate,
                PrimaryEmail = customerUpdateRequestModel.PrimaryEmailID,
                RegisteredAddress = customerUpdateRequestModel.RegisteredAddress,
                StateId = customerUpdateRequestModel.CustomerStateId,
                WebSite = customerUpdateRequestModel.WebUrl,
                IsBillingsameasShippingAddress=true,

            };
            mERPDbContext.Customer.Update(customerDetails);
            await mERPDbContext.SaveChangesAsync();

            Addresses billingaddress = new Addresses
            {
                Address = customerUpdateRequestModel.Billingaddress,
                City = customerUpdateRequestModel.BillingCity,
                Country = customerUpdateRequestModel.BilllingCountryId,
                Name = customerUpdateRequestModel.BillingCustomerName,
                CustomerId = customerUpdateRequestModel.CustomerId,
                PhoneNumber = customerUpdateRequestModel.BillingPhoneNumber,
                PostalCode = customerUpdateRequestModel.PostalCode,
                State = customerUpdateRequestModel.BillingStateId,
                IsBillingAddress = true,
               
            };
            mERPDbContext.Addresses.Add(billingaddress);
           // await mERPDbContext.SaveChangesAsync();


            Addresses shippingAddress = new Addresses
            {
                Address = customerUpdateRequestModel.Shippingaddress,
                City = customerUpdateRequestModel.ShippingCity,
                Country = customerUpdateRequestModel.ShippingCountryId,
                Name = customerUpdateRequestModel.ShippingCustomerName,
                CustomerId = customerUpdateRequestModel.CustomerId,
                PhoneNumber = customerUpdateRequestModel.ShippingPhoneNumber,
                PostalCode = customerUpdateRequestModel.PostalCode,
                State = customerUpdateRequestModel.ShippingStateId,
                IsBillingAddress= true,
            };
            mERPDbContext.Addresses.Add(shippingAddress);
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
            mERPDbContext.KYC.Add(Kyc);
            await mERPDbContext.SaveChangesAsync();

            return $"Created -{customerDetails.Id}";

        }
    }
}
