using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ProductContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class ItemMapping : BaseMapping<Item>
{
    public void CreateMapping(EntityTypeBuilder<Item> entity)
    {
        entity.ToTable("OrderItem");

        entity.HasKey(p => p.Identifier);

        entity.HasIndex(p => p.Identifier).IsUnique();

        entity.Property(p => p.ProductCode)
            .IsRequired()
            .HasMaxLength(Code.MaxValueLength)
            .HasColumnType("VARCHAR");

        entity.Property(p => p.ProductDescription)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnType("VARCHAR");

        entity.Property(p => p.ProductIdentifier)
            .IsRequired()
            .HasColumnType("VARCHAR");

        entity.Property(p => p.Sequence)
            .IsRequired()
            .HasColumnType("INTEGER");

        entity.Property(p => p.UnitaryValue)
            .IsRequired()
            .HasColumnType("DECIMAL");

        entity.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(150);

        entity.HasOne(p => p.Order).WithMany(p => p.Items);
    }
}
