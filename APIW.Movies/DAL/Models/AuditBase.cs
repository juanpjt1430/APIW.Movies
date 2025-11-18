using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key] //Este decorator me indica que esta propiedad es la PK
        public virtual int Id { get; set; } //nuestra PK

        public virtual DateTime CreatedDate { get; set; } //Me indica la fecha de creación de cada registro en BD

        public virtual DateTime? UpdatedDate { get; set; } //Me indica la fecha de actualización de cada registro en BD
    }
}