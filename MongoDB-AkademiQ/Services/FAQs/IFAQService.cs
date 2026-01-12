using MongoDB_AkademiQ.DTOs.FAQDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.FAQs;

public interface IFAQService : IGenericService<FAQ, CreateFAQDTO, UpdateFAQDTO, ResultFAQDTO>
{
}
