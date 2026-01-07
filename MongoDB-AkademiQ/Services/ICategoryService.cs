using MongoDB_AkademiQ.DTOs.CategoryDTOs;

namespace MongoDB_AkademiQ.Services
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDTO>> GetAllAsync();
        Task<UpdateCategoryDTO> GetByIdAsync(string id);
        Task CreateAsync(CreateCategoryDTO createCategoryDTO);
        Task UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task DeleteAsync(string id);
    }
}
