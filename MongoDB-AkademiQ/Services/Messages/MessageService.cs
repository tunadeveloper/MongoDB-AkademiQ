using MongoDB.Driver;
using MongoDB_AkademiQ.DTOs.MessageDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;
using MongoDB_AkademiQ.Settings;

namespace MongoDB_AkademiQ.Services.Messages;

public class MessageService : GenericService<Message, CreateMessageDTO, UpdateMessageDTO, ResultMessageDTO>, IMessageService
{
    public MessageService(IDatabaseSettings settings) : base(settings, settings.MessageCollection)
    {
    }

    public async Task MarkAsReadAsync(string id)
    {
        var filter = Builders<Message>.Filter.Eq("Id", id);
        var update = Builders<Message>.Update.Set("IsRead", true);
        await _collection.UpdateOneAsync(filter, update);
    }

    protected override Message MapToEntity(CreateMessageDTO dto)
    {
        return new Message
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            Subject = dto.Subject,
            Content = dto.Content,
            SendDate = DateTime.Now,
            IsRead = false
        };
    }

    protected override Message MapToEntity(UpdateMessageDTO dto)
    {
        return new Message
        {
            Id = dto.Id,
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            Subject = dto.Subject,
            Content = dto.Content,
            SendDate = dto.SendDate,
            IsRead = dto.IsRead
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

    protected override string GetIdFromUpdateDTO(UpdateMessageDTO dto)
    {
        return dto.Id;
    }
}
