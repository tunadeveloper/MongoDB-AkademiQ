using MongoDB.Driver;
using MongoDB_AkademiQ.DTOs.AdminDTOs;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Admin;

public class AdminService : GenericService<Entities.Admin, CreateAdminDTO, UpdateAdminDTO, ResultAdminDTO>, IAdminService
{
    public AdminService(IDatabaseSettings settings) : base(settings, settings.AdminCollection)
    {
    }

    public async Task<ResultAdminDTO?> GetByUsernameAsync(string username)
    {
        var filter = Builders<Entities.Admin>.Filter.Eq(a => a.Username, username);
        var admin = await _collection.Find(filter).FirstOrDefaultAsync();
        return admin != null ? MapToResultDTO(admin) : null;
    }

    public async Task<ResultAdminDTO?> ValidateAsync(string username, string password)
    {
        var filter = Builders<Entities.Admin>.Filter.And(
            Builders<Entities.Admin>.Filter.Eq(a => a.Username, username),
            Builders<Entities.Admin>.Filter.Eq(a => a.Password, password),
            Builders<Entities.Admin>.Filter.Eq(a => a.IsVerified, true)
        );

        var admin = await _collection.Find(filter).FirstOrDefaultAsync();
        return admin != null ? MapToResultDTO(admin) : null;
    }

    protected override Entities.Admin MapToEntity(CreateAdminDTO dto)
    {
        return new Entities.Admin
        {
            NameSurname = dto.NameSurname,
            Username = dto.Username,
            Password = dto.Password,
            IsVerified = dto.IsVerified
        };
    }

    protected override Entities.Admin MapToEntity(UpdateAdminDTO dto)
    {
        return new Entities.Admin
        {
            Id = dto.Id,
            NameSurname = dto.NameSurname,
            Username = dto.Username,
            Password = dto.Password,
            IsVerified = dto.IsVerified
        };
    }

    protected override ResultAdminDTO MapToResultDTO(Entities.Admin entity)
    {
        return new ResultAdminDTO
        {
            Id = entity.Id,
            NameSurname = entity.NameSurname,
            Username = entity.Username,
            Password = entity.Password,
            IsVerified = entity.IsVerified
        };
    }

    protected override UpdateAdminDTO MapToUpdateDTO(Entities.Admin entity)
    {
        return new UpdateAdminDTO
        {
            Id = entity.Id,
            NameSurname = entity.NameSurname,
            Username = entity.Username,
            Password = entity.Password,
            IsVerified = entity.IsVerified
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateAdminDTO dto)
    {
        return dto.Id;
    }
}
