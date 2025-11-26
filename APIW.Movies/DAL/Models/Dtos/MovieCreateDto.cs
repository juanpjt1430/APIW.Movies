using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models.Dtos
{
    public class MovieCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public int Year { get; set; }

        public string? Director { get; set; }
    }
}