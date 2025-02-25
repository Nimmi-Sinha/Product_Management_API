using Product_Management_API.DTO;

namespace Product_Management_API.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategorysAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO Category);
        Task UpdateCategoryAsync(CategoryDTO Category);
        Task DeleteCategoryAsync(int id);
        bool CategoryAvailable(int id);
    }
}
