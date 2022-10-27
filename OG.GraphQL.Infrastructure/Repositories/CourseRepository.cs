using OG.GraphQL.Application.Common.Repositories;
using OG.GraphQL.Domain.Entities;
using OG.GraphQL.Infrastructure.Contexts;

namespace OG.GraphQL.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public CourseRepository(SchoolDbContext schoolDbContext)
            => this._schoolDbContext = schoolDbContext;

        public IQueryable<Course> GetCourses()
            => this._schoolDbContext.Courses;
    }
}
