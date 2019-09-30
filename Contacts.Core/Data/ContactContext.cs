using Contacts.Core.Data.Model.Contacts;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Core.Data
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
