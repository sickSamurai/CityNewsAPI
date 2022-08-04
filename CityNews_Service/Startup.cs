using CityNews_Application;

using CityNews_Persistence.Context;

using CityNews_ServiceAgent;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;

namespace CityNews_Service {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services) {
      var connectionString = Configuration.GetConnectionString("DefaultConnection");

      Console.WriteLine(connectionString);

      services.AddDbContext<HistorialContext>(options =>
          options.UseSqlServer(connectionString));

      services.AddControllers();
      services.AddServiceAgent();
      services.AddApplications();
      services.AddCors();

      AddSwagger(services);
    }

    private void AddSwagger(IServiceCollection services) {
      services.AddSwaggerGen(options => {
        var groupName = "v1";

        options.SwaggerDoc(groupName, new OpenApiInfo {
          Title = $"Challenge {groupName}",
          Version = groupName,
          Description = "Challenge CityNews API",
          Contact = new OpenApiContact {
            Name = "CityNews",
            Email = "ldmckkb@gmail.com",
            Url = new Uri("https://linkedin.com/"),
          }
        });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if(env.IsDevelopment())
        app.UseDeveloperExceptionPage();


      app.UseHttpsRedirection();

      app.UseRouting();
      app.UseCors(options => {
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
        options.AllowAnyHeader();
      });
      app.UseSwagger();
      app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CityNews API v1");
      });

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
