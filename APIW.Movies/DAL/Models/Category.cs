using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //Decorator también se llaman Data Annotations
        [Display(Name = "Categoría")] //Este decorator me permite cambiar el nombre de la propiedad en las vistas        
        public string Name { get; set; }
    }
}
