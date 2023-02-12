using api.Abstractions;
using api.Library.Models;
using api.Library.Context;

namespace api.Repositories;
class BookRepository : IBookRepository
{
    public BookRepository()
    {

    }
    public async Task<int> getBookID(string title)
    {
        await using (var context = new LibraryContext())
        {
            //Fetches the book with the same title given in params
            var book = context.Book.Single(a => a.Title == title);
            
            return book.ID;
        }
    }
    public async Task insertBook(Book book)
    {
        await using (var context = new LibraryContext())
        {

            // Creates the database if not exists
            context.Database.EnsureCreated();
            await context.Publisher.AddAsync(book.Publisher);
            await context.Book.AddAsync(book);
            context.SaveChanges();

        }
    }
    public async Task deleteBook(string title)
    {
        await using (var context = new LibraryContext())
        {
            //Fetches the book with the same title given in params
            var book = context.Book.Single(a => a.Title == title);

            context.Remove(book);
            context.SaveChanges();

        }
    }
    public async Task updateBookTitle(string oldTitle, string newTitle)
    {
        await using (var context = new LibraryContext())
        {
            var book = context.Book.Single(a => a.Title == oldTitle);
            book.Title = newTitle;
            context.SaveChanges();
        }
    }
    public async Task addRentedBook(int book_id, int member_id)
    {
        await using (var context = new LibraryContext())
        {
            Book_Rental rentedBook = new Book_Rental
            {
                BookId = book_id,
                MemberId = member_id
            };
            await context.Book_Rentals.AddAsync(rentedBook);
            context.SaveChanges();
        }
    }
}
