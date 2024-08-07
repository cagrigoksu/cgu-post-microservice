using PostMicroService.Models.Data;
using PostMicroService.Repositories.Interfaces;
using PostMicroService.Services.Interfaces;

namespace PostMicroService.Services
{
    public class JobPostService: IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostService(IJobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
        }
        public (IQueryable<JobPostDataModel> jobPosts, int maxPage) GetAllJobPostsByPage(int pageNumber)
        {
            var data = _jobPostRepository.GetAllJobPostsByPage(pageNumber);
            return data;
        }
    }
}
