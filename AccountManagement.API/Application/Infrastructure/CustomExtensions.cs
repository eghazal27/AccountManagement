using AccountManagement.Infrastructure.Data.Repositories;
using AccountManagement.Service.Services;
using AccountManagement.Services;

namespace AccountManagement.API.Application.Infrastructure
{
    public static class CustomExtensions
    {
       

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Account Management API v1");
            });
        }

    }
}
