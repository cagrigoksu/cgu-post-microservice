using PostMicroService.Models.Data;
using PostMicroService.Repositories.Interfaces;

namespace PostMicroService.Repositories
{
    public class JobPostRepository: IJobPostRepository
    {
        private readonly AppDbContext _db;
        public JobPostRepository(AppDbContext db)
        {
            _db = db;
        }

        public (IQueryable<JobPostDataModel> jobPosts, int maxPage) GetAllJobPostsByPage(int pageNumber)
        {
            var take = Globals.MaxItemForJobList;
            var skip = (pageNumber - 1) * Globals.MaxItemForJobList;

            var jobPosts = from post in _db.JobPosts where post.IsDeleted == false select post;

            var postCount = jobPosts.Count();
            var maxPage = 0;
            double _temp = (double)postCount / Globals.MaxItemForJobList;

            if (_temp > 0 && _temp < 1)
            {
                maxPage = 1;
            }
            else if (_temp > 1)
            {
                maxPage = _temp > (int)_temp ? (int)_temp + 1 : (int)_temp;
            }

            jobPosts = jobPosts.Skip(skip).Take(take);

            return (jobPosts, maxPage);
        }
    }
}
