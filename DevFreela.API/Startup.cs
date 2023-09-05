using DevFreela.API.Models;
using DevFreela.infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DevFreela.Application.Commands.CreateProject;

namespace DevFreela.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<OpeningTimeOption>(Configuration.GetSection("OpeningTime"));

            var connectionString = Configuration.GetConnectionString("DevFreelaCs");
            services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

            // Usar banco só em mémoria (para testes). Depois é so gerar as migrations
            // dotnet add package Microsoft.EntityFrameworkCore.InMemory
            // services.AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("DevFreela"));

            services.AddMediatR(typeof(CreateProjectCommand));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
