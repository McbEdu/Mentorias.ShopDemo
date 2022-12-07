using McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.ShopDemo.Infrascructure.Data.Mappings;

public class CustomerMapping : BaseMapping<Customer>
{
    public void CreateMapping(EntityTypeBuilder<Customer> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.Property(p => p.BirthDate)
            .IsRequired()
            .HasColumnType("DATE");
    }
}
