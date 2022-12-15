using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083325)]
    public class AddCatalogueTable_20221115083325 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("Catalogue").ForeignColumn("UserId").ToTable("Vendor").PrimaryColumn("Id");
            Delete.Table("Catalogue");
        }

        public override void Up()
        {
            Create.Table("Catalogue")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("Vendor", "Id")
                .WithColumn("MeterialId").AsInt32().NotNullable()
                .WithColumn("Meterial").AsString(50).NotNullable()
                .WithColumn("UOM").AsInt32().NotNullable()
                .WithColumn("Rate").AsInt32().NotNullable()
                .WithColumn("IsActive").AsBoolean()
                .WithColumn("GST").AsInt32().NotNullable()
                .WithColumn("Currency").AsString(20).NotNullable();
        }
    }
}
