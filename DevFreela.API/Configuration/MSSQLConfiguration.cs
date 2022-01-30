using DevFreela.Infrastructure.Persistence.Context;
using Microsoft.Extensions.Configuration;

namespace DevFreela.API.Configuration
{
    public class MSSQLConfiguration : IDBConfiguration
    {
        private readonly IConfiguration configuration;

        public MSSQLConfiguration(IConfiguration config)
        {
            configuration = config;
        }
        public string ConnectionString => configuration.GetConnectionString("DevFreelaCs");
    }
}
