namespace api.Library.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
    public class Publisher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Employees
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Date_of_Birth { get; set; }
    }
    public class Members
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date_of_Birth { get; set; }
    }
    public class Book_Rental
    {
        public int MemberId {get;set;}
        public Members Member { get; set; }
        public int BookId {get;set;}
        public Book Book { get; set; }
    }

}