using MongoDB_AkademiQ.DTOs.ProductDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Products
{
    public interface IProductService : IGenericService<Product, CreateProductDTO, UpdateProductDTO, ResultProductDTO>
    {
        Task<List<ResultProductDTO>> SearchAsync(string searchTerm);
    }
}
