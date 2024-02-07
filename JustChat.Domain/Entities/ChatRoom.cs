namespace JustChat.Domain.Entities
{
    public class ChatRoom
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Attendance { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }
}
