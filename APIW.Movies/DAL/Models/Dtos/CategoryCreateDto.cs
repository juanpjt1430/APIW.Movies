using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models.Dtos
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "El nombre  de la categoria es obligatorio")]
        [MaxLength(100,ErrorMessage ="El numero maximo de caracteres es de 100")]
        public string Name { get; set; }
    }
}
