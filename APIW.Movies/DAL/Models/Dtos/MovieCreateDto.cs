using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models.Dtos
{
    public class MovieCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
        public int Duration { get; set; }

        [Required]
        [StringLength(10)]
        public string Clasification { get; set; }

        public string? Description { get; set; }

        public int Year { get; set; }

        public string? Director { get; set; }
    }
}
