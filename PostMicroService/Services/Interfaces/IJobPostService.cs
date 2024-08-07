using PostMicroService.Models.Data;

namespace PostMicroService.Services.Interfaces
{
    public interface IJobPostService
    {
        (IQueryable<JobPostDataModel> jobPosts, int maxPage) GetAllJobPostsByPage(int pageNumber);

    }
}
