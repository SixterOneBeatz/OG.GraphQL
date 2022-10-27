using OG.GraphQL.Domain.Entities;

namespace OG.GraphQL.Application.Common.Repositories
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetPersons();
    }
}
