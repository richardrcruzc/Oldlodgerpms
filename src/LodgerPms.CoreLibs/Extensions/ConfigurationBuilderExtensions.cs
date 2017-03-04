﻿using LodgerPms.CoreLibs.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LodgerPms.CoreLibs.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationRoot BuildHostConfiguration(this ConfigurationBuilder builder, ILogger logger = null)
        {
            var configFullPath = ConfigHelper.GetConfigRootPath("hosting.json", logger);
            return builder
                .AddJsonFile(configFullPath, true)
                .Build();
        }
    }
}