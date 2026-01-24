using MongoDB_AkademiQ.DTOs.AboutDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Abouts;

public class AboutService : GenericService<About, CreateAboutDTO, UpdateAboutDTO, ResultAboutDTO>, IAboutService
{
    public AboutService(IDatabaseSettings settings) : base(settings, settings.AboutCollection)
    {
    }

    protected override About MapToEntity(CreateAboutDTO dto)
    {
        return new About
        {
            Title = dto.Title,
            ShortDescription = dto.ShortDescription,
            StoryTitle = dto.StoryTitle,
            StoryDescription = dto.StoryDescription
        };
    }

    protected override About MapToEntity(UpdateAboutDTO dto)
    {
        return new About
        {
            Id = dto.Id,
            Title = dto.Title,
            ShortDescription = dto.ShortDescription,
            StoryTitle = dto.StoryTitle,
            StoryDescription = dto.StoryDescription
        };
    }

    protected override ResultAboutDTO MapToResultDTO(About entity)
    {
        return new ResultAboutDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            ShortDescription = entity.ShortDescription,
            StoryTitle = entity.StoryTitle,
            StoryDescription = entity.StoryDescription
        };
    }

    protected override UpdateAboutDTO MapToUpdateDTO(About entity)
    {
        return new UpdateAboutDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            ShortDescription = entity.ShortDescription,
            StoryTitle = entity.StoryTitle,
            StoryDescription = entity.StoryDescription
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateAboutDTO dto)
    {
        return dto.Id;
    }
}
