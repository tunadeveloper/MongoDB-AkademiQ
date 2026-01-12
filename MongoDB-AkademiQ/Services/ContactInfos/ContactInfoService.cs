using MongoDB_AkademiQ.DTOs.ContactInfoDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.ContactInfos;

public class ContactInfoService : GenericService<ContactInfo, CreateContactInfoDTO, UpdateContactInfoDTO, ResultContactInfoDTO>, IContactInfoService
{
    public ContactInfoService(IDatabaseSettings databaseSettings)
        : base(databaseSettings, databaseSettings.ContactInfoCollection)
    {
    }

    protected override ContactInfo MapToEntity(CreateContactInfoDTO createDTO)
    {
        return new ContactInfo
        {
            Address = createDTO.Address,
            PhoneNumber = createDTO.PhoneNumber,
            Email = createDTO.Email
        };
    }

    protected override ContactInfo MapToEntity(UpdateContactInfoDTO updateDTO)
    {
        return new ContactInfo
        {
            Id = updateDTO.Id,
            Address = updateDTO.Address,
            PhoneNumber = updateDTO.PhoneNumber,
            Email = updateDTO.Email
        };
    }

    protected override ResultContactInfoDTO MapToResultDTO(ContactInfo entity)
    {
        return new ResultContactInfoDTO
        {
            Id = entity.Id,
            Address = entity.Address,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email
        };
    }

    protected override UpdateContactInfoDTO MapToUpdateDTO(ContactInfo entity)
    {
        return new UpdateContactInfoDTO
        {
            Id = entity.Id,
            Address = entity.Address,
            PhoneNumber = entity.PhoneNumber,
            Email = entity.Email
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateContactInfoDTO updateDTO)
    {
        return updateDTO.Id;
    }
}
