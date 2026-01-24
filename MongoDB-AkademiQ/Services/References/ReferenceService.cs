using MongoDB_AkademiQ.DTOs.ReferenceDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.References;

public class ReferenceService : GenericService<Reference, CreateReferenceDTO, UpdateReferenceDTO, ResultReferenceDTO>, IReferenceService
{
    public ReferenceService(IDatabaseSettings settings) : base(settings, settings.ReferenceCollection)
    {
    }

    protected override Reference MapToEntity(CreateReferenceDTO dto)
    {
        return new Reference
        {
            CompanyName = dto.CompanyName,
            LogoUrl = dto.LogoUrl,
            Description = dto.Description
        };
    }

    protected override Reference MapToEntity(UpdateReferenceDTO dto)
    {
        return new Reference
        {
            Id = dto.Id,
            CompanyName = dto.CompanyName,
            LogoUrl = dto.LogoUrl,
            Description = dto.Description
        };
    }

    protected override ResultReferenceDTO MapToResultDTO(Reference entity)
    {
        return new ResultReferenceDTO
        {
            Id = entity.Id,
            CompanyName = entity.CompanyName,
            LogoUrl = entity.LogoUrl,
            Description = entity.Description
        };
    }

    protected override UpdateReferenceDTO MapToUpdateDTO(Reference entity)
    {
        return new UpdateReferenceDTO
        {
            Id = entity.Id,
            CompanyName = entity.CompanyName,
            LogoUrl = entity.LogoUrl,
            Description = entity.Description
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateReferenceDTO dto)
    {
        return dto.Id;
    }
}
