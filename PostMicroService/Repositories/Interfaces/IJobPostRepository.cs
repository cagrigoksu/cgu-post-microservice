using PostMicroService.Models.Data;

namespace PostMicroService.Repositories.Interfaces
{
    public interface IJobPostRepository
    {
        (IQueryable<JobPostDataModel> jobPosts, int maxPage) GetAllJobPostsByPage(int pageNumber);

    }
}
