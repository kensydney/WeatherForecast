using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Weather.Services;

namespace Weather
{
    public class AutofacModule : Autofac.Module
    {
        public string ConnectionString_Application { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(WebApiApplication).Assembly;

            // ASP.NET MVC types
            builder.RegisterControllers(assembly);
            builder.RegisterApiControllers(assembly);
            builder.RegisterModelBinders(assembly);
            builder.RegisterFilterProvider();
            builder.RegisterType<CountryService>().As<ICountryService>();
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();

        }


    }
}