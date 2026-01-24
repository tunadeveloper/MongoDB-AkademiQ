using MongoDB_AkademiQ.DTOs.AdminDTOs;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Admin
{
    public interface IAdminService : IGenericService<Entities.Admin, CreateAdminDTO, UpdateAdminDTO, ResultAdminDTO>
    {
        Task<ResultAdminDTO?> GetByUsernameAsync(string username);
        Task<ResultAdminDTO?> ValidateAdminAsync(string username, string password);
    }
}
