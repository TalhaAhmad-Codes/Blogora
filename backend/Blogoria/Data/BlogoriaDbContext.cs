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
            /* User - Configurations */
            modelBuilder.Entity<User>(builder =>
            {
                // Owns a unique (email) value object
                builder.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Value)
                         .HasColumnName("Email")
                         .IsRequired();

                    email.HasIndex(e => e.Value)
                         .IsUnique();
                });

                // Username is required and must be unique
                builder.Property(u => u.Username)
                       .IsRequired();

                builder.HasIndex(u => u.Username)
                       .IsUnique();
            });

            /* Blog - Configurations */
            // Blog → User (One-to-Many)
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.Blog)
                .HasForeignKey(c => c.BlogId);

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Reactions)
                .WithOne(r => r.Blog)
                .HasForeignKey(r => r.BlogId);

            // For Performance
            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.UserId);

            /* User Reaction - Configurations */
            modelBuilder.Entity<UserReaction>(builder =>
            {
                // User → Reactions (One-to-Many)
                builder.HasOne(r => r.User)
                       .WithMany(u => u.Reactions)
                       .HasForeignKey(r => r.UserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Blog → Reactions (One-to-Many)
                builder.HasOne(r => r.Blog)
                       .WithMany(b => b.Reactions)
                       .HasForeignKey(r => r.BlogId)
                       .OnDelete(DeleteBehavior.Cascade);

                // One reaction per user per blog
                builder.HasIndex(r => new { r.UserId, r.BlogId })
                       .IsUnique();

                // Performance
                builder.HasIndex(r => r.BlogId);
            });

            /* User Comment - Configurations */
            modelBuilder.Entity<UserComment>(builder =>
            {
                // User → Comment (One-to-Many)
                builder.HasOne(c => c.User)
                       .WithMany(u => u.Comments)
                       .HasForeignKey(c => c.UserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Blog → Comment (One-to-Many)
                builder.HasOne(c => c.Blog)
                       .WithMany(b => b.Comments)
                       .HasForeignKey(c => c.BlogId)
                       .OnDelete(DeleteBehavior.Cascade);

                // Order
                builder.HasIndex(c => new { c.BlogId, c.CreatedAt });

                // Performance
                builder.HasIndex(c => c.BlogId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
