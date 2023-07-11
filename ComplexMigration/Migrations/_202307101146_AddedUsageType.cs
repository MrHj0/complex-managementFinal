using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307101146)]
    public class _202307101146_AddedUsageType : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("UsageTypes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("UsageTypes");
        }
    }
}
