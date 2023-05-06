using Microsoft.EntityFrameworkCore;
namespace GalleryAPIWebApp.Models
{
    public class GalleryAPIContext : DbContext
    {
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<ActorFilm> ActorFilms { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }

        public GalleryAPIContext(DbContextOptions<GalleryAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
