using System;

namespace Aspo.Core.Entities
{
    public class Participant : BaseEntity
    {
        public string UserId { get; set; }
        public int ConversationId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ApplicationUser User { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
