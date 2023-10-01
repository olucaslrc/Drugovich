using Drugovich.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugovich.Domain.Models.Mapping
{
    public class ManagerMap : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Level)
                .IsRequired();

            builder.Property(x => x.Registered)
                .IsRequired();

            builder.Property(x => x.LastUpdate)
                .IsRequired();

            // To Table & Column Names
            builder.ToTable("Managers");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Level).HasColumnName("Level");
            builder.Property(x => x.Registered).HasColumnName("Registered");
            builder.Property(x => x.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
