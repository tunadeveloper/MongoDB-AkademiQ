using MongoDB_AkademiQ.DTOs.ProductDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Products
{
    public interface IProductService : IGenericService<Product, CreateProductDTO, UpdateProductDTO, ResultProductDTO>
    {
        Task<List<ResultProductDTO>> SearchAsync(string searchTerm);
        Task<List<ResultProductDTO>> GetFilteredAsync(List<string>? categoryIds, decimal? minPrice, decimal? maxPrice, string? sort);
        Task<Dictionary<string, int>> GetCategoryProductCountsAsync();
        Task<ResultProductDTO?> GetByIdForDisplayAsync(string id);
    }
}
