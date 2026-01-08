using MongoDB_AkademiQ.DTOs.ProductDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Products;

public class ProductService : GenericService<Product, CreateProductDTO, UpdateProductDTO, ResultProductDTO>, IProductService
{
    public ProductService(IDatabaseSettings databaseSettings) 
        : base(databaseSettings, databaseSettings.ProductCollection)
    {
    }

    protected override Product MapToEntity(CreateProductDTO createDTO)
    {
        return new Product
        {
            Name = createDTO.Name,
            Description = createDTO.Description,
            ImageUrl = createDTO.ImageUrl,
            Price = createDTO.Price,
            IsPopular = createDTO.IsPopular,
            CategoryName = createDTO.CategoryId
        };
    }

    protected override Product MapToEntity(UpdateProductDTO updateDTO)
    {
        return new Product
        {
            Id = updateDTO.Id,
            Name = updateDTO.Name,
            Description = updateDTO.Description,
            ImageUrl = updateDTO.ImageUrl,
            Price = updateDTO.Price,
            IsPopular = updateDTO.IsPopular,
            CategoryName = updateDTO.CategoryId
        };
    }

    protected override ResultProductDTO MapToResultDTO(Product entity)
    {
        return new ResultProductDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            Price = entity.Price,
            IsPopular = entity.IsPopular,
            CategoryId = entity.CategoryName
        };
    }

    protected override UpdateProductDTO MapToUpdateDTO(Product entity)
    {
        return new UpdateProductDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            Price = entity.Price,
            IsPopular = entity.IsPopular,
            CategoryId = entity.CategoryName
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateProductDTO updateDTO)
    {
        return updateDTO.Id;
    }
}
