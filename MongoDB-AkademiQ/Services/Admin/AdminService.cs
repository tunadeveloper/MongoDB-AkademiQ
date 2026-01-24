using MongoDB.Driver;
using MongoDB_AkademiQ.DTOs.AdminDTOs;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Admin
{
    public class AdminService : GenericService<Entities.Admin, CreateAdminDTO, UpdateAdminDTO, ResultAdminDTO>, IAdminService
    {
        private readonly IMongoCollection<Entities.Admin> _adminCollection;

        public AdminService(IDatabaseSettings databaseSettings)
            : base(databaseSettings, databaseSettings.AdminCollection)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _adminCollection = database.GetCollection<Entities.Admin>(databaseSettings.AdminCollection);
        }

        public async Task<ResultAdminDTO?> GetByUsernameAsync(string username)
        {
            var admin = await _adminCollection.Find(x => x.Username == username).FirstOrDefaultAsync();
            if (admin == null) return null;

            return MapToResultDTO(admin);
        }

        public async Task<ResultAdminDTO?> ValidateAdminAsync(string username, string password)
        {
            // Not: Gerçek uygulamalarda şifre hashlenmeli (BCrypt, Argon2, vb.)
            var admin = await _adminCollection.Find(x => x.Username == username && x.Password == password && x.IsVerified).FirstOrDefaultAsync();
            if (admin == null) return null;

            return MapToResultDTO(admin);
        }

        protected override Entities.Admin MapToEntity(CreateAdminDTO dto)
        {
            return new Entities.Admin
            {
                NameSurname = dto.NameSurname,
                Username = dto.Username,
                Password = dto.Password, // Şifre hashlenmelidir!
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
                Password = dto.Password, // Şifre hashlenmelidir!
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
                Password = entity.Password, // Gerçek uygulamalarda şifreyi döndürmeyin!
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

        protected override string GetIdFromUpdateDTO(UpdateAdminDTO updateDTO)
        {
            return updateDTO.Id;
        }
    }
}
