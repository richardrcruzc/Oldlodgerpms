using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LodgerPms.DepartmentsDataLayer.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
