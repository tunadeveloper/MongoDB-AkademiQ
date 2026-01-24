using MongoDB_AkademiQ.DTOs.AdminDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Admin;

public interface IAdminService : IGenericService<Entities.Admin, CreateAdminDTO, UpdateAdminDTO, ResultAdminDTO>
{
    Task<ResultAdminDTO?> GetByUsernameAsync(string username);
    Task<ResultAdminDTO?> ValidateAsync(string username, string password);
}
