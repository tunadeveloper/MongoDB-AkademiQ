using MongoDB_AkademiQ.DTOs.ProductDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;
using MongoDB.Driver;

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

    public async Task<List<ResultProductDTO>> SearchAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return new List<ResultProductDTO>();

        var filter = Builders<Product>.Filter.Or(
            Builders<Product>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(searchTerm, "i")),
            Builders<Product>.Filter.Regex(p => p.Description, new MongoDB.Bson.BsonRegularExpression(searchTerm, "i"))
        );

        var products = await _mongoCollection.Find(filter).ToListAsync();
        return products.Select(MapToResultDTO).ToList();
    }

    public async Task<List<ResultProductDTO>> GetFilteredAsync(List<string>? categoryIds, decimal? minPrice, decimal? maxPrice, string? sort)
    {
        var allProducts = await GetAllAsync();
        var filteredProducts = allProducts.AsEnumerable();

        if (categoryIds != null && categoryIds.Count > 0)
        {
            filteredProducts = filteredProducts.Where(x => x.CategoryId != null && categoryIds.Contains(x.CategoryId));
        }

        if (minPrice.HasValue)
        {
            filteredProducts = filteredProducts.Where(x => x.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            filteredProducts = filteredProducts.Where(x => x.Price <= maxPrice.Value);
        }

        var result = filteredProducts.ToList();

        switch (sort)
        {
            case "price-asc":
                result = result.OrderBy(x => x.Price).ToList();
                break;
            case "price-desc":
                result = result.OrderByDescending(x => x.Price).ToList();
                break;
            case "popular":
                result = result.OrderByDescending(x => x.IsPopular).ThenBy(x => x.Name).ToList();
                break;
            case "name-asc":
                result = result.OrderBy(x => x.Name).ToList();
                break;
            case "name-desc":
                result = result.OrderByDescending(x => x.Name).ToList();
                break;
            default:
                result = result.OrderByDescending(x => x.IsPopular).ThenBy(x => x.Name).ToList();
                break;
        }

        return result;
    }

    public async Task<Dictionary<string, int>> GetCategoryProductCountsAsync()
    {
        var allProducts = await GetAllAsync();
        return allProducts
            .Where(p => !string.IsNullOrEmpty(p.CategoryId))
            .GroupBy(p => p.CategoryId)
            .ToDictionary(g => g.Key!, g => g.Count());
    }
}
