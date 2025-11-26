using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public int Year { get; set; }

        public string? Director { get; set; }
    }
}