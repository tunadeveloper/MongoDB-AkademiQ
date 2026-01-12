using MongoDB_AkademiQ.DTOs.AboutDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Abouts;

public interface IAboutService : IGenericService<About, CreateAboutDTO, UpdateAboutDTO, ResultAboutDTO>
{
}
