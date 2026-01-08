namespace MongoDB_AkademiQ.Services.Generic;

public interface IGenericService<TEntity, TCreateDTO, TUpdateDTO, TResultDTO>
    where TEntity : class
{
    Task<List<TResultDTO>> GetAllAsync();
    Task<TUpdateDTO> GetByIdAsync(string id);
    Task CreateAsync(TCreateDTO createDTO);
    Task UpdateAsync(TUpdateDTO updateDTO);
    Task DeleteAsync(string id);
}
