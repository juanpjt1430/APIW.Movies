using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;

namespace APIW.Movies.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<bool> CategoryExistsByIdAsync(int id);
        Task<bool> CategoryExistsByNameAsync(string name);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}