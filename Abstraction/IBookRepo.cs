using api.Library.Models;

namespace api.Abstractions      
{
    public interface IBookRepository
    {
        Task insertBook(Book book);
        Task deleteBook(string title);
        Task updateBookTitle(string oldTitle, string newTitle);
        Task addRentedBook(int book_id, int member_id);
        Task<int> getBookID(string title);
    }
}