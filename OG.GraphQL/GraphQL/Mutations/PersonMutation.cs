using MediatR;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Application.Features.Person.Commands;

namespace OG.GraphQL.API.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class PersonMutation
    {
        public async Task<int> AddPerson([Service] IMediator mediator, CancellationToken cancellationToken, PersonDTO input)
            => await mediator.Send(new AddPersonCommand(input), cancellationToken);

        public async Task<int> UpdatePerson([Service] IMediator mediator, CancellationToken cancellationToken, PersonDTO input)
            => await mediator.Send(new UpdatePersonCommand(input), cancellationToken);

        public async Task<int> DeletePerson([Service] IMediator mediator, CancellationToken cancellationToken, int input)
            => await mediator.Send(new DeletePersonCommand(input), cancellationToken);
    }
}
