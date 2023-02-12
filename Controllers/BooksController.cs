using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using api.Library.Models;
using api.Library.Models.DTO;
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
        private readonly IMemberRepository _memberrepo;
        public BooksController(IMemberRepository memberRepository,IBookRepository bookRepository, IPublisherRepository publisherRepository)
        {
            _bookrepo = bookRepository;
            _publisherrepo = publisherRepository;
            _memberrepo = memberRepository;
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
        [HttpPost("rent")]
        public async Task addRentedBook([FromBody] Rental_Info info)
        {
            try
            {
                var bookId = await _bookrepo.getBookID(info.Title);
                var memberId = await _memberrepo.getMemberID(info.MemberName);

                await _bookrepo.addRentedBook(bookId,memberId);
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
        public async Task updateBookTitle([FromBody] Book book, [FromRoute] string newTitle)
        {
            try
            {
                await _bookrepo.updateBookTitle(book.Title, newTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}

