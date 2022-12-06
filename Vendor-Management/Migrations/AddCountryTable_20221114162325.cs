using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221114162325)]
    public class AddCountryTable_20221114162325 : Migration
    {
        public override void Down()
        {
            Delete.Table("Country");
        }

        public override void Up()
        {
            Create.Table("Country")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()                
                .WithColumn("CreatedDate").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedDate").AsDateTime().Nullable();
        }
    }
}
