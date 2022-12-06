using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083525)]
    public class AddUploadedFilesDetailTable_20221115083525 : Migration
    {
        public override void Down()
        {
            Delete.Table("UploadedFilesDetail");
        }

        public override void Up()
        {
            Create.Table("UploadedFilesDetail")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CreatedDate").AsDateTime().NotNullable()
                .WithColumn("UpdatedDate").AsDateTime().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable();
        }
    }
}
