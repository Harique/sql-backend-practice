using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using api.Abstractions;
using api.Library.Models;

namespace api.Controllers
{
    [EnableCors("Cors-Policy")]
    [Route("api/publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherrepo;
        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherrepo = publisherRepository;
        }

        [HttpDelete("{publisherName}")]
        public async Task deletePublisher([FromRoute] string publisherName)
        {
            try
            {
                await _publisherrepo.deletePublisher(publisherName);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());

            }
        }
        [HttpPatch("{author}")]
        public async Task updatePublisher([FromRoute] string author,[FromBody] Publisher publisher)
        {
            try
            {
                await _publisherrepo.updatePublisherName(publisher.Name,author);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());

            }
        }
    }
}









