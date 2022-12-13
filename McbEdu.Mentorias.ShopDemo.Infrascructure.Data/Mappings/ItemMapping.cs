using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.ItemContext.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class ItemMapping : BaseMapping<Item>
{
    public void CreateMapping(EntityTypeBuilder<Item> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.HasOne(p => p.Order).WithMany(p => p.Items);
    }
}
