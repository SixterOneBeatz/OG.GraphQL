using AutoMapper;
using MediatR;
using OG.GraphQL.Application.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OG.GraphQL.Application.Features.Person.Commands
{
    public class DeletePersonCommand :IRequest<int>
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await this._unitOfWork.PersonRepository.GetPerson(request.Id);

            if (person == null)
                throw new ApplicationException("Not found");

            this._unitOfWork.PersonRepository.DeletePerson(person);

            await this._unitOfWork.Complete();

            return request.Id;
        }
    }
}

