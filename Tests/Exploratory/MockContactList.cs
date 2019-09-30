using System.Collections.Generic;
using Bogus;
using Contacts.Core.Data.Model.Contacts;

namespace Exploratory
{
    public class Fake
    {
        public Faker<Contact> Contacts { get; }
        public Faker<Name> Names { get; }
        public Faker<Address> Addresses { get; }
        public Faker<ContactDetails> ContactDetails { get; }

        public string[] CustomerIds = { "10000", "20000", "30000", "40000", "50000" };

        public Fake()
        {

            Contacts = new Faker<Contact>()
                .RuleFor(c => c.CustomerId, f => f.PickRandom(CustomerIds));

            Names = new Faker<Name>()
                .RuleFor(fake => fake.Forename, f => f.Name.FirstName())
                .RuleFor(fake => fake.Surname, f => f.Name.LastName());

            Addresses = new Faker<Address>()
                .RuleFor(fake => fake.Line1, f => $"{f.Address.BuildingNumber()} {f.Address.StreetName()}")
                .RuleFor(fake => fake.City, f => f.Address.City())
                .RuleFor(fake => fake.County, f => f.Address.County())
                .RuleFor(fake => fake.State, f => f.Address.State())
                .RuleFor(fake => fake.Zip, f => f.Address.ZipCode());

            ContactDetails = new Faker<ContactDetails>()
                .RuleFor(fake => fake.Email, f => f.Internet.Email());
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
