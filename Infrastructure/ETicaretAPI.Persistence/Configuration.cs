using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), ""));
                configurationManager.AddJsonFile("appsettings.json");
            //C: \Users\enesyalcin\source\repos\ETicaretUygulaması\ETicaretAPI\Persistance\ETicaretAPI.API\ETicaretAPI.API.csproj
                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
