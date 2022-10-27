using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Application.Common.Repositories;

namespace OG.GraphQL.Application.Features.Course.Queries
{
    public class GetCoursesQuery : IRequest<IQueryable<CourseDTO>>
    {
    }

    public class GetCoursesQueryHanlder : IRequestHandler<GetCoursesQuery, IQueryable<CourseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoursesQueryHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public Task<IQueryable<CourseDTO>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
            => Task.FromResult(this._unitOfWork.CourseRepository.GetCourses().ProjectTo<CourseDTO>(this._mapper.ConfigurationProvider));
    }
}
