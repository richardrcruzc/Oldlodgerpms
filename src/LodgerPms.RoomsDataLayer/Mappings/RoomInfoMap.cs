
using LodgerPms.Domain.Rooms;
using LodgerPms.RoomsDataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LodgerPms.RoomsDataLayer.Mappings
{
   
    public class RoomInfoMap : EntityTypeConfiguration<RoomInfo>
    {
        public override void Map(EntityTypeBuilder<RoomInfo> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            //builder.Property(c => c.Description)
            //    .HasColumnType("nvarchar(100)")
            //    .HasMaxLength(100)
            //    .IsRequired();

            //builder.Property(c => c.Email)
            //    .HasColumnType("varchar(100)")
            //    .HasMaxLength(11)
            //    .IsRequired();
        }
    }
}
