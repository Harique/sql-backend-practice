using api.Abstractions;
using api.Library.Models;
using api.Library.Context;


namespace api.Repositories;
class MemberRepository : IMemberRepository
{
    public MemberRepository() { }

    public async Task insertMember(Members member)
    {
        await using (var context = new LibraryContext())
        {

            // Creates the database if not exists
            context.Database.EnsureCreated();
            await context.Members.AddAsync(member);
            Console.WriteLine(member.ToString());

            context.SaveChanges();

        }
    }
    public async Task<int> getMemberID(string name)
    {
        await using (var context = new LibraryContext())
        {
            //Fetches the book with the same title given in params
            var member = context.Members.Single(a => a.Name == name);

            return member.ID;
        }
    }
}