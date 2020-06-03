using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBasite.Ultilities
{
    public class Common
    {
        public IConfiguration Configuration { get; }

        public static string GetByKey(string key)
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json").Build();
            var result = configuration.GetSection(key).Value;
            return result;
        }
        public static string GetSection(string key)
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json").Build();
            var result = configuration[key];
            return result;
        }

    }
}
