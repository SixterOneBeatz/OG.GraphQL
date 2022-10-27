using OG.GraphQL.Application.Common.Repositories;
using OG.GraphQL.Infrastructure.Contexts;

namespace OG.GraphQL.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _schoolDbContext;

        public UnitOfWork(SchoolDbContext schoolDbContext)
            => _schoolDbContext = schoolDbContext;

        public ICourseRepository CourseRepository => new CourseRepository(this._schoolDbContext);

        public IPersonRepository PersonRepository => new PersonRepository(this._schoolDbContext);
    }
}
