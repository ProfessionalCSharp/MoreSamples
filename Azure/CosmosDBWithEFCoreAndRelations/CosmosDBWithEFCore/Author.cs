using System;

namespace CosmosDBWithEFCore
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
