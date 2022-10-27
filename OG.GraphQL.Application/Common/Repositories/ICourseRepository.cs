using OG.GraphQL.Domain.Entities;

namespace OG.GraphQL.Application.Common.Repositories
{
    public interface ICourseRepository
    {
        IQueryable<Course> GetCourses();
    }
}
