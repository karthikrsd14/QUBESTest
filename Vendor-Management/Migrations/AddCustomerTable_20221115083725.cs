using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083725)]
    public class AddCustomerTable_20221115083725 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("Customer").ForeignColumn("CountryId").ToTable("Country").PrimaryColumn("Id");
            Delete.ForeignKey().FromTable("Customer").ForeignColumn("StateId").ToTable("State").PrimaryColumn("Id");
            Delete.Table("Customer");
        }

        public override void Up()
        {
            Create.Table("Customer")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("EnrollmentDate").AsDateTime().NotNullable()
                .WithColumn("PrimaryEmail").AsString(20).NotNullable()
                .WithColumn("City").AsString(50).NotNullable()
                .WithColumn("PrimaryContactNumber").AsInt32().NotNullable()
                .WithColumn("AlternativeEmail").AsString(20).Nullable()
                .WithColumn("AlternativeContactNumber").AsInt32().Nullable()
                .WithColumn("CreditLimit").AsInt32().NotNullable()
                .WithColumn("StateId").AsInt32().NotNullable().ForeignKey("State", "Id")
                .WithColumn("CountryId").AsInt32().NotNullable().ForeignKey("Country", "Id")
                .WithColumn("PostalCode").AsInt32().NotNullable()
                .WithColumn("WebSite").AsString(20).Nullable()
                .WithColumn("RegisteredAddress").AsString(200).NotNullable()
                .WithColumn("CustomerContactName").AsString(50).NotNullable()
                .WithColumn("IsBillingsameasShippingAddress").AsBoolean().NotNullable();
        }
    }
}
