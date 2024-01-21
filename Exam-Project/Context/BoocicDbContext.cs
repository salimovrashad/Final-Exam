using Exam_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam_Project.Context
{
    public class BoocicDbContext : IdentityDbContext
    {
        public BoocicDbContext(DbContextOptions opt) : base (opt)
        {
        }
        public DbSet<Service> Services { get; set; }
    }
}
