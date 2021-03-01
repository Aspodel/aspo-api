using Aspo.Contracts;
using Aspo.Core.Database;
using Aspo.Core.Entities;
using Aspo.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Aspo.Repository
{
    public class ConversationRepository : RepositoryBase<Conversation>, IConversationRepository
    {
        public ConversationRepository(ApplicationDbContext context) : base(context) { }

        public override IQueryable<Conversation> FindAll(Expression<Func<Conversation, bool>>? predicate = null)
            => _dbSet
                .WhereIf(predicate != null, predicate!)
                .Include(x => x.Messages!)
                .Include(x => x.Participants)
                    .ThenInclude(y => y.User);

        public IQueryable<Conversation> FindAll(string userId, Expression<Func<Conversation,bool>>? predicate=null)
            => FindAll(predicate)
                .Where(x => x.CreatorId == userId);

        public override async Task<Conversation?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
            => await FindAll(b => b.Id == id)
                .Include(x => x.Messages)
                .Include(x => x.Participants)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
