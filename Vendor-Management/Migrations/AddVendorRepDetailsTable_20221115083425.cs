using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083425)]
    public class AddVendorRepDetailsTable_20221115083425 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("VendorRepDetails").ForeignColumn("VendorId").ToTable("Vendor").PrimaryColumn("Id");
            Delete.Table("VendorRepDetails");
        }
        public override void Up()
        {
            Create.Table("VendorRepDetails")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Designation").AsString(50).NotNullable()
                .WithColumn("PrimaryEmail").AsString(20).NotNullable()
                .WithColumn("PrimaryContactNumber").AsString(20).NotNullable()
                .WithColumn("AlternativeEmail").AsString(20).Nullable()
                .WithColumn("AlternativeContactNumber").AsString(20).Nullable()
                .WithColumn("ReportingHeadName").AsString(50).NotNullable()
                .WithColumn("Department").AsString(50).NotNullable()
                .WithColumn("ManagerEmail").AsString(20).NotNullable()
                .WithColumn("ManagerContactNumber").AsString(20).NotNullable()
                .WithColumn("VendorId").AsInt32().NotNullable().ForeignKey("Vendor", "Id");
        }
    }
}
