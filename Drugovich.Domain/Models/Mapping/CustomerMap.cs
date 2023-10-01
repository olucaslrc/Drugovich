using Drugovich.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drugovich.Domain.Models.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CNPJ)
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(x => x.FK_CustomerGroup)
                .IsRequired();

            builder.Property(x => x.Registered)
                .IsRequired();

            builder.Property(x => x.LastUpdate)
                .IsRequired();

            // To Table & Column Names
            builder.ToTable("Customers");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.CNPJ).HasColumnName("CNPJ");
            builder.Property(x => x.FK_CustomerGroup).HasColumnName("FK_CustomerGroup");
            builder.Property(x => x.Registered).HasColumnName("Registered");
            builder.Property(x => x.LastUpdate).HasColumnName("LastUpdate");

            // Relationships
            builder.HasOne(x => x.CustomerGroup)
                .WithOne(x => x.Customer)
                .HasForeignKey<Customer>(x => x.FK_CustomerGroup);
        }
    }
}
