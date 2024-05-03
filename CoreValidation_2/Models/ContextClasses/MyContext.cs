using CoreValidation_2.Models.Configurations;
using CoreValidation_2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreValidation_2.Models.ContextClasses
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt):base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
    }
}
