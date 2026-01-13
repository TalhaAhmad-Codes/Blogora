using Blogoria.Data;
using Blogoria.Repositories;
using Blogoria.Repositories.Interfaces;
using Blogoria.Services;
using Blogoria.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
//using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Blogoria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add database connection
            builder.Services.AddDbContext<BlogoriaDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure();
                })
            );

            // Add repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserCommentRepository, UserCommentRepository>();
            builder.Services.AddScoped<IUserReactionRepository, UserReactionRepository>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();

            // Add services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBlogService, BlogService>();
            builder.Services.AddScoped<IUserReactionService, UserReactionService>();
            builder.Services.AddScoped<IUserCommentService, UserCommentService>();

            // Add services to the container.
            builder.Services.AddControllers();

            // Register the Swagger generator
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Port
            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
                app.UseSwaggerUI();

                app.MapOpenApi();
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseForwardedHeaders();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
