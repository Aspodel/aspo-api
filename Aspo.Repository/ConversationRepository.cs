using Aspo.Contracts;
using Aspo.Core.Database;
using Aspo.Core.Entities;

namespace Aspo.Repository
{
    public class ConversationRepository : RepositoryBase<Conversation>, IConversationRepository
    {
        public ConversationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
