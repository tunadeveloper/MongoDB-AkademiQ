using MongoDB_AkademiQ.DTOs.NewsletterDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Newsletters;

public class NewsletterService : GenericService<Newsletter, CreateNewsletterDTO, UpdateNewsletterDTO, ResultNewsletterDTO>, INewsletterService
{
    public NewsletterService(IDatabaseSettings databaseSettings) 
        : base(databaseSettings, databaseSettings.NewsletterCollection)
    {
    }

    protected override Newsletter MapToEntity(CreateNewsletterDTO createDTO)
    {
        return new Newsletter
        {
            Email = createDTO.Email
        };
    }

    protected override Newsletter MapToEntity(UpdateNewsletterDTO updateDTO)
    {
        return new Newsletter
        {
            Id = updateDTO.Id,
            Email = updateDTO.Email
        };
    }

    protected override ResultNewsletterDTO MapToResultDTO(Newsletter entity)
    {
        return new ResultNewsletterDTO
        {
            Id = entity.Id,
            Email = entity.Email
        };
    }

    protected override UpdateNewsletterDTO MapToUpdateDTO(Newsletter entity)
    {
        return new UpdateNewsletterDTO
        {
            Id = entity.Id,
            Email = entity.Email
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateNewsletterDTO updateDTO)
    {
        return updateDTO.Id;
    }
}
