﻿using System.Collections.Generic;
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
            LineItems lineItems = new LineItems
            {
               
                ItemsId = lineItemsUpdateRequestModel.ItemsId,
                Quantity = lineItemsUpdateRequestModel.Quantity,
                RequestVendorId = lineItemsUpdateRequestModel.RequestVendorId,
                Status = lineItemsUpdateRequestModel.Status,
                GST=lineItemsUpdateRequestModel.GST,
                
            };
            mERPDbContext.Add(lineItems);
            await mERPDbContext.SaveChangesAsync();
            return $"Updated - {lineItems.Id}";
        }

        public async Task<List<LineItemsResponceModel>> GellAllLineItems()
        {
            
            List <LineItemsResponceModel> catalogueItemResponceModel = await (from lineItems in mERPDbContext.LineItems
                                                                                 join catalogue in mERPDbContext.Catalogue
                                                                                 on lineItems.ItemsId equals catalogue.Id

                                                                             
                                                                              where lineItems.ItemsId == catalogue.Id
                                                                              select new LineItemsResponceModel
                                                                                 {
                                                                                     Sno = lineItems.Id,
                                                                                     Quantity=lineItems.Quantity,
                                                                                     ItemsId = mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x => x.Meterial).FirstOrDefault(),
                                                                                     Amount = mERPDbContext.Catalogue.Where(x=>x.Id==lineItems.ItemsId).Select(x=>x.Rate* lineItems.Quantity).FirstOrDefault(),
                                                                                     Rate= mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x => x.Rate).FirstOrDefault(),
                                                                                     RequestVendorId = lineItems.RequestVendorId,
                                                                                     Status = lineItems.Status,
                                                                                     GST=lineItems.GST,
                                                                                     UOM= mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x=>x.UOM.ToString()).FirstOrDefault(),
                                                                                     //UOM= mERPDbContext.Catalogue.Where(x => x.Id == lineItems.ItemsId).Select(x => x.UOM.ToString()).FirstOrDefault(),
                                                                                 }).OrderBy(x => x.Sno).ToListAsync();

                                                                                 return catalogueItemResponceModel;
                                                                                                                                                   
        }

        public async Task<string> Update(LineItemsUpdateRequestModel lineItemsUpdateRequestModel)
        {
            LineItems catalogueItems = new LineItems
            {
               
                 ItemsId = lineItemsUpdateRequestModel.ItemsId,
                Quantity = lineItemsUpdateRequestModel.Quantity,
                RequestVendorId = lineItemsUpdateRequestModel.RequestVendorId,
                Status = lineItemsUpdateRequestModel.Status,
                GST = lineItemsUpdateRequestModel.GST,
            };
            mERPDbContext.Update(catalogueItems);
          await  mERPDbContext.SaveChangesAsync();
            return $"Updated - {catalogueItems.Id}";
        }
    }
}