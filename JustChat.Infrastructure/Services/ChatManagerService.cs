using JustChat.Application.Interfaces;
using JustChat.Domain.Entities;

namespace JustChat.Infrastructure.Services
{
    public class ChatManagerService : IChatManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ChatRoom> _chatRoomRepository;

        public ChatManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _chatRoomRepository = _unitOfWork.GetRepository<ChatRoom>();
        }

        public async Task<IEnumerable<ChatRoom>> GetChatRoomsAsync()
        {
            return await _chatRoomRepository.GetAllAsync();
        }

        public async Task<object?> GetChatRoomAsync(int id)
        {
            return await _chatRoomRepository.GetByIdAsync(id);
        }

        public async Task CreateChatRoomAsync(ChatRoom chatRoomDto)
        {
            await _chatRoomRepository.AddAsync(chatRoomDto);
            _unitOfWork.Commit();
        }

        public async Task UpdateChatRoomAsync(ChatRoom chatRoomDto)
        {
            await _chatRoomRepository.UpdateAsync(chatRoomDto);
            _unitOfWork.Commit();
        }

        public async Task DeleteChatRoomAsync(int id)
        {
            var chatRoom = await _chatRoomRepository.GetByIdAsync(id);
            await _chatRoomRepository.DeleteAsync(chatRoom);
            _unitOfWork.Commit();
        }
    }
}
