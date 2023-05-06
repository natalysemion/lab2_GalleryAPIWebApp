namespace GalleryAPIWebApp.Models
{
    public class Film
    {
        public Film() 
        {
            ActorFilms = new List<ActorFilm>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int CategoryId { get; set; } 
        public int ProductionCompanyId { get; set; }
        bool IsFavorite { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductionCompany ProductionCompany { get; set; }
        public virtual ICollection<ActorFilm> ActorFilms { get; set; } = new List<ActorFilm>();
    }
}
