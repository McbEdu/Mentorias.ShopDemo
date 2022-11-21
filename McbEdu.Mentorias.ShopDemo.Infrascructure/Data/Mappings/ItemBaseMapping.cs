using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class ItemBaseMapping : IBaseMapping<Item>
{
    public void CreateBaseMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Item> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.HasOne(p => p.Order).WithMany(p => p.Items);
        entity.HasOne(p => p.Product).WithMany(p => p.Items);
    }
}
