namespace GalleryAPIWebApp.Models
{
    public class ActorFilm
    {
        public int Id { get; set; }
        public int ActorID { get; set; }
        public int FilmId { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
        public bool IsLeadingRole { get; set; }
    }
}
