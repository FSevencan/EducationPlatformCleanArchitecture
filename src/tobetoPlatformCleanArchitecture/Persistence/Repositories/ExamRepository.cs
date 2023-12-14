using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExamRepository : EfRepositoryBase<Exam, Guid, BaseDbContext>, IExamRepository
{
    public ExamRepository(BaseDbContext context) : base(context)
    {
    }
}