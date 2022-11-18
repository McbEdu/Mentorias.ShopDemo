using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class ProductBaseMapping : IBaseMapping<Product>
{
    public void CreateBaseMapping(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(p => p.Identifier);
    }
}
