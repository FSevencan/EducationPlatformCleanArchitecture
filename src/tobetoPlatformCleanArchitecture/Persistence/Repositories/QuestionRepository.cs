using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class QuestionRepository : EfRepositoryBase<Question, Guid, BaseDbContext>, IQuestionRepository
{
    public QuestionRepository(BaseDbContext context) : base(context)
    {
    }
}