using Datos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Denti_Salud.Config;
using Denti_Salud.Hubs;
using Microsoft.OpenApi.Models; 
using Microsoft.AspNetCore.SignalR;

namespace Denti_Salud
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
      var connectionString = Configuration.GetConnectionString("DefaultConnection1");
      services.AddDbContext<DentisaludContext>(p => p.UseSqlServer(connectionString));
      services.AddControllersWithViews();
      #region    configure strongly typed settings objects
      var appSettingsSection = Configuration.GetSection("AppSetting");
      services.Configure<AppSetting>(appSettingsSection);
      #endregion

      #region Configure jwt authentication
      var appSettings = appSettingsSection.Get<AppSetting>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
      });
            #endregion
      
      services.AddSwaggerGen(c =>
      {
          c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
          {
              Name ="Authorization",
              Type = SecuritySchemeType.Http,
              Scheme = "bearer",
              BearerFormat = "JWT",
              In = ParameterLocation.Header,
              Description ="JWT authorization header using the beares scheme"
          });
          c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
              {
                  new OpenApiSecurityScheme
                  {
                      Reference = new OpenApiReference
                      {
                          Type = ReferenceType.SecurityScheme,
                          Id ="bearerAuth"
                      }
                  },
                  new string[]{}
              }
          });
      });
      
      // In production, the Angular files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/dist";
      });
      services.AddSignalR();  
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
     
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });


      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      if (!env.IsDevelopment())
      {
        app.UseSpaStaticFiles();
      }

      app.UseRouting();

      #region global cors policy activate Authentication/Authorization
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

      app.UseEndpoints(endpoints =>
      {
          endpoints.MapHub<SignalHub>("/signalHub");
          endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");
      });
            
     app.UseSpa(spa =>
      {
              // To learn more about options for serving an Angular SPA from ASP.NET Core,
              // see https://go.microsoft.com/fwlink/?linkid=864501

              spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseAngularCliServer(npmScript: "start");
        }
      });
    }
  }
}
