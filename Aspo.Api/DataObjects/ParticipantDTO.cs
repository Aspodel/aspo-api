using System;

namespace Aspo.Api.DataObjects
{
    public class ParticipantDTO
    {
        public string UserId { get; set; }
        public int ConversationId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
