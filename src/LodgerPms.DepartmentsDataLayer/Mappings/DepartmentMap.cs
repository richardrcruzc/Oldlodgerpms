
using LodgerPms.DepartmentsDataLayer.Extensions;
using LodgerPms.Domain.Departments;
using LodgerPms.Domain.Departments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LodgerPms.DepartmentsDataLayer.Mappings
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public override void Map(EntityTypeBuilder<Department> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Description)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            //builder.Property(c => c.Email)
            //    .HasColumnType("varchar(100)")
            //    .HasMaxLength(11)
            //    .IsRequired();
        }
    }
}
