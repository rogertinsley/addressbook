﻿using Contacts.Core.Data;
using Xunit;

namespace Exploratory
{
    public class Seed
    {
        [Fact]
        public void Contacts()
        {
            var contacts = new Fake().GenerateContacts(100);

            using (var context = new ContactContext())
            {
                context.SaveChanges();
            }
        }
    }
}
