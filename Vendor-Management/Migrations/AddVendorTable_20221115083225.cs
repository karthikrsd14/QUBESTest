using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083225)]
    public class AddVendorTable_20221115083225 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("Vendor").ForeignColumn("CategoryId").ToTable("Category").PrimaryColumn("Id");
            Delete.ForeignKey().FromTable("Vendor").ForeignColumn("CountryId").ToTable("Country").PrimaryColumn("Id");
            Delete.ForeignKey().FromTable("Vendor").ForeignColumn("StateId").ToTable("State").PrimaryColumn("Id");
            Delete.Table("Vendor");
        }

        public override void Up()
        {
            Create.Table("Vendor")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Company").AsString(50).NotNullable()
                .WithColumn("EnrollmentDate").AsDateTime().NotNullable()
                .WithColumn("CategoryId").AsInt32().NotNullable().ForeignKey("Category", "Id")
                .WithColumn("CountryId").AsInt32().NotNullable().ForeignKey("Country", "Id")
                .WithColumn("StateId").AsInt32().NotNullable().ForeignKey("State", "Id")
                .WithColumn("City").AsString(50).NotNullable()
                .WithColumn("PostalCode").AsInt32().NotNullable()
                .WithColumn("WebSite").AsString(20).Nullable()
                .WithColumn("RegisteredAddress").AsString(500).NotNullable();
        }
    }
}
