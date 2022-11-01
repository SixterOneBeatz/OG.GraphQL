namespace OG.GraphQL.Application.Common.Repositories
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IPersonRepository PersonRepository { get; }
        Task<int> Complete();
    }
}
