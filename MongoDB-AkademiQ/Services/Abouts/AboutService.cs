using MongoDB_AkademiQ.DTOs.AboutDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Abouts;

public class AboutService : GenericService<About, CreateAboutDTO, UpdateAboutDTO, ResultAboutDTO>, IAboutService
{
    public AboutService(IDatabaseSettings databaseSettings)
        : base(databaseSettings, databaseSettings.AboutCollection)
    {
    }

    protected override About MapToEntity(CreateAboutDTO createDTO)
    {
        return new About
        {
            Title = createDTO.Title,
            ShortDescription = createDTO.ShortDescription,
            StoryTitle = createDTO.StoryTitle,
            StoryDescription = createDTO.StoryDescription
        };
    }

    protected override About MapToEntity(UpdateAboutDTO updateDTO)
    {
        return new About
        {
            Id = updateDTO.Id,
            Title = updateDTO.Title,
            ShortDescription = updateDTO.ShortDescription,
            StoryTitle = updateDTO.StoryTitle,
            StoryDescription = updateDTO.StoryDescription
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

    protected override string GetIdFromUpdateDTO(UpdateAboutDTO updateDTO)
    {
        return updateDTO.Id;
    }
}
