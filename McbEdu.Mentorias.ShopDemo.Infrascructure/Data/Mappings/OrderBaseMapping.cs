using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class OrderBaseMapping : IBaseMapping<Order>
{
    public void CreateBaseMapping(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(p => p.Identifier);
    }
}
