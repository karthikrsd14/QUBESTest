using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083125)]
    public class AddCategoryTable_20221115083125 : Migration
    {
        public override void Down()
        {
            Delete.Table("Category");
        }

        public override void Up()
        {
            Create.Table("Category")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CreatedDate").AsDateTime().NotNullable()
                .WithColumn("UpdatedDate").AsDateTime().NotNullable();
        }
    }
}
