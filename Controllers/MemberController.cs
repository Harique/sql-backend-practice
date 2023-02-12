using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using api.Abstractions;
using api.Library.Models;

namespace api.Controllers
{
    [EnableCors("Cors-Policy")]
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberrepo;
        public MemberController(IMemberRepository memberRepository)
        {
            _memberrepo = memberRepository;
        }
        [HttpPost]
        public async Task insertMember([FromBody] Members member)
        {
            await _memberrepo.insertMember(member);
        }


    }
}









