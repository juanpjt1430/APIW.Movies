using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }

        // "Name" requerido, no nulo, max 100
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Duración (en minutos). No nulo -> usar int y exigir > 0 en DTO/validación.
        [Required]
        public int Duration { get; set; }

        // Clasification requerido, max 10
        [Required]
        [StringLength(10)]
        public string Clasification { get; set; }

        // Campos opcionales
        public string? Description { get; set; }
        public int Year { get; set; }
        public string? Director { get; set; }
    }
}
