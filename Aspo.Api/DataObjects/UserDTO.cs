using Aspo.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aspo.Api.DataObjects
{
    public class UserDTO
    {
        public string ProfileUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        public Participant Participant { get; set; } = null;
        public virtual ICollection<Conversation> Conversations { get; set; } = Array.Empty<Conversation>();
    }
}
