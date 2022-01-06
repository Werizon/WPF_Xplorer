﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WPF_Xplorer.HostBuilders
{
    public static class AddConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfig(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("AppConfig.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
