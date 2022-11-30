using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace McbEdu.Mentorias.General.Infrascructure.Abstractions.Mappings;

public interface BaseMapping<TEntity>
    where TEntity : class
{
    public void CreateMapping(EntityTypeBuilder<TEntity> entity);
}
