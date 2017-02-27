using LodgerPms.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.DepartmentsDataLayer
{ 
    public class DepartmentContext : DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options)
         : base(options)
        { }

        public DbSet<Department> Departments { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>()
             .ToTable("Departments")
             .HasKey(x => x.Id);
        }
    }
}
