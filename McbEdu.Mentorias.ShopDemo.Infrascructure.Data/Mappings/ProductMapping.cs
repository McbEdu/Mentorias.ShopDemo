using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class ProductMapping : BaseMapping<Product>
{
    public void CreateMapping(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(p => p.Identifier);
    }
}
