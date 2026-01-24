using MongoDB_AkademiQ.DTOs.NewsletterDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Newsletters;

public class NewsletterService : GenericService<Newsletter, CreateNewsletterDTO, UpdateNewsletterDTO, ResultNewsletterDTO>, INewsletterService
{
    public NewsletterService(IDatabaseSettings settings) : base(settings, settings.NewsletterCollection)
    {
    }

    protected override Newsletter MapToEntity(CreateNewsletterDTO dto)
    {
        return new Newsletter
        {
            Email = dto.Email
        };
    }

    protected override Newsletter MapToEntity(UpdateNewsletterDTO dto)
    {
        return new Newsletter
        {
            Id = dto.Id,
            Email = dto.Email
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

    protected override string GetIdFromUpdateDTO(UpdateNewsletterDTO dto)
    {
        return dto.Id;
    }
}
