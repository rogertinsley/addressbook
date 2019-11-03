using System;
using System.Linq;
using Contacts.Core.Data;
using Contacts.Core.Model;
using Shouldly;
using Xunit;

namespace Integration.CosmosDb
{
    public class CosmosRepositoryTests : IClassFixture<CosmosRepositoryFixture>
    {
        private IRepository<Contact, ContactContext> Repository { get; set; }

        public CosmosRepositoryTests(CosmosRepositoryFixture fixture)
        {
            Repository = fixture.Repository;
        }

        [Fact]
        public void Can_add_and_query()
        {
            Repository.EnsureDeleted();
            Repository.EnsureCreated();

            Repository.Add(new Contact
            {
                Id = Guid.NewGuid(),
                CustomerId = "1234567890",
                Forename = "Forename",
                Surname = "Surname",
            });

            var contact = Repository.GetAsQueryable().Single(c => c.Forename == "Forename" && c.Surname == "Surname");

            contact.CustomerId.ShouldBe("1234567890");
            contact.Forename.ShouldBe("Forename");
            contact.Surname.ShouldBe("Surname");

            Repository.EnsureDeleted();
        }
    }
}
