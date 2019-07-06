using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WasabiUI.Forms.Core.Renderers;

namespace WasabiUI.Forms.Core
{

    public class PlatformServices
    {
        private PlatformServices()
        {

        }

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
        public static void AddStylePropertyFormatters(this IServiceCollection services, params Assembly[] assemblies)
        {
            var f = new StylePropertyFormatterFactory();

            f.Build(assemblies);

            services.AddSingleton<IStylePropertyFormatterFactory>(f);
        }

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

    public interface IStylePropertyFormatterFactory
    {
        Type GetFormatter(string name);
    }

    public class StylePropertyFormatterFactory : IStylePropertyFormatterFactory
    {
        private readonly ConcurrentDictionary<string, Type> _dict = new ConcurrentDictionary<string, Type>();

        public void Build(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var typesWithMyAttribute = TypesWithMyAttribute(assembly);
                foreach (var (key, value) in typesWithMyAttribute)
                {
                    _dict[key] = value;
                }
            }
        }

        public Type GetFormatter(string name)
        {
            return _dict[name];
        }

        private static Dictionary<string, Type> TypesWithMyAttribute(Assembly assembly)
        {
            return (from t in assembly.GetTypes()
                    let attributes = t.GetCustomAttributes(typeof(StylePropertyFormatterAttribute), true)
                    where attributes != null && attributes.Length > 0
                    select new {Type = t, Attribute = attributes.Cast<StylePropertyFormatterAttribute>().SingleOrDefault()})
                .ToDictionary(e => e.Attribute.CssPropertyName, v => v.Type);
        }
    }
}
