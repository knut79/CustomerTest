using Gyldendal.Customer.Business.Wrappers;
using Gyldendal.Customer.Data.DbContext;
using Gyldendal.Customer.Data.Repository;
using Gyldendal.Customer.WebApi.ActionFilters;
using Microsoft.EntityFrameworkCore;

namespace Gyldendal.Customer.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(
                l => l.Filters.Add<HttpResponseExceptionFilter>()
                );
            builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
            builder.Services.AddScoped<ICustomersRepositoryProxy, CustomersRepositoryProxy>();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
            }, ServiceLifetime.Scoped);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}