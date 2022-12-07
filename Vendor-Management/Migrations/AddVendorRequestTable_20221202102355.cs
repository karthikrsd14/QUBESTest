using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221202102355)]
    public class AddVendorRequestTable_20221202102355 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("AddtionalInfo").ForeignColumn("VendorId").ToTable("Vendor").PrimaryColumn("Id");

            Delete.Table("AddtionalInfo");
        }

        public override void Up()
        {
            Create.Table("AddtionalInfo")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
           .WithColumn("AdditionalInfo").AsString(60)
           .WithColumn("CommentBox").AsString(60)
           .WithColumn("RisedBy").AsString(30)
           .WithColumn("PrimaryApprover").AsInt32().NotNullable()
           .WithColumn("AlternativeApprover").AsInt32().NotNullable()
            .WithColumn("VendorId").AsInt32().NotNullable().ForeignKey("Vendor","Id");
           

        }
   
    }
    
    }

  

