﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307101446)]
    public class _202307101446_AddedComplexUsageType : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("ComplexUsageTypes")
                .WithColumn("ComplexId").AsInt32().PrimaryKey()
                .ForeignKey("FK_ComplexUsageTypes_Complexs",
                            "Complexs", "Id")
                .WithColumn("UsageTypeId").AsInt32().PrimaryKey()
                .ForeignKey("FK_ComplexUsageTypes_UsageTypes",
                            "UsageTypes", "Id");
        }

        public override void Down()
        {
            Delete.Table("ComplexUsageTypes");
        }
    }
}
