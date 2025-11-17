using APIW.Movies.DAL;
using APIW.Movies.DAL.Models;
using APIW.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIW.Movies.Repository
{
    public class CategoryRepository : ICategoryRepository

    { private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // Patron inyeccion de dependencias. asi se utiliza 


        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            return await _context.Categories
            .AsNoTracking()
            .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _context.Categories
            .AsNoTracking()
            .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;

            await _context.Categories.AddAsync(category);

            return await SaveAsync();

            // SQL Insert DENTRO DE LOS METODOS DE MODIFICACION O ESCRITURA


        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            return await SaveAsync();
            // Delete from category where id = 2
        }


        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories
            .AsNoTracking()
            .FirstAsync(c => c.Id == id); // lambda funtions 

        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;

            _context.Categories.Update(category);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
