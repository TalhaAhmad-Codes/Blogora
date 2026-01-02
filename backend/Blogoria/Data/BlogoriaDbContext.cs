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

        // Method - Do some configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* User - Configuration */
            //modelBuilder.Entity<User>()
            //    .OwnsOne(u => u.Email, e =>
            //    {
            //        e.Property(p => p.Value)
            //            .HasColumnName("Email")
            //            .IsRequired();
            //    });

            //modelBuilder.Entity<User>()
            //    .HasIndex(u => u.Username)
            //    .IsUnique();
            modelBuilder.Entity<User>(builder =>
            {
                builder.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Value)
                         .HasColumnName("Email")
                         .IsRequired();

                    email.HasIndex(e => e.Value)
                         .IsUnique();
                });

                builder.Property(u => u.Username)
                       .IsRequired();

                builder.HasIndex(u => u.Username)
                       .IsUnique();
            });

            //modelBuilder.Entity<User>()
            //    .HasIndex("Email")
            //    .IsUnique();

            /* Blog - Configuration */
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Comments)
                .WithOne()
                .HasForeignKey("BlogId");

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Reactions)
                .WithOne()
                .HasForeignKey("BlogId");

            base.OnModelCreating(modelBuilder);
        }
    }
}
