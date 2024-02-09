using JustChat.Domain.Entities;

namespace JustChat.Application.Interfaces
{
    public interface IChatManagerService
    {
        Task<IEnumerable<ChatRoom>> GetChatRoomsAsync();
        Task<object?> GetChatRoomAsync(int id);
        Task CreateChatRoomAsync(ChatRoom chatRoomDto);
        Task UpdateChatRoomAsync(ChatRoom chatRoomDto);
        Task DeleteChatRoomAsync(int id);
    }
}
