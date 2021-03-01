using Aspo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aspo.Contracts
{
    public interface IConversationRepository : IRepositoryBase<Conversation>
    {
        IQueryable<Conversation> FindAll(string userId, Expression<Func<Conversation, bool>>? predicate = null);
    }
}
