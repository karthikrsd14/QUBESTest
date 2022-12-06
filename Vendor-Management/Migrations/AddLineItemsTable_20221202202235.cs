using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221202202235)]
    public class AddLineItemsTable_20221202202235 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("LineItems").ForeignColumn("ItemsId").ToTable("Catalogue").PrimaryColumn("Id");
                       
            Delete.Table("LineItems");
        }
        
        public override void Up()
        {
            Create.Table("LineItems")
               .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
               .WithColumn("ItemsId").AsInt32().NotNullable().ForeignKey("Catalogue", "Id")
               .WithColumn("UOM").AsInt32()
               .WithColumn("Quantity").AsInt32().NotNullable()
               .WithColumn("Rate").AsInt32()
               .WithColumn("GST").AsInt32()
               .WithColumn("Amount").AsInt32()
                .WithColumn("Status").AsString(20).NotNullable()
               .WithColumn("RequestVendorId").AsInt32().NotNullable();
        }
       
    }
    
}
