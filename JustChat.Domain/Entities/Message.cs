namespace JustChat.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ChatRoomId { get; set; }


        public string Content { get; set; } = string.Empty;

        public DateTime Timestamped { get; set; }


        public User Sender { get; set; }

        public ChatRoom ChatRoom { get; set; }

    }
}
