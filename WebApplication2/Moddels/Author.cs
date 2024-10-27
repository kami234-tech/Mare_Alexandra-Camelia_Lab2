namespace WebApplication2.Moddels
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // Proprietate pentru numele complet

        public ICollection<Book>? Books { get; set; }
    }
}
