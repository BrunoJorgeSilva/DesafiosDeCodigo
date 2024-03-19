using Microsoft.EntityFrameworkCore;
using TestLiveCode.Model;

namespace TestLiveCode.Context
{
    public class DbContextExample : DbContext
    {
        public DbContextExample(DbContextOptions<DbContextExample> options) : base(options)
        {
            
        }

        public DbSet<Example> Example { get; set; }
        public DbSet<ExampleDetails> ExampleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example>(e =>
            {
                e.HasKey(k => k.Id);
                e.Property(k => k.Name).HasMaxLength(500).HasColumnType("VARCHAR(500)");
                e.Property(k => k.Date).HasColumnType("datetime");
                e.Property(k => k.Description).HasMaxLength(250).HasColumnType("VARCHAR(250)");

                e.Property(k => k.IsDeleted).HasColumnName("Is_Deleted").HasColumnType("bit").IsRequired(true);
                e.HasMany(e => e.ExampleDetails)
                         .WithOne(e => e.Example)
                         .HasForeignKey(details => details.ExampleId); ;
            });

            modelBuilder.Entity<ExampleDetails>(e =>
            {
                e.HasKey(k => k.Id);
                e.Property(k => k.Details).HasColumnName("DETAILS").HasMaxLength(1000).HasColumnType("VARCHAR(1000)");
                e.Property(k => k.ExampleId).HasColumnName("Example_Id");
            });
        }

    }
}
