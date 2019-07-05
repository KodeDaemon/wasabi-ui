using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WasabiUI.Forms.Core
{

    public class PlatformServices
    {
        private PlatformServices()
        {

        }

        //public static IServiceCollection ServiceCollection { get; internal set; }

        public static DeviceState DeviceState
        {
            get
            {
                using var scope = ServiceProvider.CreateScope();
                return scope.ServiceProvider.GetService<DeviceState>();
            }
        }

        public static IServiceProvider ServiceProvider { get; set; }
    }


    public static class ServiceCollectionExtensions
    {
        public static void AddWasabiPlatformServices(this IServiceCollection services)
        {
            services.AddScoped<DeviceState>();
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static void UseWasabiPlatform(this IApplicationBuilder app)
        {
            PlatformServices.ServiceProvider = app.ApplicationServices;
        }
    }
}
