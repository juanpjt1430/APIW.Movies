using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] // Este Data notacion indica que el campo es obligatorio
        [Display(Name = "Category Name")] // Esta Data notacion especifica el nombre para mostrar del campo
        public String Name { get; set; }
    }
}
