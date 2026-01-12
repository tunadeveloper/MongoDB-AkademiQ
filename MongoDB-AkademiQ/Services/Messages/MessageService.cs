using MongoDB_AkademiQ.DTOs.MessageDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Messages;

public class MessageService : GenericService<Message, CreateMessageDTO, UpdateMessageDTO, ResultMessageDTO>, IMessageService
{
    public MessageService(IDatabaseSettings databaseSettings)
        : base(databaseSettings, databaseSettings.MessageCollection)
    {
    }

    protected override Message MapToEntity(CreateMessageDTO createDTO)
    {
        return new Message
        {
            Name = createDTO.Name,
            Surname = createDTO.Surname,
            Email = createDTO.Email,
            Subject = createDTO.Subject,
            Content = createDTO.Content,
            SendDate = DateTime.Now,
            IsRead = false
        };
    }

    protected override Message MapToEntity(UpdateMessageDTO updateDTO)
    {
        return new Message
        {
            Id = updateDTO.Id,
            Name = updateDTO.Name,
            Surname = updateDTO.Surname,
            Email = updateDTO.Email,
            Subject = updateDTO.Subject,
            Content = updateDTO.Content,
            SendDate = updateDTO.SendDate,
            IsRead = updateDTO.IsRead
        };
    }

    protected override ResultMessageDTO MapToResultDTO(Message entity)
    {
        return new ResultMessageDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Email = entity.Email,
            Subject = entity.Subject,
            Content = entity.Content,
            SendDate = entity.SendDate,
            IsRead = entity.IsRead
        };
    }

    protected override UpdateMessageDTO MapToUpdateDTO(Message entity)
    {
        return new UpdateMessageDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Email = entity.Email,
            Subject = entity.Subject,
            Content = entity.Content,
            SendDate = entity.SendDate,
            IsRead = entity.IsRead
        };
    }

    protected override string GetIdFromUpdateDTO(UpdateMessageDTO updateDTO)
    {
        return updateDTO.Id;
    }
}
