using Aspo.Contracts;
using Aspo.Core.Database;
using Aspo.Core.Entities;

namespace Aspo.Repository
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
