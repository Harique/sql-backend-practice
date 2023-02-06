namespace api.Abstractions      
{
    public interface IPublisherRepository
    {
        Task deletePublisher(string name);
        Task updatePublisherName(string oldName, string newName);
    }
}