using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PostMicroService.Services.Interfaces;

namespace PostMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPostController : Controller
    {
        private readonly IJobPostService? _jobPostService;

        public JobPostController(IJobPostService? jobPostService)
        {
            _jobPostService = jobPostService;
        }

        [HttpGet("GetAllJobPostsByPage")]
       public IActionResult GetAllJobPostsByPage(int page=1)
        {
            var result = _jobPostService.GetAllJobPostsByPage(page);
            return Json(new { jobPostList = result.jobPosts, maxPageNumber = result.maxPage });
        }
    }
}
