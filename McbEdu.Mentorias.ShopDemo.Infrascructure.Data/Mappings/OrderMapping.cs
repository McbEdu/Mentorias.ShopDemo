using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.OrderContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class OrderMapping : BaseMapping<Order>
{
    public void CreateMapping(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.HasIndex(p => p.Identifier).IsUnique();

        entity.HasIndex(p => p.Code).IsUnique();

        entity.Property(p => p.Code)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(Code.MaxValueLength);

        entity.Property(p => p.OrderTime)
            .IsRequired()
            .HasColumnType("DATETIME");

        entity.Property(p => p.CustomerIdentifier)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(Guid.Empty.ToString().Count());

        entity.Property(p => p.CustomerBirthdate)
            .IsRequired()
            .HasColumnType("DATE")
            .HasConversion<string>(p => p.ToShortDateString(), p => Convert.ToDateTime(p));

        entity.Property(P => P.CustomerEmail)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(Email.MaxValueLength);

        entity.Property(p => p.CustomerName)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(Name.MaxNameLength);

        entity.Property(p => p.CustomerSurname)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(Surname.MaxSurnameLength);
    }
}
