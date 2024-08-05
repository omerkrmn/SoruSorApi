using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoruSorApi.Repositories;

namespace SoruSorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public AnswerController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostAnswer([FromQuery(Name ="questionID")]int questionID, [FromQuery(Name = "Answer")]string answer)
        {
            return Ok();
        }
    }
}
