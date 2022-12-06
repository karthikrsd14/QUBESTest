using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083625)]
    public class AddKYCTable_20221115083625 : Migration
    {
        public override void Down()
        {
            Delete.Table("KYC");
        }

        public override void Up()
        {
            Create.Table("KYC")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("PanNumber").AsString(50).Nullable()
                .WithColumn("GSTRegistrationNumber").AsString(20).NotNullable()
                .WithColumn("VAT").AsString(20).Nullable()
                .WithColumn("SSIRegistration").AsString(50).Nullable()
                .WithColumn("BankName").AsString(50).NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("AccountNumber").AsString(20).NotNullable()
                .WithColumn("IFSCCode").AsString(20).NotNullable()
                .WithColumn("BranchName").AsString(50).NotNullable()
                .WithColumn("UPIId").AsString(20).NotNullable()
                .WithColumn("Reference").AsString(200).Nullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable();
        }
    }
}
