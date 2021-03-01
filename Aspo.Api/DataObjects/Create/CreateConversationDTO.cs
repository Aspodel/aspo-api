using Aspo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspo.Api.DataObjects.Create
{
    public class CreateConversationDTO
    {
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public ConversationTypes Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Participant> Participants { get; set; } = Array.Empty<Participant>();
    }
}
