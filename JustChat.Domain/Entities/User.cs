namespace JustChat.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public ICollection<Message>? SentMessages { get; set; }

        public ICollection<Message>? ReceiveMessages { get; set; }

        public ICollection<ChatRoom>? JoinedChatRooms { get; set; }


    }
}
