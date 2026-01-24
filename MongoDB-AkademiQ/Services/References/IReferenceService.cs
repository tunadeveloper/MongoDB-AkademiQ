using MongoDB_AkademiQ.DTOs.ReferenceDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.References;

public interface IReferenceService : IGenericService<Reference, CreateReferenceDTO, UpdateReferenceDTO, ResultReferenceDTO>
{
}
