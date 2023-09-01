using System.ComponentModel.DataAnnotations;

namespace MVC_Movie.Models
{
    public class Movie
    {
        [key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]

        public string? Mname { get; set; }
        [Required]

        public DateTime ReleaseDate { get; set; }
        [Required]

        public string Genre { get; set; }
        [Required]
        public string StarsName { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
