using Application;

using ServiceAgent;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;
using Persistence;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace Service {
  public class Startup {
    public IConfiguration Configuration { get; }
    private readonly string ClientAppRootPath;
    private readonly string ClientAppStartScript;
    private readonly string ClientAppUrl;
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
      ClientAppRootPath = Configuration["ClientApp:RootPath"];
      ClientAppStartScript = Configuration["ClientApp:StartScript"];
      ClientAppUrl = Configuration["ClientApp:Url"];
    }


    public void ConfigureServices(IServiceCollection services) {
      var connectionString = Configuration.GetConnectionString("DefaultConnection");

      services.AddDbContext<CityNewsDbContext>(options => options.UseSqlServer(connectionString));
      services.AddControllers();
      services.AddServiceAgent();
      services.AddApplications();
      services.AddCors();

      services.AddSpaStaticFiles(configuration => {
        configuration.RootPath = $"{ClientAppRootPath}/build";
      });


      AddSwagger(services);
    }

    private void AddSwagger(IServiceCollection services) {
      services.AddSwaggerGen(options => {
        var groupName = "v1";

        options.SwaggerDoc(groupName, new OpenApiInfo {
          Title = $"Challenge {groupName}",
          Version = "v1",
          Description = "Challenge CityNews API",
          Contact = new OpenApiContact {
            Name = "CityNews",
            Email = "ldmckkb@gmail.com",
            Url = new Uri("https://github.com/sickSamurai"),
          }
        });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if(env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseRouting();
      
      app.UseCors(options => {
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
        options.AllowAnyHeader();
      });

      app.UseSwagger();
      
      app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CityNews API v1");
      });

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
