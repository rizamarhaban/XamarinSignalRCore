using AspNetCoreSignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreSignalR
{
    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSignalR();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(cors =>
            {
                cors.AllowAnyHeader();
                cors.AllowAnyOrigin();
                cors.AllowAnyMethod();
            });

            app.UseWebSockets();

            app.UseSignalR(routes =>
            {
                routes.MapHub<MySignalRHub>("updater");
            });
        }
    }
}
