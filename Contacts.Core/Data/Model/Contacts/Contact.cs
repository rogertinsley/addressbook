namespace Contacts.Core.Data.Model.Contacts
{
    public class Contact : Entity
    {
        public string CustomerId  { get; set; }
        public string Forename    { get; set; }
        public string Surname     { get; set; }
        public string Email       { get; set; }
        public string Line1       { get; set; }
        public string City        { get; set; }
        public string County      { get; set; }
        public string State       { get; set; }
        public string Country     { get; set; }
        public string Zip         { get; set; }
    }
}
