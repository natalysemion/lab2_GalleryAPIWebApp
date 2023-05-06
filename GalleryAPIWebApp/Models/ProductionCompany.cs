using System.ComponentModel.DataAnnotations;
namespace GalleryAPIWebApp.Models
{
    public class ProductionCompany
    {
        public ProductionCompany()
        {
            Films = new List<Film>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Film> Films { get;set; }
    }
}
