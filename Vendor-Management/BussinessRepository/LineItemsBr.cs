using System.Collections.Generic;
using System.Threading.Tasks;
using Vendor_Management.BussinessLogic;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.Response;
using Vendor_Management.VendorManagementContext;
using System.Linq;
using Vendor_Management.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Vendor_Management.BussinessRepository
{
    public class LineItemsBr : ILineItemsBr
    {
        private readonly ERPDbContext mERPDbContext;
        public LineItemsBr(ERPDbContext iERPDbContext)
        {
            mERPDbContext = iERPDbContext;

        }

        public async Task<string> Created(LineItemsUpdateRequestModel lineItemsUpdateRequestModel)
        {
           
            using (IDbContextTransaction transaction = mERPDbContext.Database.BeginTransaction())
            {
                try
                {
                    LineItems lineItems = new LineItems
                    {

                        ItemsId = lineItemsUpdateRequestModel.ItemsId,
                        Quantity = lineItemsUpdateRequestModel.Quantity,
                        PaymentTerms = lineItemsUpdateRequestModel.PaymentTerms,
                        Status = lineItemsUpdateRequestModel.Status,
                        GST = lineItemsUpdateRequestModel.GST,
                    };
                    mERPDbContext.LineItems.Add(lineItems);
                    await mERPDbContext.SaveChangesAsync();

                    VendorRequest vendorRequest = new VendorRequest
                    {

                        Id=lineItems.Id,
                        AdditionalInfo = lineItemsUpdateRequestModel.AdditionalInfo,
                        AlternativeApprover = lineItemsUpdateRequestModel.AlternativeApprover,
                        CommentBox = lineItemsUpdateRequestModel.CommentBox,
                        PrimaryApprover = lineItemsUpdateRequestModel.PrimaryApprover,
                        RisedBy = lineItemsUpdateRequestModel.RisedBy,
                        VendorId = lineItemsUpdateRequestModel.VendorId,
                    };
                    mERPDbContext.VendorRequest.Add(vendorRequest);
                    await mERPDbContext.SaveChangesAsync();
                    transaction.Commit();
                    return $"Created -{vendorRequest.Id}";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Fail to Create";
                }

            }
        }

        public async Task<List<LineItemsResponceModel>> GellAllLineItems()
        {
            

                    List<LineItemsResponceModel> lineItemsResponceModel = await (from lineItems in mERPDbContext.LineItems
                                                                             join catalogue in mERPDbContext.Catalogue
                                                                             on lineItems.ItemsId equals catalogue.Id
                                                                             
                                                                             join vendorrequest in mERPDbContext.VendorRequest
                                                                             on lineItems.Id equals vendorrequest.Id


                                                                             where lineItems.ItemsId == catalogue.Id && lineItems.Id == vendorrequest.Id   
                                                                             select new LineItemsResponceModel
                                                                             {
                                                                                 Sno = lineItems.Id,
                                                                                 Quantity = lineItems.Quantity,
                                                                                 ItemsId = mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x => x.Meterial).FirstOrDefault(),
                                                                                 Amount = mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x => x.Rate * lineItems.Quantity).FirstOrDefault(),
                                                                                 Rate = mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x => x.Rate).FirstOrDefault(),
                                                                                 PaymentTerms = ((PaymentTreams)lineItems.PaymentTerms).ToString(),
                                                                                 Status = lineItems.Status,
                                                                                 GST = lineItems.GST,
                                                                                 UOM = mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x => ((UOM)catalogue.UOM).ToString()).FirstOrDefault(),
                                                                                 RequestId=lineItems.RequestId,
                                                                                 AdditionalInfo=vendorrequest.AdditionalInfo,
                                                                                 AlternativeApprover=vendorrequest.AlternativeApprover,
                                                                                 CommentBox=vendorrequest.CommentBox,
                                                                                 PrimaryApprover=vendorrequest.PrimaryApprover,
                                                                                 RisedBy = vendorrequest.RisedBy    
                                                                                 
                                                                                 

                                                                             }).OrderBy(x => x.Sno).ToListAsync();

            return lineItemsResponceModel;

        }


        public async Task<string> Update(LineItemsUpdateRequestModel lineItemsUpdateRequestModel)
        {
            using (IDbContextTransaction transaction = mERPDbContext.Database.BeginTransaction())
            {
                try
                {

                    LineItems lineItems = mERPDbContext.LineItems.Where(x => x.Id == lineItemsUpdateRequestModel.Id).FirstOrDefault();
                    {


                        lineItems.ItemsId = lineItemsUpdateRequestModel.ItemsId;
                        lineItems.Quantity = lineItemsUpdateRequestModel.Quantity;
                        lineItems.PaymentTerms = lineItemsUpdateRequestModel.PaymentTerms;
                        lineItems.Status = lineItemsUpdateRequestModel.Status;
                        lineItems.GST = lineItemsUpdateRequestModel.GST;
                        lineItems.RequestId = lineItemsUpdateRequestModel.RequestId;
                    };
                    mERPDbContext.LineItems.Update(lineItems);
                    await mERPDbContext.SaveChangesAsync();

                    VendorRequest vendorRequest = mERPDbContext.VendorRequest.Where(x => x.Id == lineItems.Id).FirstOrDefault();
                    {

                        vendorRequest.AdditionalInfo = lineItemsUpdateRequestModel.AdditionalInfo;
                        vendorRequest.AlternativeApprover = lineItemsUpdateRequestModel.AlternativeApprover;
                        vendorRequest.CommentBox = lineItemsUpdateRequestModel.CommentBox;
                        vendorRequest.PrimaryApprover = lineItemsUpdateRequestModel.PrimaryApprover;
                        vendorRequest.RisedBy = lineItemsUpdateRequestModel.RisedBy;
                        vendorRequest.VendorId = lineItemsUpdateRequestModel.VendorId;
                    };
                    mERPDbContext.VendorRequest.Update(vendorRequest);
                    await mERPDbContext.SaveChangesAsync();
                    transaction.Commit();
                    return $"Update";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Fail to Create";
                }
            }
        }
    }
}
