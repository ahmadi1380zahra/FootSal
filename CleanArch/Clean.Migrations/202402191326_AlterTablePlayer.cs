using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Migrations
{
    [Migration(202402191326)]
    public class _202402191326_AlterTablePlayer : Migration
    {
        public override void Up()
        {
            Alter.Table("Players").AddColumn("PlayerPost").AsInt32().Nullable();
        }
        public override void Down()
        {
            Delete.Column("PlayerPost").FromTable("Players");
        }

      
    }
}
