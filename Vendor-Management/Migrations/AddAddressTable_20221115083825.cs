using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083825)]
    public class AddAddressTable_20221115083825 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("Addresses").ForeignColumn("CustomerId").ToTable("Customer").PrimaryColumn("Id");
           
            Delete.Table("Addresses");
        }

        public override void Up()
        {
            Create.Table("Addresses")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Address").AsString(200).NotNullable()
                .WithColumn("State").AsInt32().NotNullable()
                .WithColumn("Country").AsInt32().NotNullable()
                .WithColumn("City").AsString(50).NotNullable()
                .WithColumn("PostalCode").AsInt32().NotNullable()
                .WithColumn("PhoneNumber").AsInt32().NotNullable()
                .WithColumn("CustomerId").AsInt32().NotNullable().ForeignKey("Customer","Id")
                .WithColumn("IsBillingAddress").AsBoolean().NotNullable();
        }
    }
}
