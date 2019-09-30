namespace Contacts.Core.Data.Model.Contacts
{
    public class Contact : Entity
    {
        public string CustomerId             { get; set; }
        public Name Name                     { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public Address Address               { get; set; }
    }
}
