using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(AM => new
            {
                AM.MovieId,
                AM.ActorId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(AM => AM.Movie).WithMany(Movie => Movie.Actors);
            modelBuilder.Entity<Actor_Movie>().HasOne(AM => AM.Actor).WithMany(actor => actor.Movies);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor_Movie> Actor_Movies  { get; set; }

    }   
}
