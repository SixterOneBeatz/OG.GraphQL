using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Application.Common.Repositories;

namespace OG.GraphQL.Application.Features.Person.Queries
{
    public class GetPersonsQuery : IRequest<IQueryable<PersonDTO>>
    {
    }

    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, IQueryable<PersonDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IQueryable<PersonDTO>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
            => Task.FromResult(this._unitOfWork.PersonRepository.GetPersons().ProjectTo<PersonDTO>(this._mapper.ConfigurationProvider));
    }
}
