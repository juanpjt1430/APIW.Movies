using APIW.Movies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIW.Movies.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
         
        }

        // seccion para crear el dbset de las entidades o modelos   
        public DbSet<Category> Categories { get; set; }
        }
}
    