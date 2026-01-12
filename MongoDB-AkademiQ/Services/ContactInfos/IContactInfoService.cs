using MongoDB_AkademiQ.DTOs.ContactInfoDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.ContactInfos;

public interface IContactInfoService : IGenericService<ContactInfo, CreateContactInfoDTO, UpdateContactInfoDTO, ResultContactInfoDTO>
{
}
