namespace GalleryAPIWebApp.Models
{
    public class Actor
    {
        public Actor() 
        { 
            ActorFilms = new List<ActorFilm>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Rating { get; set; }
        public string Gender { get; set; }
        public ICollection<ActorFilm> ActorFilms { get; set; }
    }
}
