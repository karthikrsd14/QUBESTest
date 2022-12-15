using FluentMigrator;

namespace Vendor_Management.Migrations
{
    [Migration(20221208125895)]
    public class AddUserTable_20221208125895 : Migration
    {
        public override void Down()
        {
           
            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("User")
                 .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                 .WithColumn("EmpId").AsInt32().NotNullable()
                 .WithColumn("Name").AsString(30).NotNullable()
                 .WithColumn("Designation").AsString(30).NotNullable()
                 .WithColumn("EmailId").AsString(30).NotNullable()
                 .WithColumn("Password").AsString(30).NotNullable()
                 .WithColumn("ReEnterPassword").AsString(30).NotNullable()
                 .WithColumn("UserType").AsInt32().NotNullable();
                 
        }
    }
}
