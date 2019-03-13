using Autofac;
using BikeRental.Infrastructure.Extensions;
using BikeRental.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace BikeRental.Infrastructure.IoC.Modules
{
    public class SettingsModule : Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                .SingleInstance();
        }
    }
}