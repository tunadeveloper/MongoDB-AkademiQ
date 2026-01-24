using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB_AkademiQ.DTOs.ProductDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Products;

public class ProductService : GenericService<Product, CreateProductDTO, UpdateProductDTO, ResultProductDTO>, IProductService
{
    public ProductService(IDatabaseSettings settings) : base(settings, settings.ProductCollection)
    {
    }

    public async Task<List<ResultProductDTO>> SearchAsync(string searchTerm)
    {
        var filter = Builders<Product>.Filter.Or(
            Builders<Product>.Filter.Regex("Name", new MongoDB.Bson.BsonRegularExpression(searchTerm, "i")),
            Builders<Product>.Filter.Regex("Description", new MongoDB.Bson.BsonRegularExpression(searchTerm, "i"))
        );

        var products = await _collection.Find(filter).ToListAsync();
        return products.Select(MapToResultDTO).ToList();
    }

    public async Task<List<ResultProductDTO>> GetFilteredAsync(List<string>? categoryIds, decimal? minPrice, decimal? maxPrice, string? sort)
    {
        var filterDefinitions = new List<FilterDefinition<Product>>();

        if (categoryIds != null && categoryIds.Any())
        {
            filterDefinitions.Add(Builders<Product>.Filter.In("CategoryName", categoryIds));
        }

        if (minPrice.HasValue)
        {
            filterDefinitions.Add(Builders<Product>.Filter.Gte("Price", minPrice.Value));
        }

        if (maxPrice.HasValue)
        {
            filterDefinitions.Add(Builders<Product>.Filter.Lte("Price", maxPrice.Value));
        }

        var filter = filterDefinitions.Any()
            ? Builders<Product>.Filter.And(filterDefinitions)
            : Builders<Product>.Filter.Empty;

        var query = _collection.Find(filter);

        if (sort == "price_asc")
        {
            query = query.SortBy(p => p.Price);
        }
        else if (sort == "price_desc")
        {
            query = query.SortByDescending(p => p.Price);
        }
        else if (sort == "name_asc")
        {
            query = query.SortBy(p => p.Name);
        }
        else if (sort == "name_desc")
        {
            query = query.SortByDescending(p => p.Name);
        }

        var products = await query.ToListAsync();
        return products.Select(MapToResultDTO).ToList();
    }

    public async Task<Dictionary<string, int>> GetCategoryProductCountsAsync()
    {
        var products = await _collection.AsQueryable().ToListAsync();
        return products
            .GroupBy(p => p.CategoryName)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    public async Task<ResultProductDTO?> GetByIdForDisplayAsync(string id)
    {
        var filter = Builders<Product>.Filter.Eq("Id", id);
        var product = await _collection.Find(filter).FirstOrDefaultAsync();
        return product != null ? MapToResultDTO(product) : null;
    }

    protected override Product MapToEntity(CreateProductDTO dto)
    {
        return new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Price = dto.Price,
            IsPopular = dto.IsPopular,
            CategoryName = dto.CategoryId
        };
    }

    protected override Product MapToEntity(UpdateProductDTO dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Price = dto.Price,
            IsPopular = dto.IsPopular,
            CategoryName = dto.CategoryId
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

    protected override string GetIdFromUpdateDTO(UpdateProductDTO dto)
    {
        return dto.Id;
    }
}
