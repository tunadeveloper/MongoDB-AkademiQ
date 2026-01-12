using MongoDB_AkademiQ.DTOs.TeamDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Teams;

public interface ITeamService : IGenericService<Team, CreateTeamDTO, UpdateTeamDTO, ResultTeamDTO>
{
}
