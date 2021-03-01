using Aspo.Core.Entities;
using System;
using System.Collections.Generic;

namespace Aspo.Api.DataObjects
{
    public class ConversationDTO
    {
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public ConversationTypes Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = Array.Empty<Message>();
        public virtual ICollection<Participant> Participants { get; set; } = Array.Empty<Participant>();
    }
}
