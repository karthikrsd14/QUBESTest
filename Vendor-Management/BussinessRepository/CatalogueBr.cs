using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Model;
using Vendor_Management.Request;
using Vendor_Management.Response;
using Vendor_Management.VendorManagementContext;
using Microsoft.EntityFrameworkCore;
using Vendor_Management.Model.Enum;

namespace Vendor_Management.BussinessRepository
{
    public class CatalogueBr : ICatalogueBr
    {
        private readonly ERPDbContext mERPDbContext;
        public CatalogueBr(ERPDbContext iERPDbContext)
        {
            mERPDbContext = iERPDbContext;
        }

        public async Task<string> Create(CatalogueRequestModel catalogueRequestModel)
        {
            Catalogue catalogue = new Catalogue
            {
                UserId = catalogueRequestModel.UserId,
                MeterialId = catalogueRequestModel.MeterialId,
                Meterial = catalogueRequestModel.Meterial,
                UOM = catalogueRequestModel.UOM,
                Rate = catalogueRequestModel.Rate,
                Currency = catalogueRequestModel.Currency,
                GST= catalogueRequestModel.GST,
            };
            mERPDbContext.Catalogue.Add(catalogue);
            await mERPDbContext.SaveChangesAsync();
            return $"Created - {catalogue.Id}";
        }
        public async Task<bool> DeleteCatalouge(int Id)
        {
            {
                Catalogue catalogues = await mERPDbContext.Catalogue.Where(x => x.Id == Id).Select(x => x).FirstOrDefaultAsync();
                {
                    catalogues.IsActive = false;
                }
                mERPDbContext.Catalogue.Remove(catalogues);
                await mERPDbContext.SaveChangesAsync();
                return true;
            }
        }
        public async Task<List<CatalogueResponseModel>> GetCatalougeByCriteria(int userId, string? criteria)
        {
            List<CatalogueResponseModel> catalogueListBycriteria = await GetCatalougeByUserId(userId);
            if (criteria != null)   
            {
                catalogueListBycriteria = catalogueListBycriteria.Select(x => x).Where(x => (x.MeterialId.ToString()).Contains(criteria) || x.Meterial.Contains(criteria)).ToList();
            }
            return catalogueListBycriteria;
        }

        public async Task<List<CatalogueResponseModel>> GetCatalougeByUserId(int userId)
        {
            
           
            List<CatalogueResponseModel> catalogueList = await (from catalogue in mERPDbContext.Catalogue
                                                                where catalogue.UserId == userId
                                                                select new CatalogueResponseModel
                                                                {
                                                                    Id = catalogue.Id,
                                                                    UserId = catalogue.UserId,
                                                                    MeterialId = catalogue.MeterialId,
                                                                    Meterial = catalogue.Meterial,
                                                                    UOM = ((UOM)catalogue.UOM).ToString(),
                                                                    Currency = catalogue.Currency,
                                                                    Rate = (catalogue.Rate),
                                                                    GST =(catalogue.GST).ToString(),
                                                                }).ToListAsync();
            return catalogueList;
        }

        public async Task<string> Update(CatalogueRequestModel catalogueRequestModel)
        {
            Catalogue catalogue = mERPDbContext.Catalogue.Where(x=>x.Id==catalogueRequestModel.Id).FirstOrDefault();    
            {
              catalogue.Id = catalogueRequestModel.Id;
                catalogue.UserId = catalogueRequestModel.UserId;
                catalogue.MeterialId = catalogueRequestModel.MeterialId;
                catalogue.Meterial = catalogueRequestModel.Meterial;
                catalogue.UOM = catalogueRequestModel.UOM;
                catalogue.Rate = catalogueRequestModel.Rate;
                catalogue.Currency = catalogueRequestModel.Currency;
                catalogue.GST = catalogueRequestModel.GST; 
            };
            mERPDbContext.Catalogue.Update(catalogue);
            await mERPDbContext.SaveChangesAsync();
            return $"Updated";
        }
    }
}
