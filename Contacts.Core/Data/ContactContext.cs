using Contacts.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Core.Data
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Contacts");

            modelBuilder.Entity<Contact>().ToContainer("Contacts");
            modelBuilder.Entity<Contact>().HasPartitionKey(c => c.CustomerId);
        }
    }
}
