using Blogoria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogoria.Data
{
    public sealed class BlogoriaDbContext : DbContext
    {
        /*// <----- DbSets -----> //*/
        public DbSet<User> Users => Set<User>();
        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<UserReaction> UserReactions => Set<UserReaction>();
        public DbSet<UserComment> UserComments => Set<UserComment>();

        // Constructor
        public BlogoriaDbContext(DbContextOptions<BlogoriaDbContext> context) : base(context) { }
    }
}
