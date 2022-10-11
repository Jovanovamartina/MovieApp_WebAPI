using BookApp.HelperMethods;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Data
{
    public class DataContext : DbContext
    {
        private readonly IHasher _hasher;
        public DataContext(DbContextOptions options, IHasher hasher) : base(options)
        {
            _hasher = hasher;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieProducer> MovieProducers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<User>Users { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>()
                     .HasKey(pc => new { pc.MovieId, pc.CategoryId });
            modelBuilder.Entity<MovieCategory>()
                    .HasOne(p => p.Movie)
                    .WithMany(pc => pc.MovieCategories)
                    .HasForeignKey(p => p.MovieId);
            modelBuilder.Entity<MovieCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.MovieCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<MovieProducer>()
                    .HasKey(po => new { po.MovieId, po.ProducerId });
            modelBuilder.Entity<MovieProducer>()
                    .HasOne(p => p.Movie)
                    .WithMany(pc => pc.MovieProducers)
                    .HasForeignKey(p => p.MovieId);
            modelBuilder.Entity<MovieProducer>()
                    .HasOne(p => p.Producer)
                    .WithMany(pc => pc.MovieProducers)
                    .HasForeignKey(c => c.ProducerId);
        }



    }
}
