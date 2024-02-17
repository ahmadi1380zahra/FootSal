using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Migrations
{
    [Migration(202402171650)]
    public class _202402171650_AddTeam : Migration
    {
        public override void Up()
        {
            Create.Table("Teams")
                      .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                      .WithColumn("Name").AsString(50).NotNullable()
                      .WithColumn("MainColor").AsInt32().NotNullable()
                      .WithColumn("SubColor").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Teams");
        }

      
    }
}
