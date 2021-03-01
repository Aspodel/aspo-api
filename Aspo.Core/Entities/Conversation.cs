using System;
using System.Collections.Generic;

namespace Aspo.Core.Entities
{
    public class Conversation : BaseEntity
    {
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public ConversationTypes Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ApplicationUser Creator { get; set; }
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public virtual ICollection<Participant> Participants { get; set; } = new HashSet<Participant>();
    }

    public enum ConversationTypes
    {
        Single,
        Group
    }
}
