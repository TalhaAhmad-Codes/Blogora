using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blogoria.Data
{
    public sealed class BlogoriaDbContextFactory : IDesignTimeDbContextFactory<BlogoriaDbContext>
    {
        public BlogoriaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogoriaDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-J8HKFCR\\SQLEXPRESS;Database=BlogoriaDB;Trusted_Connection=True;TrustServerCertificate=True");

            return new BlogoriaDbContext(optionsBuilder.Options);
        }
    }
}
