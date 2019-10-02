using Microsoft.Extensions.Configuration;

namespace Contacts.Core.Configuration
{
    public class CosmosSettings
    {
        public string AccountEndpoint { get; set; }
        public string AccountKey { get; set; }
        public string DatabaseName { get; set; }

        public static CosmosSettings Create(IConfiguration configuration)
        {
            return new CosmosSettings
            {
                AccountEndpoint = configuration["CosmosSettings:AccountEndpoint"],
                AccountKey      = configuration["CosmosSettings:AccountKey"],
                DatabaseName    = configuration["CosmosSettings:DatabaseName"]
            };
        }
    }
}