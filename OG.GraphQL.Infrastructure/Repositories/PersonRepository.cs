using OG.GraphQL.Application.Common.Repositories;
using OG.GraphQL.Domain.Entities;
using OG.GraphQL.Infrastructure.Contexts;

namespace OG.GraphQL.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public PersonRepository(SchoolDbContext schoolDbContext)
            => this._schoolDbContext = schoolDbContext;

        public IQueryable<Person> GetPersons()
            => this._schoolDbContext.People;

    }
}
