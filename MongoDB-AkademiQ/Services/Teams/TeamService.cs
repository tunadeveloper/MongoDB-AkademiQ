using MongoDB_AkademiQ.DTOs.TeamDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Teams;

public class TeamService : GenericService<Team, CreateTeamDTO, UpdateTeamDTO, ResultTeamDTO>, ITeamService
{
    public TeamService(IDatabaseSettings databaseSettings)
        : base(databaseSettings, databaseSettings.TeamCollection)
    {
    }

    protected override Team MapToEntity(CreateTeamDTO createDTO)
    {
        return new Team
        {
            NameSurname = createDTO.NameSurname,
            PositionName = createDTO.PositionName,
            ImageUrl = createDTO.ImageUrl
        };
    }

    protected override Team MapToEntity(UpdateTeamDTO updateDTO)
    {
        return new Team
        {
            Id = updateDTO.Id,
            NameSurname = updateDTO.NameSurname,
            PositionName = updateDTO.PositionName,
            ImageUrl = updateDTO.ImageUrl
        };
    }

    protected override ResultTeamDTO MapToResultDTO(Team entity)
    {
        return new ResultTeamDTO
        {
            Id = entity.Id,
            NameSurname = entity.NameSurname,
            PositionName = entity.PositionName,
            ImageUrl = entity.ImageUrl
        };
    }

    protected override UpdateTeamDTO MapToUpdateDTO(Team entity)
    {
        return new UpdateTeamDTO
        {
            Id = entity.Id,
            NameSurname = entity.NameSurname,
            PositionName = entity.PositionName,
            ImageUrl = entity.ImageUrl
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateTeamDTO updateDTO)
    {
        return updateDTO.Id;
    }
}
