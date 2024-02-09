using AutoMapper;
using JustChat.Application.Interfaces;
using JustChat.Domain.Entities;
using JustChat.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace JustChat.WebAPI.Controllers
{
    public class ChatManagerController : ControllerBase
    {
        private readonly IChatManagerService _chatManagerService;
        private readonly IMapper _mapper;
        private readonly ILogger<ChatManagerController> _logger;

        public ChatManagerController(IChatManagerService chatManagerService, IMapper mapper, ILogger<ChatManagerController> logger)
        {
            _chatManagerService = chatManagerService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "GetChatRooms")]
        public async Task<IActionResult> GetChatRooms()
        {
            var chatRooms = await _chatManagerService.GetChatRoomsAsync();
            return Ok(chatRooms);
        }

        [HttpGet("{id}", Name = "GetChatRoom")]
        public async Task<IActionResult> GetChatRoom(int id)
        {
            var chatRoom = await _chatManagerService.GetChatRoomAsync(id);
            return Ok(chatRoom);
        }

        [HttpPost(Name = "CreateChatRoom")]
        public async Task<IActionResult> CreateChatRoom([FromBody] ChatRoomDto chatRoomDto)
        {
            var chatRoom = _mapper.Map<ChatRoom>(chatRoomDto);
            await _chatManagerService.CreateChatRoomAsync(chatRoom);
            return Ok();
        }

        [HttpPut(Name = "UpdateChatRoom")]
        public async Task<IActionResult> UpdateChatRoom([FromBody] ChatRoomDto chatRoomDto)
        {
            var chatRoom = _mapper.Map<ChatRoom>(chatRoomDto);
            await _chatManagerService.UpdateChatRoomAsync(chatRoom);
            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteChatRoom")]
        public async Task<IActionResult> DeleteChatRoom(int id)
        {
            await _chatManagerService.DeleteChatRoomAsync(id);
            return Ok();
        }
    }
}
