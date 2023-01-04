using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.DTO;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class ProductMapping : BaseMapping<Product>
{
    public void CreateMapping(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.HasIndex(p => p.Identifier).IsUnique();
        entity.HasIndex(p => p.Code).IsUnique();

        entity.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(Code.MaxValueLength)
            .HasColumnType("VARCHAR");

        entity.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnType("VARCHAR");
    }
}
