﻿using Microsoft.Extensions.Configuration;

namespace TermPaper.Shared.Settings
{
    public static class SettingsFactory
    {
        public static IConfiguration Create(IConfiguration? configuration = null)
        {
            var conf = configuration ?? new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json", optional: false)
                                            .AddJsonFile("appsettings.development.json", optional: true)
                                            .AddEnvironmentVariables()
                                            .Build();
            return conf;
        }
    }
}
