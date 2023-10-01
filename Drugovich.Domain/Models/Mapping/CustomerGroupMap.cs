using Drugovich.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Drugovich.Domain.Models.Mapping
{
    public class CustomerGroupMap : IEntityTypeConfiguration<CustomerGroup>
    {
        public void Configure(EntityTypeBuilder<CustomerGroup> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.GroupName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Registered)
                .IsRequired();

            builder.Property(x => x.LastUpdate)
                .IsRequired();

            // To Table & Column Names
            builder.ToTable("CustomerGroups");
            builder.Property(x => x.GroupName).HasColumnName("GroupName");
            builder.Property(x => x.Registered).HasColumnName("Registered");
            builder.Property(x => x.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
