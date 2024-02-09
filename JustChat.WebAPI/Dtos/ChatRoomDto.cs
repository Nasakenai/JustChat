namespace JustChat.WebAPI.Dtos
{
    public class ChatRoomDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public int Attendance { get; set; } = 0;

    }
}
