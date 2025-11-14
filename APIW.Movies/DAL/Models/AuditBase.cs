using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key]
        public virtual int id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; } 
        


    }
}
