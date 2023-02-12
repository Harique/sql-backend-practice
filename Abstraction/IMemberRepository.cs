using api.Library.Models;
namespace api.Abstractions
{
    public interface IMemberRepository
    {
        public Task insertMember(Members members);
        Task<int> getMemberID(string name);
    }
}