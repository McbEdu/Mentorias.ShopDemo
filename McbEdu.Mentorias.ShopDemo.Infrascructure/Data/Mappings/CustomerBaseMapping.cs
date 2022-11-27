using McbEdu.Mentorias.ShopDemo.Domain.Contracts.Infrascructure.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class CustomerBaseMapping : IBaseMapping<Customer>
{
    public void CreateBaseMapping(EntityTypeBuilder<Customer> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.Property(p => p.Birthday);
    }
}
