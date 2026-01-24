using MongoDB_AkademiQ.DTOs.MessageDTOs;
using MongoDB_AkademiQ.Entities;
using MongoDB_AkademiQ.Services.Generic;

namespace MongoDB_AkademiQ.Services.Messages;

public interface IMessageService : IGenericService<Message, CreateMessageDTO, UpdateMessageDTO, ResultMessageDTO>
{
    Task MarkAsReadAsync(string id);
}
