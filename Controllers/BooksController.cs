using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using api.Library;
using api.Library.Context;

namespace api.BooksController
{
    [EnableCors("Cors-Policy")]
    [Route("api/books")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        public BooksController()
        {

        }

        [HttpPost]
        public void addBook([FromBody] Book book)
        {
            Console.WriteLine("hit the controller");
            try
            {
                using (var context = new LibraryContext())
                {

                    // Creates the database if not exists
                    context.Database.EnsureCreated();
                    /*var publisher = new Publisher
                    {
                        
                    };
                    context.Publisher.Add(publisher);*/

                    context.Book.Add(new Book
                    {
                        ISBN = book.ISBN,
                        Title = book.Title,
                        Author = book.Author,
                        Language = book.Language,
                        Pages = book.Pages,
                        Publisher = book.Publisher
                    });
                    context.SaveChanges();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }



        }
    }
}

