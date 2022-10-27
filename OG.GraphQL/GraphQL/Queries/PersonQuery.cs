using MediatR;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Application.Features.Person.Queries;

namespace OG.GraphQL.API.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class PersonQuery
    {
        public async Task<IQueryable<PersonDTO>> GetPersons([Service] IMediator mediator, CancellationToken cancellationToken)
            => await mediator.Send(new GetPersonsQuery(), cancellationToken);
    }
}
