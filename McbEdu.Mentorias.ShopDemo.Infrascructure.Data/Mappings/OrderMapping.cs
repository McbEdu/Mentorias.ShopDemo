using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class OrderMapping : BaseMapping<Order>
{
    public void CreateMapping(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.HasOne(p => p.Customer).WithMany(p => p.Orders);
    }
}
