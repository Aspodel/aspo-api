using Aspo.Contracts;
using Aspo.Core.Database;
using Aspo.Core.Entities;

namespace Aspo.Repository
{
    public class ParticipantRepository:RepositoryBase<Participant>,IParticipantRepository
    {
        public ParticipantRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
