using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221115083025)]
    public class AddStatesTable_20221115083025 : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey().FromTable("State").ForeignColumn("CountryId").ToTable("Country").PrimaryColumn("Id");
            Delete.Table("State");
        }

        public override void Up()
        {
            Create.Table("State")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CreatedDate").AsDateTime().NotNullable()
                .WithColumn("UpdatedDate").AsDateTime().NotNullable()
                .WithColumn("CountryId").AsInt32().NotNullable().ForeignKey("Country","Id");
        }
    }
}
