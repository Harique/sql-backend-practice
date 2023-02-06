using api.Abstractions;
using api.Library;
using api.Library.Context;

namespace api.Repositories;
class BookRepository : IBookRepository
{
    public BookRepository()
    {

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
}
