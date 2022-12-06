using Microsoft.EntityFrameworkCore;
using Vendor_Management.Model;

namespace Vendor_Management.VendorManagementContext
{
    public class ERPDbContext : DbContext
    {
        public ERPDbContext(DbContextOptions<ERPDbContext> options)
        : base(options)
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorRepDetails> VendorRepDetails { get; set; }
        public DbSet<UploadedFilesDetail> UploadedFilesDetail { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<KYC> KYC { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Catalogue> Catalogue { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<CatalogueItems> CatalogueItems { get; set; }
        public DbSet<VendorRequest> VendorRequest { get; set; }
    }
}
