using System;

namespace Aspo.Core.Entities
{
    public class Message : BaseEntity
    {
        public int ConversationId { get; set; }
        public string SenderId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public MessageTypes Type { get; set; }
        public string Content { get; set; }


        public virtual Conversation Conversation { get; set; }
        public virtual ApplicationUser Sender { get; set; }

    }

    public enum MessageTypes
    {
        Text,
        Image,
        File
    }
}
