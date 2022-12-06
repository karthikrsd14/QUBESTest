using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221202202235)]
    public class AddCatalogueItemsTable_20221202202235 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("CatalogueItems").ForeignColumn("ItemsId").ToTable("Catalogue").PrimaryColumn("Id");
                       
            Delete.Table("CatalogueItems");
        }
        
        public override void Up()
        {
            Create.Table("CatalogueItems")
               .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
               .WithColumn("ItemsId").AsInt32().NotNullable().ForeignKey("Catalogue", "Id")
               .WithColumn("UOM").AsInt32().NotNullable()
               .WithColumn("Quantity").AsInt32().NotNullable()
               .WithColumn("Rate").AsInt32().NotNullable()
               .WithColumn("GST").AsString(20).NotNullable()
               .WithColumn("Amount").AsInt32().NotNullable()
                .WithColumn("Status").AsString(20).NotNullable()
               .WithColumn("RequestVendorId").AsInt32().NotNullable();
        }
    }
    
}
