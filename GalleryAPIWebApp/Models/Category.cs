namespace GalleryAPIWebApp.Models
{
    public class Category
    {
        public Category() 
        { 
            Films = new List<Film>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get;}
    }
}
