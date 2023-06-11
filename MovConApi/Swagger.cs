using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MovConApi
{
    public class Swagger
    {
        public static void ConfigureSwagger(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MovConApi",
                    Description = "MovConApi",
                    Version = "1.0"
                });

                options.EnableAnnotations();
            });
        }

        public static void UseSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(ui => {
                ui.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
                ui.RoutePrefix = string.Empty;
            });
        }
    }
}
