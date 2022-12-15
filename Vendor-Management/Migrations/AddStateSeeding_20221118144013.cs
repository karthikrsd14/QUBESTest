using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor_Management.Migrations
{
    public class AddStateSeeding_20221118144013 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("State").Row(new { CountryId = 1 });
        }

        public override void Up()
        {
            Insert.IntoTable("State").Row(new { Id = "1", Name = ("AndhraPradesh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "2", Name = ("ArunachalPradesh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "3", Name = ("Assam"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "4", Name = ("Bihar"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "5", Name = ("Chhattisgarh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "6", Name = ("Goa"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "7", Name = ("Gujarat"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "8", Name = ("Haryana"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "9", Name = ("HimachalPradesh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "10", Name = ("Jharkhand"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "11", Name = ("Karnataka"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "12", Name = ("Kerala"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "13", Name = ("MadhyaPradesh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "14", Name = ("Maharashtra"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "15", Name = ("Manipur"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "16", Name = ("Meghalaya"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "17", Name = ("Mizoram"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "18", Name = ("Nagaland"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "19", Name = ("Odisha"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "20", Name = ("Punjab"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "21", Name = ("Rajasthan"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "22", Name = ("Sikkim"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "23", Name = ("TamilNadu"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "24", Name = ("Telangana"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "25", Name = ("Tripura"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "26", Name = ("Uttarakhand"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "27", Name = ("UttarPradesh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "28", Name = ("WestBengal"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "29", Name = ("AndamanandNicobarIslands"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "30", Name = ("Chandigarh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "31", Name = ("DadraandNagarHaveliandDaman&Diu"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "32", Name = ("TheGovernmentofNCTofDelhi"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "33", Name = ("Jammu&Kashmir"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "34", Name = ("Ladakh"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "35", Name = ("Lakshadweep"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });
            Insert.IntoTable("State").Row(new { Id = "36", Name = ("Puducherry"), CreatedDate = (DateTime.UtcNow), UpdatedDate = (DateTime.UtcNow), CountryId = ("1") });

        }
    }
}
