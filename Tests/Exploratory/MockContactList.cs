using System;
using System.Collections.Generic;
using Bogus;
using Contacts.Core.Model;

namespace Exploratory
{
    public class Fake
    {
        public Faker<Contact> Contacts { get; }

        public string[] CustomerIds = { "10000", "20000", "30000", "40000", "50000", "60000" };

        public Fake()
        {
            Contacts = new Faker<Contact>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.CustomerId, f => f.PickRandom(CustomerIds))
                .RuleFor(fake => fake.Forename, f => f.Name.FirstName())
                .RuleFor(fake => fake.Surname, f => f.Name.LastName())
                .RuleFor(fake => fake.Line1, f => $"{f.Address.BuildingNumber()} {f.Address.StreetName()}")
                .RuleFor(fake => fake.City, f => f.Address.City())
                .RuleFor(fake => fake.County, f => f.Address.County())
                .RuleFor(fake => fake.Country, "USA")
                .RuleFor(fake => fake.State, f => f.Address.State())
                .RuleFor(fake => fake.Zip, f => f.Address.ZipCode())
                .RuleFor(fake => fake.Email, (f, u) => f.Internet.Email(u.Forename, u.Surname));
        }

        public List<Contact> GenerateContacts(int count)
        {
            var contacts = new List<Contact>();

            for (int i=0; i < count; i++)
            {
                contacts.Add(Contacts.Generate());
            }

            return contacts;
        }
    }
}
