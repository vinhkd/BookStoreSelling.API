using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Domain.Services;
using BookStoreSelling.API.Extensions;
using BookStoreSelling.API.Persistence.Contexts;
using BookStoreSelling.API.Persistence.Repositories;
using BookStoreSelling.API.Services;
using Quartz;
using BookStoreSelling.API.Infrastructure;

namespace BookStoreSelling.API
{
  public class Startup
  {
    public readonly IConfiguration Configuration;
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMemoryCache();

      services.AddCustomSwagger();

      services.AddControllers();
      
      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseInMemoryDatabase(Configuration.GetConnectionString("memory"));
      });

      services.AddQuartz(q =>
      {
        //TODO: Here is the job to:
        // - Activate to run at a certain time or a certain time of day
        // - Connect and read an email.
        // - Download XML and parse XML files.
        // - Deserialize file content and save data to database
        //(We can use store name and ISBN code to identify a book)
        q.UseMicrosoftDependencyInjectionScopedJobFactory();
        q.AddJobAndTrigger<InitDataJob>(Configuration);
      });
      services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        
      services.AddScoped<IStoreRepository, StoreRepository>();
      services.AddScoped<IBookRepository, BookRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddScoped<IStoreService, StoreService>();
      services.AddScoped<IBookService, BookService>();

      services.AddAutoMapper(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCustomSwagger();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}