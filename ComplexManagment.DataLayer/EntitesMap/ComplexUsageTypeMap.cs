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
    internal class ComplexUsageTypeMap : IEntityTypeConfiguration<ComplexUsageType>
    {
        public void Configure(EntityTypeBuilder<ComplexUsageType> complexUsageType)
        {
            complexUsageType.ToTable("ComplexUsageTypes");
            complexUsageType.HasKey(_ => new
            {
                _.UsageTypeId,
                _.ComplexId
            });

            complexUsageType.Property(_=>_.UsageTypeId)
                .ValueGeneratedNever();
            complexUsageType.Property(_ => _.ComplexId)
                .ValueGeneratedNever();

            //complexUsageType.HasOne(_ => _.Complex)
            //    .WithMany(_ => _.UsageTypes)
            //    .HasForeignKey(_ => _.ComplexId);

            //complexUsageType.HasOne(_=>_.UsageType)
            //    .WithMany(_=>_.Complexes)
            //    .HasForeignKey(_=>_.UsageTypeId);


        }
    }
}
