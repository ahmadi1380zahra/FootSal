using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Migrations
{
    [Migration(202402171657)]
    public class _202402171657_AddPlayes : Migration
    {
        public override void Up()
        {
            Create.Table("Players")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("FullName").AsString(50).NotNullable()
                .WithColumn("BirthDate").AsDate().NotNullable()
                .WithColumn("TeamId").AsInt32().Nullable()
                   .ForeignKey("FK_Players_Teams", "Teams", "Id") ;
        }
        public override void Down()
        {
            Delete.ForeignKey("FK_Players_Teams").OnTable("Players");
            Delete.Table("Players");
        }

       
    }
}
