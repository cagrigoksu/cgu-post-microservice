using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PostMicroService.Models.Data;

namespace PostMicroService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<JobPostDataModel> JobPosts { get; set; }

    }
}
