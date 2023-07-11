using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307111154)]
    public class _202307111154_DeletedFKComplexUsageType : FluentMigrator.Migration
    {
        
        public override void Up()
        {
            Delete.ForeignKey("FK_ComplexUsageTypes_Complexs")
                .OnTable("ComplexUsageTypes");

            Delete.ForeignKey("FK_ComplexUsageTypes_UsageTypes")
                .OnTable("ComplexUsageTypes");


        }

        public override void Down()
        {
            
        }
    }
}
