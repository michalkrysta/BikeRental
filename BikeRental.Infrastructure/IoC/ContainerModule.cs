﻿using Autofac;
using BikeRental.Infrastructure.IoC.Modules;
using BikeRental.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;

namespace BikeRental.Infrastructure.IoC
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            //builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}