using MongoDB_AkademiQ.DTOs.TeamDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Teams;

public class TeamService : GenericService<Team, CreateTeamDTO, UpdateTeamDTO, ResultTeamDTO>, ITeamService
{
    public TeamService(IDatabaseSettings settings) : base(settings, settings.TeamCollection)
    {
    }

    protected override Team MapToEntity(CreateTeamDTO dto)
    {
        return new Team
        {
            NameSurname = dto.NameSurname,
            PositionName = dto.PositionName,
            ImageUrl = dto.ImageUrl
        };
    }

    protected override Team MapToEntity(UpdateTeamDTO dto)
    {
        return new Team
        {
            Id = dto.Id,
            NameSurname = dto.NameSurname,
            PositionName = dto.PositionName,
            ImageUrl = dto.ImageUrl
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

    protected override string GetIdFromUpdateDTO(UpdateTeamDTO dto)
    {
        return dto.Id;
    }
}
