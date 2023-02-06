using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using api.Library;
using api.Abstractions;

namespace api.BooksController
{
    [EnableCors("Cors-Policy")]
    [Route("api/books")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookrepo;
        private readonly IPublisherRepository _publisherrepo;
        public BooksController(IBookRepository bookRepository, IPublisherRepository publisherRepository)
        {
            _bookrepo = bookRepository;
            _publisherrepo = publisherRepository;
        }

        [HttpPost]
        public async Task addBook([FromBody] Book book)
        {
            try
            {
                var publisher = new Publisher
                {
                    Name = book.Publisher.Name,

                };

                Book Book = new Book
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author,
                    Language = book.Language,
                    Pages = book.Pages,
                    Publisher = publisher
                };

                await _bookrepo.insertBook(Book);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        [HttpDelete("{title}")]
        public async Task deleteBook([FromRoute] string title)
        {
            try
            {
                await _bookrepo.deleteBook(title);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());

            }

        }
        [HttpPatch("{newTitle}")]
        public async Task updateBookTitle([FromBody]Book book,[FromRoute] string newTitle)
        {
            try
            {
                await _bookrepo.updateBookTitle(book.Title,newTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}

