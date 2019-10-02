using Contacts.Core.Configuration;
using Contacts.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Exploratory
{
    public class Seed
    {
        private IConfiguration Configuration { get; set; }

        public Seed()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Seed>();

            Configuration = builder.Build();
        }

        [Fact]
        public void Contacts()
        {
            var contacts = new Fake().GenerateContacts(100);

            var settings = CosmosSettings.Create(Configuration);

            var dbOption = new DbContextOptionsBuilder<ContactContext>()
                .UseCosmos(
                    accountEndpoint: settings.AccountEndpoint,
                    accountKey     : settings.AccountKey,
                    databaseName   : settings.DatabaseName)
                .Options;

            using (var context = new ContactContext(dbOption))
            {
                context.Database.EnsureCreated();
                context.AddRange(contacts);
                context.SaveChanges();
            }
        }
    }
}
