using ComplexManagment.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.EntitesMap
{
    internal class BlockUsageTypeMap : IEntityTypeConfiguration<BlockUsageType>
    {
        public void Configure(EntityTypeBuilder<BlockUsageType> blockUsageType)
        {
            blockUsageType.ToTable("BlockUsageTypes");
            blockUsageType.HasKey(_ => new
            {
                _.BlockId,
                _.UsagetypeId
            });

            blockUsageType.Property(_ => _.UsagetypeId)
                .ValueGeneratedNever();
            blockUsageType.Property(_ => _.BlockId)
                .ValueGeneratedNever();


            //blockUsageType.HasOne(_=>_.UsageType)
            //    .WithMany(_=>_.Blocks)
            //    .HasForeignKey(_=>_.UsagetypeId);

            blockUsageType.HasOne(_ => _.Block)
                .WithMany(_ => _.UsageTypes)
                .HasForeignKey(_ => _.BlockId);
        }
    }
}
