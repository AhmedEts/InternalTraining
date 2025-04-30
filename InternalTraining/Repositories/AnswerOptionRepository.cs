using InternalTraining.Repositories;
using InternalTraining.Data;
using InternalTraining.Models;

namespace InternalTraining.Repositories
{
    public class AnswerOptionRepository : Repository<AnswerOption>
    {
        public AnswerOptionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
