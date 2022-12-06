using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221202102355)]
    public class AdditionalInfoTable_20221202102355 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("VendorRequest").ForeignColumn("VendorId").ToTable("Vendor").PrimaryColumn("Id");

            Delete.Table("VendorRequest");
        }

        public override void Up()
        {
            Create.Table("VendorRequest")
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

  

