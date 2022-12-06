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

namespace Vendor_Management.BussinessRepository
{
    public class CatalogueItemBr : ICatalogueItemBr
    {
        private readonly ERPDbContext mERPDbContext;
        public CatalogueItemBr(ERPDbContext iERPDbContext)
        {
            mERPDbContext = iERPDbContext;  

        }

        public async Task<string> Created(CatalogueItemUpdateRequestModel catalogueItemupdateRequestModel)
        {
            CatalogueItems catalogueItems = new CatalogueItems
            {
                Amount = catalogueItemupdateRequestModel.Amount,
                GST = catalogueItemupdateRequestModel.GST,
                ItemsId = catalogueItemupdateRequestModel.ItemsId,
                Quantity = catalogueItemupdateRequestModel.Quantity,
                Rate = catalogueItemupdateRequestModel.Rate,
                RequestVendorId = catalogueItemupdateRequestModel.RequestVendorId,
                Status = catalogueItemupdateRequestModel.Status,
                UOM = catalogueItemupdateRequestModel.UOM,
            };
            mERPDbContext.Add(catalogueItems);
            await mERPDbContext.SaveChangesAsync();
            return $"Updated - {catalogueItems.Id}";
        }

        public async Task<List<CatalogueItemResponceModel>> GellAllCatalogueItem()
        {
            List<CatalogueItemResponceModel> catalogueItemResponceModel = await (from catalogueItems in mERPDbContext.CatalogueItems
                                                                                 join catalogue in mERPDbContext.Catalogue
                                                                                 on catalogueItems.ItemsId equals catalogue.Id


                                                                                 where catalogueItems.ItemsId == catalogue.Id
                                                                                 select new CatalogueItemResponceModel
                                                                                 {
                                                                                     Sno = catalogueItems.Id,
                                                                                     GST = catalogueItems.GST,
                                                                                     Amount = catalogueItems.Amount,
                                                                                     ItemsId = mERPDbContext.Catalogue.Where(x => x.Id == catalogueItems.ItemsId).Select(x => x.Meterial).FirstOrDefault(),
                                                                                     Quantity = catalogueItems.Quantity,
                                                                                     Rate = catalogueItems.Rate,
                                                                                     RequestVendorId = catalogueItems.RequestVendorId,
                                                                                     Status = catalogueItems.Status,
                                                                                     UOM = ((UOM)catalogueItems.UOM).ToString(),
                                                                                 }).OrderBy(x => x.Sno).ToListAsync();

                                                                                 return catalogueItemResponceModel;
                                                                                                                                                  
        }

        public async Task<string> Update(CatalogueItemUpdateRequestModel catalogueItemupdateRequestModel)
        {
            CatalogueItems catalogueItems = new CatalogueItems
            {
                Amount = catalogueItemupdateRequestModel.Amount,
                GST = catalogueItemupdateRequestModel.GST,
                ItemsId = catalogueItemupdateRequestModel.ItemsId,
                Quantity = catalogueItemupdateRequestModel.Quantity,
                Rate = catalogueItemupdateRequestModel.Rate,
                RequestVendorId = catalogueItemupdateRequestModel.RequestVendorId,
                Status = catalogueItemupdateRequestModel.Status,
                UOM = catalogueItemupdateRequestModel.UOM,
            };
            mERPDbContext.Update(catalogueItems);
          await  mERPDbContext.SaveChangesAsync();
            return $"Updated - {catalogueItems.Id}";
        }
    }
}
