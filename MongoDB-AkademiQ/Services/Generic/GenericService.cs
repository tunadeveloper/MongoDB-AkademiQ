using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Generic;

public abstract class GenericService<TEntity, TCreateDTO, TUpdateDTO, TResultDTO> : IGenericService<TEntity, TCreateDTO, TUpdateDTO, TResultDTO>
    where TEntity : class
{
    protected readonly IMongoCollection<TEntity> _collection;

    protected GenericService(IDatabaseSettings settings, string collectionName)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<TEntity>(collectionName);
    }

    public virtual async Task<List<TResultDTO>> GetAllAsync()
    {
        var entities = await _collection.AsQueryable().ToListAsync();
        return entities.Select(MapToResultDTO).ToList();
    }

    public virtual async Task<TUpdateDTO> GetByIdAsync(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq("Id", id);
        var entity = await _collection.Find(filter).FirstOrDefaultAsync();
        return MapToUpdateDTO(entity);
    }

    public virtual async Task CreateAsync(TCreateDTO dto)
    {
        var entity = MapToEntity(dto);
        await _collection.InsertOneAsync(entity);
    }

    public virtual async Task UpdateAsync(TUpdateDTO dto)
    {
        var entity = MapToEntity(dto);
        var id = GetIdFromUpdateDTO(dto);
        var filter = Builders<TEntity>.Filter.Eq("Id", id);
        await _collection.FindOneAndReplaceAsync(filter, entity);
    }

    public virtual async Task DeleteAsync(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq("Id", id);
        await _collection.DeleteOneAsync(filter);
    }

    protected abstract TEntity MapToEntity(TCreateDTO dto);
    protected abstract TEntity MapToEntity(TUpdateDTO dto);
    protected abstract TResultDTO MapToResultDTO(TEntity entity);
    protected abstract TUpdateDTO MapToUpdateDTO(TEntity entity);
    protected abstract string GetIdFromUpdateDTO(TUpdateDTO dto);
}
