using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB_AkademiQ.DTOs.CategoryDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _mongoCollection;

    public CategoryService(IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _mongoCollection = database.GetCollection<Category>(databaseSettings.CategoryCollection);
    }

    public async Task CreateAsync(CreateCategoryDTO createCategoryDTO)
    {
        var category = new Category
        {
            Name = createCategoryDTO.Name
        };

        await _mongoCollection.InsertOneAsync(category);
    }

    public async Task DeleteAsync(string id)
    {
        await _mongoCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultCategoryDTO>> GetAllAsync()
    {
        var categories = await _mongoCollection.AsQueryable().ToListAsync();
        return categories.Select(c => new ResultCategoryDTO
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }

    public async Task<UpdateCategoryDTO> GetByIdAsync(string id)
    {
        var category = await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        return new UpdateCategoryDTO
        {
            Id = category.Id,
            Name = category.Name
        };
    }


    public async Task UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
    {
        var category = new Category
        {
            Id = updateCategoryDTO.Id,
            Name = updateCategoryDTO.Name
        };

        await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == category.Id, category);
    }
}