using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class CustomerMapping : BaseMapping<Customer>
{
    public void CreateMapping(EntityTypeBuilder<Customer> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.HasIndex(p => p.Identifier).IsUnique();
        entity.HasIndex(p => p.Email).IsUnique();

        entity.Property(p => p.BirthDate)
            .IsRequired()
            .HasConversion(p => p.ToShortDateString(), p => Convert.ToDateTime(p))
            .HasColumnType("DATE");

        entity.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(Email.MaxValueLength)
            .HasColumnType("VARCHAR");

        entity.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Name.MaxNameLength)
            .HasColumnType("VARCHAR");

        entity.Property(p => p.Surname)
            .IsRequired()
            .HasMaxLength(Surname.MaxSurnameLength)
            .HasColumnType("VARCHAR");
    }
}
