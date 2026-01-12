using MongoDB_AkademiQ.DTOs.FAQDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.FAQs;

public class FAQService : GenericService<FAQ, CreateFAQDTO, UpdateFAQDTO, ResultFAQDTO>, IFAQService
{
    public FAQService(IDatabaseSettings databaseSettings)
        : base(databaseSettings, databaseSettings.FAQCollection)
    {
    }

    protected override FAQ MapToEntity(CreateFAQDTO createDTO)
    {
        return new FAQ
        {
            Question = createDTO.Question,
            Answer = createDTO.Answer
        };
    }

    protected override FAQ MapToEntity(UpdateFAQDTO updateDTO)
    {
        return new FAQ
        {
            Id = updateDTO.Id,
            Question = updateDTO.Question,
            Answer = updateDTO.Answer
        };
    }

    protected override ResultFAQDTO MapToResultDTO(FAQ entity)
    {
        return new ResultFAQDTO
        {
            Id = entity.Id,
            Question = entity.Question,
            Answer = entity.Answer
        };
    }

    protected override UpdateFAQDTO MapToUpdateDTO(FAQ entity)
    {
        return new UpdateFAQDTO
        {
            Id = entity.Id,
            Question = entity.Question,
            Answer = entity.Answer
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateFAQDTO updateDTO)
    {
        return updateDTO.Id;
    }
}
