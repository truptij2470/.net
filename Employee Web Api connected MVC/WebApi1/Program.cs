
using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<Acts2023Context>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("Acts2023Context")));

            builder.Services.AddCors(c=>c.AddDefaultPolicy(dfpolicy=>dfpolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}