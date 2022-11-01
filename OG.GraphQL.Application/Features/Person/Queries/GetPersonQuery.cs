using AutoMapper;
using MediatR;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Application.Common.Repositories;

namespace OG.GraphQL.Application.Features.Person.Queries
{
    public class GetPersonQuery : IRequest<PersonDTO>
    {
        public GetPersonQuery(int id)
            => this.Id = id;

        public int Id { get; set; }
    }

    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PersonDTO> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await this._unitOfWork.PersonRepository.GetPerson(request.Id);

            if (person == null)
                throw new ApplicationException("Not found");

            return this._mapper.Map<PersonDTO>(person);
        }
    }
}
