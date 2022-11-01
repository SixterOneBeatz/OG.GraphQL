using AutoMapper;
using MediatR;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Application.Common.Repositories;

namespace OG.GraphQL.Application.Features.Person.Commands
{
    public class AddPersonCommand : IRequest<int>
    {
        public AddPersonCommand(PersonDTO person)
            => this.Person = person;
        public PersonDTO? Person { get; set; }
    }

    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.Entities.Person>(request.Person);
            this._unitOfWork.PersonRepository.AddPerson(person);
            await this._unitOfWork.Complete();

            return person.PersonId;
        }
    }
}
