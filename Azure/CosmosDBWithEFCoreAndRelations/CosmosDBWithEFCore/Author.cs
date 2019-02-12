using System;

namespace CosmosDBWithEFCore
{
    public class Author
    {
        public Author(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);


        public Guid AuthorId { get; } = Guid.NewGuid();
        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
