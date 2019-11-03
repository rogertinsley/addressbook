using System;
using Contacts.Core.Configuration;
using Contacts.Core.Data;
using Contacts.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Integration.CosmosDb
{
    public class CosmosRepositoryFixture : IDisposable
    {
        public IRepository<Contact, ContactContext> Repository { get; private set; }
        private readonly ContactContext context;

        public CosmosRepositoryFixture()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<CosmosRepositoryTests>();

            var configuration = builder.Build();

            var settings = CosmosSettings.Create(configuration);

            var dbOption = new DbContextOptionsBuilder<ContactContext>()
                .UseCosmos(
                    accountEndpoint: settings.AccountEndpoint,
                    accountKey: settings.AccountKey,
                    databaseName: $"({settings.DatabaseName}-integration-test")
                .Options;

            context = new ContactContext(dbOption);
            Repository = new CosmosEntityRepository<Contact, ContactContext>(context);
        }

        public void Dispose()
        {
            context?.Dispose();
            Repository?.Dispose();
        }
    }
}