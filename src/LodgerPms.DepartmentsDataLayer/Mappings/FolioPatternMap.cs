using LodgerPms.DepartmentsDataLayer.Extensions;
using LodgerPms.Domain.Departments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LodgerPms.DepartmentsDataLayer.Mappings
{
 
    public class FolioPatternMap : EntityTypeConfiguration<FolioPattern>
    {
        public override void Map(EntityTypeBuilder<FolioPattern> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Description)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Code)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(100)
                .IsRequired();

            //builder.Property(c => c.Email)
            //    .HasColumnType("varchar(100)")
            //    .HasMaxLength(11)
            //    .IsRequired();
        }
    }
}
