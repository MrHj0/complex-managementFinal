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
    public class UsageTypeMap : IEntityTypeConfiguration<UsageType>
    {
        public void Configure(EntityTypeBuilder<UsageType> usageType)
        {
            usageType.ToTable("UsageTypes");
            usageType.HasKey(x => x.Id);
            usageType.Property(_ => _.Id).ValueGeneratedOnAdd();
            usageType.Property(_ => _.Title).HasMaxLength(50).IsRequired();
        }
    }
}
