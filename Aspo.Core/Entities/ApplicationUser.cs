using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace Aspo.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfileUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Participant Participant { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; } = new HashSet<Conversation>();
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
