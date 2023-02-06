using api.Abstractions;
using api.Library.Context;

namespace api.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        public PublisherRepository()
        {

        }

        public async Task deletePublisher(string name)
        {

            await using (var context = new LibraryContext())
            {
                var publisher = context.Publisher.Single(p => p.Name == name);

                context.Remove(publisher);
                context.SaveChanges();
            }

        }
        public async Task updatePublisherName(string oldName, string newName)
        {
            await using (var context = new LibraryContext())
            {
                var publisher = context.Publisher.Single(p => p.Name == oldName);
                publisher.Name = newName;
                context.SaveChanges();
            }
        }
    }
}