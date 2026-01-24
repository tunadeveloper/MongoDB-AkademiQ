using MongoDB_AkademiQ.DTOs.FAQDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.FAQs;

public class FAQService : GenericService<FAQ, CreateFAQDTO, UpdateFAQDTO, ResultFAQDTO>, IFAQService
{
    public FAQService(IDatabaseSettings settings) : base(settings, settings.FAQCollection)
    {
    }

    protected override FAQ MapToEntity(CreateFAQDTO dto)
    {
        return new FAQ
        {
            Question = dto.Question,
            Answer = dto.Answer
        };
    }

    protected override FAQ MapToEntity(UpdateFAQDTO dto)
    {
        return new FAQ
        {
            Id = dto.Id,
            Question = dto.Question,
            Answer = dto.Answer
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

    protected override string GetIdFromUpdateDTO(UpdateFAQDTO dto)
    {
        return dto.Id;
    }
}
