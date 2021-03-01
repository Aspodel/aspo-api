using Aspo.Core.Entities;
using System;

namespace Aspo.Api.DataObjects
{
    public class MessageDTO
    {
        public int ConversationId { get; set; }
        public string SenderId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public MessageTypes Type { get; set; }
        public string Content { get; set; }
    }
}
