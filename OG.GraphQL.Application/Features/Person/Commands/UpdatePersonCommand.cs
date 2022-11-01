using AutoMapper;
using MediatR;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Application.Common.Repositories;

namespace OG.GraphQL.Application.Features.Person.Commands
{
    public class UpdatePersonCommand : IRequest<int>
    {
        public UpdatePersonCommand(PersonDTO person)
            => this.Person = person;

        public PersonDTO? Person { get; set; }
    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await this._unitOfWork.PersonRepository.GetPerson(request.Person.PersonId);

            if (person == null)
                throw new ApplicationException("Not found");

            this._mapper.Map(request.Person, person);

            this._unitOfWork.PersonRepository.UpdatePerson(person);

            await this._unitOfWork.Complete();

            return person.PersonId;
        }
    }
}
