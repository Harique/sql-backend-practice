using api.Library;

namespace api.Abstractions      
{
    public interface IBookRepository
    {
        Task insertBook(Book book);
        Task deleteBook(string title);
        Task updateBookTitle(string oldTitle, string newTitle);

    }
}