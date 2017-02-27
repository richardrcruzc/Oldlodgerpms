
using LodgerPms.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace LodgerPms.BookingsDataLayer
{
    public class BookingsContext: DbContext
    {
        public BookingsContext(DbContextOptions<BookingsContext> options)
         : base(options)
        { }

        public DbSet<Booking> Bookings { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>()
             .ToTable("Bookings")
             .HasKey(x => x.Id);
        }
    }
}
