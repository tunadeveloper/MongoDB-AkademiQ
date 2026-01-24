using MongoDB_AkademiQ.DTOs.NewsletterDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Newsletters;

public interface INewsletterService : IGenericService<Newsletter, CreateNewsletterDTO, UpdateNewsletterDTO, ResultNewsletterDTO>
{
}
