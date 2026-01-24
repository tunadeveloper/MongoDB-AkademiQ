using MongoDB_AkademiQ.DTOs.ContactInfoDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.ContactInfos;

public class ContactInfoService : GenericService<ContactInfo, CreateContactInfoDTO, UpdateContactInfoDTO, ResultContactInfoDTO>, IContactInfoService
{
    public ContactInfoService(IDatabaseSettings settings) : base(settings, settings.ContactInfoCollection)
    {
    }

    protected override ContactInfo MapToEntity(CreateContactInfoDTO dto)
    {
        return new ContactInfo
        {
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email
        };
    }

    protected override ContactInfo MapToEntity(UpdateContactInfoDTO dto)
    {
        return new ContactInfo
        {
            Id = dto.Id,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email
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

    protected override string GetIdFromUpdateDTO(UpdateContactInfoDTO dto)
    {
        return dto.Id;
    }
}
